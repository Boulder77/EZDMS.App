using System.Windows.Controls;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for DialogCustomerSelect.xaml
    /// </summary>
    public partial class DialogCustomerSelect : BaseDialogUserControl
    {
        public DialogCustomerSelect()
        {
            InitializeComponent();
                       
        }

        public DialogCustomerSelect(CustomersListViewModel specificViewModel)
        {
            InitializeComponent();



        }
    }
}
