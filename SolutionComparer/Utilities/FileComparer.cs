using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSolutionComparer.Utilities
{
    public interface IFileComparer {
        string ProgramDisplayName { get; }
        bool IsInstalled  { get;set; }
        string InstallLocation { get; set; }
        void Launch(string sourcePath, string targetPath);        
    }    
    public class WinMergeComparer : IFileComparer
    {
        public bool isInstalled = false;
        public string installLocation = string.Empty;
        public string ProgramDisplayName { get => "WinMerge"; }
        public bool IsInstalled { get => isInstalled; set => isInstalled = value; }
        public string InstallLocation { get => installLocation; set => installLocation = value; }

        

        public void Launch(string sourcePath, string targetPath)
        {
            Process winMergeProcess = new Process();

            winMergeProcess.StartInfo.UseShellExecute = false;
            winMergeProcess.StartInfo.FileName = $@"{installLocation}\WinMergeU.exe";
            winMergeProcess.StartInfo.Arguments = $@"/r {sourcePath} {targetPath}";
            winMergeProcess.Start();
        }
    }
    public class FileComparerManager
    {
        public IFileComparer GetFileComparer(List<IFileComparer> fileComparers)
        {
            
            foreach (var comparer in fileComparers)
            {
                Console.WriteLine(string.Format("Checking install status of: {0}", comparer.ProgramDisplayName));
                var isInstalled = IsProgramInstalled(comparer.ProgramDisplayName, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (isInstalled.Item1 == false) {
                    isInstalled =  IsProgramInstalled(comparer.ProgramDisplayName, "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                }
                if (isInstalled.Item1 == true) {
                    comparer.IsInstalled = true;
                    comparer.InstallLocation = isInstalled.Item2;
                    return comparer;
                }
            }
            return null;
        }
        private Tuple<bool, string> IsProgramInstalled(string programDisplayName, string registry)
        {
            
            var subKeys = Registry.LocalMachine.OpenSubKey(registry);
            if (subKeys != null)
                foreach (var item in subKeys.GetSubKeyNames())
                {

                    object programName = Registry.LocalMachine.OpenSubKey(registry + "\\" + item).GetValue("DisplayName");

                    if (programName?.ToString().IndexOf(programDisplayName) > -1)
                    {
                        Console.WriteLine("Install status: INSTALLED");
                        return Tuple.Create<bool, string>(true, Registry.LocalMachine.OpenSubKey(registry + "\\" + item).GetValue("InstallLocation")?.ToString());
                    }
                }
            return Tuple.Create<bool, string>(false, null);
        }
    }
}
