using System;

namespace automationpractice.com
{
    public static class Routes
    {
        public static string HomePage => "http://automationpractice.com/";
        public static string AuthenticationPage => "http://automationpractice.com/index.php?controller=authentication";
        public static string MyAccountPage => "http://automationpractice.com/index.php?controller=my-account";
        public static string SearchResultsPage => "http://automationpractice.com/index.php?controller=search";
        public static string BankWirePaymentPage => "http://automationpractice.com/index.php?fc=module&module=bankwire&controller=payment";
        public static string OrderConfirmationPage => "http://automationpractice.com/index.php?controller=order-confirmation";

    }
}
