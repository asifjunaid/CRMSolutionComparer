using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMSolutionComparer.Utilities
{
    public class SolutionManager
    {
        public string SourceSolutionName { get; set; }
        public string TargetSolutionName  {get; set; }
       
        public IEnumerable<Entity> RetrieveSolutions(IOrganizationService service)
        {
            var qe = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet(new[]{
                                            "publisherid", "installedon", "version",
                                            "uniquename", "friendlyname", "description",
                                            "ismanaged"
                                        }),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("isvisible", ConditionOperator.Equal, true),
                        new ConditionExpression("uniquename", ConditionOperator.NotEqual, "Default")
                    }
                }
            };

            return service.RetrieveMultiple(qe).Entities;
        }
        public void ExportSolution(IOrganizationService service, string solutionName, Guid solutionId)
        {
           
            string filename = solutionName + ".zip";
            //string filePath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.ToString();
            //filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";
            
            string filePath = System.IO.Path.GetTempPath();
            filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";
            Directory.CreateDirectory(filePath);

            if (File.Exists(filePath + filename))
            {
                DialogResult dr = MessageBox.Show($"Soltution file {filePath + filename} already exist. Do you want to export again?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    return;
            }
            QueryExpression querySampleSolution = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet(new string[] { "publisherid", "installedon", "version", "versionnumber", "friendlyname", "uniquename" }),
                Criteria = new FilterExpression()
            };

            querySampleSolution.Criteria.AddCondition("solutionid", ConditionOperator.Equal, solutionId);
            var solution = service.RetrieveMultiple(querySampleSolution).Entities[0];

            ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
            exportSolutionRequest.Managed = false;
            exportSolutionRequest.SolutionName = solution.GetAttributeValue<string>("uniquename");

            ExportSolutionResponse exportSolutionResponse = (ExportSolutionResponse)service.Execute(exportSolutionRequest);

            byte[] exportXml = exportSolutionResponse.ExportSolutionFile;

            System.IO.File.WriteAllBytes($@"{filePath + filename}", exportXml);
            Console.WriteLine($"Solution exported on path {filePath + filename}");
        }
        public Tuple<string,string> ExtractSolution(string sourceSolutionName, string targetSolutionName) {

            //string filePath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.ToString();
            string filePath = System.IO.Path.GetTempPath();
            filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";

            string solutionPackagerFileName = Path.Combine($@"{filePath}Microsoft.CrmSdk.CoreTools.9.1.0.79\content\bin\coretools", "SolutionPackager.exe");

            string zipFileName1 = $@"{filePath + sourceSolutionName}.zip";
            string folderPath1 = $@"{filePath + sourceSolutionName}";
            

            string zipFileName2 = $@"{filePath + targetSolutionName}.zip";
            string folderPath2 = $@"{filePath + targetSolutionName}";

            try{
                if (Directory.Exists(folderPath1))
                    Directory.Delete(folderPath1, true);
            }
            catch (Exception ex) {
            }
            try{
                if (Directory.Exists(folderPath2))
                    Directory.Delete(folderPath2, true);
            }
            catch (Exception ex) {
            }

            var batFile = $@"{filePath}Extract.bat";
            if (File.Exists(batFile))File.Delete(batFile);
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"{solutionPackagerFileName} /action:Extract /zipfile:{zipFileName1} /folder:{folderPath1}");
            sb.AppendLine($@"{solutionPackagerFileName} /action:Extract /zipfile:{zipFileName2} /folder:{folderPath2}");


            // Create a new file     
            using (FileStream fs = File.Create(batFile))
            {
                // Add some text to file    
                Byte[] title = new UTF8Encoding(true).GetBytes(sb.ToString());
                fs.Write(title, 0, title.Length);
            }
            Console.WriteLine($"Bat file created on path {batFile}");

            Process p = new Process();
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += (sender_, e_) => Console.WriteLine(e_.Data + "\n");
            p.ErrorDataReceived += (sender_, e_) => Console.WriteLine(e_.Data + "\n");
            p.Exited += (sender_, e_) => Console.WriteLine(string.Format("process exited with code {0}\n", p.ExitCode.ToString()));

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = batFile;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();            
            p.WaitForExit();

            return Tuple.Create<string, string>(folderPath1, folderPath2);
        }        
    }
}
