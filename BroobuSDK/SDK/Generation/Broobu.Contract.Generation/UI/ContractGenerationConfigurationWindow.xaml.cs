using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Iris.Contract.Generation.Domain;

namespace Iris.Contract.Generation.UI
{
    /// <summary>
    /// Interaction logic for AgentInterfaceGenerationSettings.xaml
    /// </summary>
    public partial class ContractGenerationConfigurationWindow : Window, INotifyPropertyChanged
    {
        private DirectoryInfo _WorkingDirectory;
        private ContractDefinition _Settings;
        private FileInfo _ConfigurationFile;
        private String ConfigurationFileLocation { get { return Path.Combine(_WorkingDirectory.FullName, ContractDefinition.RelativeConfigurationFileLocation); } }

        public DirectoryInfo WorkingDirectory
        {
            get { return _WorkingDirectory; }
            set
            {
                if (_WorkingDirectory == value)
                    return;

                _WorkingDirectory = value;
                if (_WorkingDirectory.Exists)
                    ConfigurationFile = new FileInfo(ConfigurationFileLocation);
                OnPropertyChanged("WorkingDirectory");
            }
        }
        public ContractDefinition Settings
        {
            get { return _Settings; }
            set
            {
                if (_Settings == value)
                    return;

                _Settings = value;
                OnPropertyChanged("Settings");
            }
        }
        public FileInfo ConfigurationFile
        {
            get { return _ConfigurationFile; }
            set
            {
                if (value == _ConfigurationFile) return;
                _ConfigurationFile = value;
                if (_ConfigurationFile.Exists)
                    Settings = ContractDefinition.LoadFromFile(_ConfigurationFile.FullName);
                OnPropertyChanged("ConfigurationFile");
            }
        }

        private ContractGenerationConfigurationWindow()
        {
            Settings = new ContractDefinition();
        }

        public ContractGenerationConfigurationWindow(DirectoryInfo workingDirectory)
            :this()
        {
            InitializeComponent();
            WorkingDirectory = workingDirectory;
        }

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.DialogResult = true;
            //Iris.Contract.Generation.Templates.ConfigTemplate configTemplate = new Templates.ConfigTemplate(Settings);
            //configTemplate.RenderToFile(Path.Combine(WorkingDirectory.FullName,ContractGenerationConfiguration.RelativeConfigurationFileLocation));
            //Settings.SaveToFile(ConfigurationFileLocation);
            this.Close();

        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Settings = ContractDefinition.LoadFromFile(ConfigurationFile.FullName);
        }


        private void TemplateConfigurationWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!DialogResult.HasValue || !DialogResult.Value)
                e.Cancel = true;
        }
    }
}
