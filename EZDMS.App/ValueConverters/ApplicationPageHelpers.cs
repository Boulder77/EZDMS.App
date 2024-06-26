﻿using EZDMS.App.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace EZDMS.App
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            // Find the appropriate page
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.SalesRecall:
                    return new SalesRecallPage(viewModel as SalesRecallViewModel);

                case ApplicationPage.SalesFinance:
                    return new SalesFinancePage(viewModel as SalesFinanceViewModel);

                case ApplicationPage.CustomersList:
                    return new CustomersListPage(viewModel as CustomersListViewModel);

                case ApplicationPage.VehiclesList:
                    return new VehiclesListPage(viewModel as VehiclesListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            // Find application page that matches the base page
            if (page is ChatPage)
                return ApplicationPage.Chat;

            if (page is LoginPage)
                return ApplicationPage.Login;

            if (page is RegisterPage)
                return ApplicationPage.Register;

            if (page is SalesRecallPage)
                return ApplicationPage.SalesRecall;

            if (page is SalesFinancePage)
                return ApplicationPage.SalesFinance;
            
            if (page is CustomersListPage)
                return ApplicationPage.CustomersList;

            if (page is VehiclesListPage)
                return ApplicationPage.VehiclesList;

            // Alert developer of issue
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
