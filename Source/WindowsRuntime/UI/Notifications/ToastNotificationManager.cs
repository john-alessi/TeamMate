using Microsoft.Toolkit.Uwp.Notifications;

namespace Microsoft.Tools.TeamMate.WindowsRuntime.UI.Notifications
{
    public class ToastNotificationManager
    {
        private string applicationId;

        public ToastNotificationManager(string applicationId)
        {
            this.applicationId = applicationId;
        }

        public void Show(string appLogImageUri, string launchArgs, string lineOneText, string lineTwoText)
        {
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            new ToastContentBuilder()
#pragma warning restore CA1416 // Validate platform compatibility
                .AddArgument("launch", launchArgs)
#pragma warning restore CA1416 // Validate platform compatibility
                .AddHeroImage(new System.Uri(appLogImageUri))
#pragma warning restore CA1416 // Validate platform compatibility
                .AddText(lineOneText)
#pragma warning restore CA1416 // Validate platform compatibility
                .AddText(lineTwoText)
                .Show();
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
};