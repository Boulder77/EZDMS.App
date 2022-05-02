using EZDMS.App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for SalesFinancePage.xaml
    /// </summary>
    public partial class SalesFinancePage : BasePage<SalesDealCardViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SalesFinancePage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public SalesFinancePage(SalesDealCardViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            //// Make sure UI exists first
            //if (ChatMessageList == null)
            //    return;

            //// Fade in chat message list
            //var storyboard = new Storyboard();
            //storyboard.AddFadeIn(1, from: true);
            //storyboard.Begin(ChatMessageList);

            //// Make the message box focused
            //MessageText.Focus();
        }

        #endregion

  
    }
}
