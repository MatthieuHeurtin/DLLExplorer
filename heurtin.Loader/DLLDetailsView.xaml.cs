using heurtin.Loader.Loader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace heurtin.Loader
{
    /// <summary>
    /// Interaction logic for DLLDetailsView.xaml
    /// </summary>
    public partial class DLLDetailsView : Window
    {

        public ObservableCollection<ApiDescription> DllDetails { get; set; }
        public DLLDetailsView()
        {
            InitializeComponent();

            DllDetails = new ObservableCollection<ApiDescription>();


            DataContext = this;
        }

        public void SetDllDetails(IEnumerable<ApiDescription> dllDetails)
        {
            foreach(var elt in dllDetails)
            {
                DllDetails.Add(elt);
            }
        }
    }
}
