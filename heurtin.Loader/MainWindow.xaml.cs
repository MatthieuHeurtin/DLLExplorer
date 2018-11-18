using heurtin.Loader.Command;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using heurtin.Loader.ViewModel;
using heurtin.Loader.Loader;
using System;
using System.Collections.ObjectModel;

namespace heurtin.Loader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region command
        public ICommand _browseCommand;

        public ICommand BrowseCommand
        {
            get
            {
                return _browseCommand ?? (_browseCommand = new BrowseCommand(() => BrowseFolder(), true));
            }
        }

        public void BrowseFolder()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    BrowsewViewModelPath.Path = dialog.SelectedPath;
                }
            }
        }


        private ICommand _parseCommand;
        public ICommand ParseCommand
        {
            get { return _parseCommand ?? (_parseCommand = new ParseCommand((x) => _parser.Parse(BrowsewViewModelPath.Path), true)); }
        }

                                   


        private ICommand _analyseDllCommand;
        public ICommand AnalyseDllCommand
        {
            get { return _analyseDllCommand ?? (_analyseDllCommand = new AnalyseDllCommand((x) => _dllAnalyser.Analyse(x), true)); }
        }
        #endregion

        #region viewModels
        public BrowsewViewModel BrowsewViewModelPath { get; set; }
        public ObservableCollection<DLLProperties> DllProperties{ get; set; }
        #endregion



        #region dependencies
        private IDllParser _parser;
        private IDllAnalyser _dllAnalyser;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            

            BrowsewViewModelPath = new BrowsewViewModel();
            
            DllProperties = new ObservableCollection<DLLProperties>();

            _parser = new DllParser();
            _parser.DllParserEvent += UpdateDllListViewModel;

            _dllAnalyser = new DllAnalyser();
            _dllAnalyser.AnalyseTerminated += ShowDllDetails;




            DataContext = this;


        }

        private void ShowDllDetails(object sender, DLLAnalyseEventParam e)
        {
           var view =  new DLLDetailsView();
           view.SetDllDetails(e.parap);
           view.ShowDialog();
        }

        private void UpdateDllListViewModel(object sender, DllParserEventParam e)
        {
            foreach(var y in e.parap)
            {
                DllProperties.Add(y);
            }

        }


        private void SeeDllDetails_Click( object sender, RoutedEventArgs e)
        {
            AnalyseDllCommand.Execute((sender as System.Windows.Controls.Button).Tag);
        }
    }
}
