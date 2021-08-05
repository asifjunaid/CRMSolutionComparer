using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace CRMSolutionComparer
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "CRM Solution Comparer"),        
        ExportMetadata("Description", "Extract and compare default or custom solutions"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}