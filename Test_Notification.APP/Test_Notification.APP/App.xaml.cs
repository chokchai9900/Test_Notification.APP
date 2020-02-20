using Com.OneSignal;
using Com.OneSignal.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                .EndInit();

            GetPlayerId();

        }

        private async void GetPlayerId()
        {
            var playerId = await OneSignal.Current.IdsAvailableAsync();
        }

        private async void HandleNotificationReceived(OSNotification notification)
        {
            await MainPage.DisplayAlert("Additional Data ", notification.payload.additionalData["endpoint"].ToString(), "Ok");
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
