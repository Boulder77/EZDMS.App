using System.ComponentModel;
using System.Windows.Controls;
using static EZDMS.App.DI;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for SalesSummaryDetails.xaml
    /// </summary>
    public partial class SalesSummaryDetails : UserControl
    {
        public SalesSummaryDetails()
        {
            InitializeComponent();

            // Set data context to settings view model

            // If we are in design mode...
            if (DesignerProperties.GetIsInDesignMode(this))
                // Create new instance of settings view model
                DataContext = new SalesSummaryDetailsViewModel();
            else
                DataContext = ViewModelSalesSummary;
        }
    }
}
