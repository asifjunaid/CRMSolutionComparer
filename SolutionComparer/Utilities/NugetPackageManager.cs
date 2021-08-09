using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMSolutionComparer.Utilities
{
    class NugetPackageManager
    {
        string packageID = "Microsoft.CrmSdk.CoreTools";
        NuGetVersion version = new NuGetVersion("9.1.0.79");
        public void DownloadPackage()
        {

            //string packageID = "Microsoft.CrmSdk.CoreTools";
            //IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/v1/FeedService.svc/");

            //string filePath = System.IO.Path.GetTempPath();
            //filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";

            //string solutionPackagerFileName = Path.Combine($@"{filePath}Microsoft.CrmSdk.CoreTools.9.1.0.79\content\bin\coretools", "SolutionPackager.exe");

            //if (!File.Exists(solutionPackagerFileName))
            //{
            //    Console.WriteLine($"Downloading solution packager on path {filePath}");
            //    PackageManager packageManager = new PackageManager(repo, filePath);
            //    //Download and unzip the package 
            //    packageManager.InstallPackage(packageID, SemanticVersion.Parse("9.1.0.79"));
            //    Console.WriteLine($"Solution packager downloaded on path {filePath}");
            //}
            //else {
            //    Console.WriteLine($"Solution packager already exist on path {solutionPackagerFileName}");
            //}

            string filePath = System.IO.Path.GetTempPath();
            filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";

            string solutionPackagerFileName = Path.Combine($@"{filePath}{packageID}.{version.Version}\content\bin\coretools", "SolutionPackager.exe");

            if (!File.Exists(solutionPackagerFileName))
            {
                Console.WriteLine($"Downloading solution packager on path {filePath}");

                var task = DownloadPackageAsync();
                task.Wait();

            }
            else
            {
                Console.WriteLine($"Solution packager already exist on path {solutionPackagerFileName}");
            }

        }
        private async Task DownloadPackageAsync()
        {
            FindPackageByIdResource findPackageById;
            PackageSearchResource packageSearch;
            SourceCacheContext cache = new SourceCacheContext();
            CancellationToken cancellationToken = CancellationToken.None;
            ILogger logger = NullLogger.Instance;

            SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
            packageSearch = repository.GetResource<PackageSearchResource>();
            findPackageById = repository.GetResource<FindPackageByIdResource>();



            using (MemoryStream packageStream = new MemoryStream())
            {
                if (!await findPackageById.CopyNupkgToStreamAsync(
                     packageID,
                     version,
                     packageStream,
                     cache,
                     logger,
                     cancellationToken))
                {
                    throw new Exception($"The Nuget package for tool plugin.NugetId ({version}) has not been found");
                }

                string filePath = System.IO.Path.GetTempPath();
                filePath += "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\\";

                var packageFolder = Path.Combine(filePath, $"{packageID}.{version.Version}");

                using (PackageArchiveReader packageReader = new PackageArchiveReader(packageStream))
                {
                    foreach (var packageFile in await packageReader.GetFilesAsync(cancellationToken))
                    {

                        if (!Directory.Exists(packageFolder))
                        {
                            Directory.CreateDirectory(packageFolder);
                        }

                        var relativeFilePath = packageFile;
                        var filePath_ = Path.Combine(packageFolder, relativeFilePath);
                        var fi = new FileInfo(filePath_);

                        if (!Directory.Exists(fi.Directory.FullName))
                        {
                            Directory.CreateDirectory(fi.Directory.FullName);
                        }

                        using (var fileStream = File.OpenWrite(filePath_))
                        using (var stream = await packageReader.GetStreamAsync(packageFile, cancellationToken))
                        {
                            await stream.CopyToAsync(fileStream);
                        }


                    }
                }
                Console.WriteLine($"Solution packager downloaded.");
            }

           
        }
    }
}
