using NuGet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSolutionComparer.Utilities
{
    class NugetPackageManager
    {
        public void DownloadPackage()
        {
            //ID of the package to be looked up 
            string packageID = "Microsoft.CrmSdk.CoreTools";


            //Connect to the official package repository 
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/v1/FeedService.svc/");

            /*
            //Get the list of all NuGet packages with ID 'EntityFramework' 
            List<IPackage> packages = repo.FindPackagesById(packageID).ToList();

            //Filter the list of packages that are not Release (Stable) versions 
            packages = packages.Where(item => (item.IsReleaseVersion() == false)).ToList();
            //Iterate through the list and print the full name of the pre-release packages to console 
            foreach (IPackage p in packages)
            {
                Console.WriteLine(p.GetFullName());
            }
            */

            //Initialize the package manager string path = <PATH_TO_WHERE_THE_PACKAGES_SHOULD_BE_INSTALLED>
            //string filePath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.ToString();
            string filePath = System.IO.Path.GetTempPath();
            filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";

            string solutionPackagerFileName = Path.Combine($@"{filePath}Microsoft.CrmSdk.CoreTools.9.1.0.79\content\bin\coretools", "SolutionPackager.exe");

            if (!File.Exists(solutionPackagerFileName))
            {
                Console.WriteLine($"Downloading solution packager on path {filePath}");
                PackageManager packageManager = new PackageManager(repo, filePath);
                //Download and unzip the package 
                packageManager.InstallPackage(packageID, SemanticVersion.Parse("9.1.0.79"));
                Console.WriteLine($"Solution packager downloaded on path {filePath}");
            }
            else {
                Console.WriteLine($"Solution packager already exist on path {solutionPackagerFileName}");
            }
        }
    }
}
