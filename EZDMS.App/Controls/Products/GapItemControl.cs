using EZDMS.App.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for ProductItemControl.xaml
    /// </summary>
    public partial class GapItemControl : UserControl
    {
        public GapItemControl()
        {
            InitializeComponent();
        }

        private void CbProviders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update view model
            if (DataContext is ProductItemViewModel viewModel)
            {
                viewModel.Plans = new ObservableCollection<CoveragePlanDataModel>(
                viewModel.Plans.Where(item => item.ProviderNumber == (string)cbProviders.SelectedValue));

            }

        }
    }
}
