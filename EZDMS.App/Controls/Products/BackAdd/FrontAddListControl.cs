using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for BackAddItemControl.xaml
    /// </summary>
    public partial class BackAddItemListControl : UserControl
    {
        public BackAddItemListControl()
        {
            InitializeComponent();

            //// Set data context to settings view model

            //// If we are in design mode...
            //if (DesignerProperties.GetIsInDesignMode(this))
            //    // Create new instance of settings view model
            //    DataContext = new FrontAddListViewModel();
            //else
            //    DataContext = FrontAddListDesignModel.Instance;



        }
    }
}
