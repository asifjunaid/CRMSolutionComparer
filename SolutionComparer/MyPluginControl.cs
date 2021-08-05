using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using System.Collections.Specialized;
using CRMSolutionComparer.Utilities;
using Microsoft.Crm.Sdk.Messages;
using System.IO;
using System.Diagnostics;
using XrmToolBox.Extensibility.Interfaces;

namespace CRMSolutionComparer
{
    public partial class MyPluginControl : MultipleConnectionsPluginControlBase, IGitHubPlugin
    {
        private Settings mySettings;        
        private SolutionManager solManager = new SolutionManager();
        private string sourceOrgName = string.Empty;
        private string targetOrgName = string.Empty;
        private string compareToolFileLocation = string.Empty;

        public string RepositoryName => "https://github.com/asifjunaid/SolutionComparer";

        public string UserName => "asif.junaid@hotmail.com";

        public MyPluginControl()
        {
            InitializeComponent();            
            Console.SetOut(new ConsoleWriter(this.listView1));
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            ConnectionDetail.ServiceClient.OrganizationServiceProxy.Timeout = new TimeSpan(1, 0, 0);
            sourceOrgName = detail.OrganizationFriendlyName;
            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            AdditionalConnectionDetails.First().ServiceClient.OrganizationServiceProxy.Timeout = new TimeSpan(1, 0, 0);
            targetOrgName =  AdditionalConnectionDetails.First().OrganizationFriendlyName;
            btnConnectToDest.Enabled = false;
            lblDestination.Visible = true;
            lblDestination.Text = $"Target Organization Connected To {AdditionalConnectionDetails.First().ConnectionName}";
            
            Task.Run((Action)(() => {
                try
                {
                    Console.WriteLine("Fetching source solutions!");
                    var solution = solManager.RetrieveSolutions(Service);
                    sourceSolutionPicker.BeginInvoke((Action)(() => { sourceSolutionPicker.LoadSolutions(solution); }));

                    Console.WriteLine("Fetching target solutions!");
                    solution = solManager.RetrieveSolutions(AdditionalConnectionDetails.First().ServiceClient.OrganizationServiceProxy);
                    targetSolutionPicker.BeginInvoke((Action)(() => { targetSolutionPicker.LoadSolutions(solution); }));
                    Console.WriteLine("select source and target solution to compare!");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    LogError(ex.ToString());
                }
            }));

        }
        private void btnConnectToDest_Click(object sender, EventArgs e)
        {
            if (Service == null) {
                MessageBox.Show("Source organization not connected! Please connect source organization first!","Connection Error");
                return;
            }
            AddAdditionalOrganization();
        }

        private void rdSolutionBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Name == rdDefaultSolutionBtn.Name){
                sourceSolutionPicker.Enabled = false;
                targetSolutionPicker.Enabled = false;
                txtBrowseSource.Enabled = false;
                txtBrowseTarget.Enabled = false;
                btnBrowserSource.Enabled = false;
                btnBrowseTarget.Enabled = false;
                txtBrowseSource.Text = "";
                txtBrowseTarget.Text = "";
            }
            else if (radioButton.Name == rdCustomSolutionBtn.Name)
            {
                sourceSolutionPicker.Enabled = true;
                targetSolutionPicker.Enabled = true;
                txtBrowseSource.Enabled = false;
                txtBrowseTarget.Enabled = false;
                btnBrowserSource.Enabled = false;
                btnBrowseTarget.Enabled = false;
                txtBrowseSource.Text = "";
                txtBrowseTarget.Text = "";
            }
            else if (radioButton.Name == rdCompareLocalSolution.Name)
            {
                sourceSolutionPicker.Enabled = false;
                targetSolutionPicker.Enabled = false;
                txtBrowseSource.Enabled = true;
                txtBrowseTarget.Enabled = true;
                btnBrowserSource.Enabled = true;
                btnBrowseTarget.Enabled = true;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            IFileComparer fileComparer = null;
            var isDefualtSolution = rdDefaultSolutionBtn.Checked;
            var isExporedSolution = rdCompareLocalSolution.Checked;
            var isCustomSolution = rdCustomSolutionBtn.Checked;
            if (isCustomSolution && ( sourceSolutionPicker.selectedSolution == null || targetSolutionPicker.selectedSolution == null)) {
                MessageBox.Show("Please select source and target solution!","Error");
                return;
            }
            if (isExporedSolution && (txtBrowseSource.Text.Length == 0 || txtBrowseTarget.Text.Length == 0)) {
                MessageBox.Show("Please provide source and target solutiont!", "Error");
                return;
            }
            if (isDefualtSolution && (sourceOrgName?.Length==0 || targetOrgName?.Length==0))
            {
                MessageBox.Show("Please connect to soure and target organization first!", "Error");
                return;
            }
            try
            {
                fileComparer = new FileComparerManager().GetFileComparer(new List<IFileComparer>() { new WinMergeComparer() });
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                LogError(ex.ToString());
            }
            if (fileComparer == null)
            {
                MessageBox.Show("WinMerge File Difference Tool Not Found!. Please install WinMerge.", "Error");
                return;
            }
            btnCompare.Enabled = false;
            Task.Run((Action)(() => {
            try
            {
                    if (isDefualtSolution)
                    {
                        solManager.SourceSolutionName = $"DefaultSolution_{sourceOrgName}_Source";
                        solManager.TargetSolutionName = $"DefaultSolution_{targetOrgName}_Target";

                        Console.WriteLine($"Exporting source default solution!");
                        solManager.ExportSolution(Service, solManager.SourceSolutionName, Guid.Parse("FD140AAF-4DF4-11DD-BD17-0019B9312238"));
                        Console.WriteLine($"Exporting target default solution!");
                        solManager.ExportSolution(AdditionalConnectionDetails.First().ServiceClient.OrganizationServiceProxy,
                            solManager.TargetSolutionName, Guid.Parse("FD140AAF-4DF4-11DD-BD17-0019B9312238"));

                    }
                    else if (isExporedSolution) {
                        solManager.SourceSolutionName = $"{Path.GetFileNameWithoutExtension(txtBrowseSource.Text)}_Source";
                        solManager.TargetSolutionName = $"{Path.GetFileNameWithoutExtension(txtBrowseTarget.Text)}_Target";
                    }
                    else
                    {
                        var sourceSolution = sourceSolutionPicker.selectedSolution;
                        var targetSolution = targetSolutionPicker.selectedSolution;
                        solManager.SourceSolutionName = sourceSolution.GetAttributeValue<string>("uniquename") + "_Source";
                        solManager.TargetSolutionName = targetSolution.GetAttributeValue<string>("uniquename") + "_Target";

                        Console.WriteLine($"Exporting source solution {sourceSolution.GetAttributeValue<string>("uniquename")}!");
                        solManager.ExportSolution(Service, solManager.SourceSolutionName, sourceSolution.Id);
                        Console.WriteLine($"Exporting target solution {targetSolution.GetAttributeValue<string>("uniquename")}!");
                        solManager.ExportSolution(AdditionalConnectionDetails.First().ServiceClient.OrganizationServiceProxy, solManager.TargetSolutionName, targetSolution.Id);

                        btnCompare.BeginInvoke((Action)(() =>
                        {
                            btnCompare.Enabled = true;
                        }));
                    }

                    NugetPackageManager nugetPackageManager = new NugetPackageManager();
                    nugetPackageManager.DownloadPackage();

                    var folderPaths = solManager.ExtractSolution(solManager.SourceSolutionName, solManager.TargetSolutionName);
                    fileComparer.Launch(folderPaths.Item1, folderPaths.Item2);
                }
                catch (Exception ex) {
                    btnCompare.Enabled = true;
                    Console.WriteLine(ex.Message);
                    LogError(ex.ToString());
                }
            }));
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (btn.Name == btnBrowserSource.Name)
                {
                    txtBrowseSource.Text = openFileDialog1.FileName;
                    string filename = $"{Path.GetFileNameWithoutExtension(txtBrowseSource.Text)}_Source.zip";
                  
                    string filePath = System.IO.Path.GetTempPath();
                    filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";
                    Directory.CreateDirectory(filePath);

                    File.Copy(txtBrowseSource.Text, filePath + filename, true);
                }
                else
                {
                    txtBrowseTarget.Text = openFileDialog1.FileName;                    
                    string filename = $"{Path.GetFileNameWithoutExtension(txtBrowseTarget.Text)}_Target.zip";

                    string filePath = System.IO.Path.GetTempPath();
                    filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";
                    Directory.CreateDirectory(filePath);

                    File.Copy(txtBrowseTarget.Text, filePath + filename, true);
                }
            }

        }
    }
}