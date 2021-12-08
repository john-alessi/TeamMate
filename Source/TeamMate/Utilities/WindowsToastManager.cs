using Microsoft.Tools.TeamMate.Foundation.Diagnostics;
using Microsoft.Tools.TeamMate.Model;
using Microsoft.Tools.TeamMate.WindowsRuntime.UI.Notifications;
using System;

namespace Microsoft.Tools.TeamMate.Utilities
{
    public class WindowsToastManager : IToastManager
    {
        private ToastNotificationManager toastNotificationManager;

        public WindowsToastManager()
        {
            try
            {
                var toastNotificationManager = new ToastNotificationManager(TeamMateApplicationInfo.AppUserModelId);

                this.toastNotificationManager = toastNotificationManager;
            }
            catch (Exception ex)
            {
                Log.ErrorAndBreak("Error initializing built-in toast notification service", ex);
            }
        }

        public void Show(ToastInfo toast)
        {
            if (this.toastNotificationManager == null)
            {
                // Toast notification service was not initialized successfully, ignore any future calls
                return;
            }

            string appLogoImageUri = TeamMateApplicationInfo.ApplicationImageUri.ToString();
            this.toastNotificationManager.Show(appLogoImageUri, toast.Arguments, toast.Title, toast.Description);
        }

        public void Dispose()
        {
        }
    }
}
