// <copyright file="Generator1.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using System;
using System.IO;
using System.Windows.Forms;
using Iris.Contract.Generation.Domain;
using T4Toolbox;

namespace Iris.Contract.Generation.Generators
{

    public class BaseGenerator : Generator
    {
        protected ContractDefinition _Configuration;
        private DirectoryInfo _WorkingDirectory;
        private FileInfo _ConfigurationFile;

        public DirectoryInfo WorkingDirectory
        {
            get { return _WorkingDirectory; }
            set
            {
                _WorkingDirectory = value;
                ConfigurationFile = new FileInfo(Path.Combine(_WorkingDirectory.FullName, ContractDefinition.RelativeConfigurationFileLocation));
            }
        }
        public FileInfo ConfigurationFile
        {
            get { return _ConfigurationFile; }
            set { _ConfigurationFile = value; }
        }

        public BaseGenerator()
            : base()
        {
            //AppDomain currentdomain = AppDomain.CurrentDomain;
            //currentdomain.AssemblyResolve += new ResolveEventHandler(Iris.Common.RunTimeCompiler.AssemblyHelper.ResolveAssembly);
        }

        protected override void RunCore()
        {
            throw new NotImplementedException();
        }

        protected internal bool LoadConfiguration()
        {
            if (ConfigurationFile.Exists)
            {
                _Configuration = ContractDefinition.LoadFromFile(ConfigurationFile.FullName);
            }
            else
            {
                MessageBox.Show(String.Format("Please create the configuration file on following location or add the template again and modify the file (location: {0})", ConfigurationFile));
            }
            //if (_Configuration == null)
            //{
            //    ContractGenerationConfigurationWindow mainWindow = new ContractGenerationConfigurationWindow(WorkingDirectory);
            //    var result = mainWindow.ShowDialog();
            //    if (result.HasValue && result.Value)
            //        _Configuration = mainWindow.Settings;
            //}
           return _Configuration != null;
        }

        protected override void Validate()
        {
            this.Warning("Generator properties have not been validated");
        }
    }
}
