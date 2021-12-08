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
            new ToastContentBuilder()
                .AddArgument("launch", launchArgs)
                .AddHeroImage(new System.Uri(appLogImageUri))
                .AddText(lineOneText)
                .AddText(lineTwoText)
                .Show();
        }
    }
};