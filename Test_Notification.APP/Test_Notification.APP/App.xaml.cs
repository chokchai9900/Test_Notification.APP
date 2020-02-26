using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Plugin.DeviceInfo;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;


namespace Test_Notification.APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            OneSignal.Current.StartInit("d852feb3-ef79-403f-b8cd-ceddc02f4654")
                .HandleNotificationReceived(HandleNotificationReceived)
                .HandleNotificationOpened(HandleNotificationOpened)
                .InFocusDisplaying(OSInFocusDisplayOption.None)
                .EndInit();
        }

        private void HandleNotificationOpened(OSNotificationOpenedResult result)
        {
            DisplayNotificationMessage(result.notification);
        }

        private void HandleNotificationReceived(OSNotification notification)
        {
            DisplayNotificationMessage(notification);
        }

        private void DisplayNotificationMessage(OSNotification notification)
        {
            var hasEnpoint1 = notification.payload.additionalData.ContainsKey("endpoint1");
            var hasEnpoint2 = notification.payload.additionalData.ContainsKey("endpoint2");
            if (hasEnpoint1 && hasEnpoint2)
            {
                var enpoint1 = notification.payload?.additionalData["endpoint1"];
                var enpoint2 = notification.payload?.additionalData["endpoint2"];

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await MainPage.DisplayAlert("Additional Data 1", enpoint1.ToString(), "Ok");
                    await MainPage.DisplayAlert("Additional Data 2", enpoint2.ToString(), "Ok");
                });
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
