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
                //.HandleInAppMessageClicked(HandleInAppMessageClicked)
                .InFocusDisplaying(OSInFocusDisplayOption.None)
                .EndInit();

            //OneSignal.Current.StartInit("d852feb3-ef79-403f-b8cd-ceddc02f4654")
            //    .EndInit();
        }

        private void HandleInAppMessageClicked(OSInAppMessageAction action)
        {

        }

        private void HandleNotificationOpened(OSNotificationOpenedResult result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await MainPage.DisplayAlert("Additional Data 1", "test", "Ok");
            });
            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await MainPage.DisplayAlert("Additional Data 1", result.notification.payload.additionalData["endpoint1"].ToString(), "Ok");
            //        await MainPage.DisplayAlert("Additional Data 2", result.notification.payload.additionalData["endpoint2"].ToString(), "Ok");
            //    });
        }

        private void HandleNotificationReceived(OSNotification notification)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await MainPage.DisplayAlert("Additional Data 1", "test", "Ok");
            });

            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await MainPage.DisplayAlert("Additional Data 1", notification.payload.additionalData["endpoint1"].ToString(), "Ok");
            //    await MainPage.DisplayAlert("Additional Data 2", notification.payload.additionalData["endpoint2"].ToString(), "Ok");
            //});
            //Debug.WriteLine("##### Noti ######");
            //Debug.WriteLine(notification.payload.additionalData["endpoint"].ToString());
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
