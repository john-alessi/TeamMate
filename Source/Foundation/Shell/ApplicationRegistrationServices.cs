using Microsoft.Tools.TeamMate.Foundation.Diagnostics;
using Microsoft.Win32;
using System;

namespace Microsoft.Tools.TeamMate.Foundation.Shell
{
    /// <summary>
    /// Helper class for dealing with Windows Application Registration
    /// </summary>
    public static class ApplicationRegistrationServices
    {
        /// <summary>
        /// Register the specified application in the registry
        /// </summary>
        /// <param name="appName">Application name</param>
        /// <param name="registryPath">Registry path (relative to HKLM\Software)</param>
        /// <param name="appExeLocation">Application exe location</param>
        /// <param name="description">Application description</param>
        /// <param name="fileTypes">File extensions to register for this app (e.g. ".txt")</param>
        public static void RegisterApplication(string appName, string registryPath, string appExeLocation, string description, params FileTypeRegistration[] fileTypes)
        {
            Assert.ParamIsNotNullOrEmpty(appName, "appName");
            Assert.ParamIsNotNullOrEmpty(registryPath, "registryPath");
            Assert.ParamIsNotNullOrEmpty(appExeLocation, "appExeLocation");

#pragma warning disable CA1416 // Validate platform compatibility
            RegistryKey currentUser = Registry.CurrentUser;
#pragma warning restore CA1416 // Validate platform compatibility

            // Register with Default Programs
            string capabilitiesRegPath = string.Format(@"SOFTWARE\{0}\Capabilities", registryPath);
#pragma warning disable CA1416 // Validate platform compatibility
            using (RegistryKey capabilities = currentUser.CreateSubKey(capabilitiesRegPath))
#pragma warning restore CA1416 // Validate platform compatibility
            {
#pragma warning disable CA1416 // Validate platform compatibility
                capabilities.SetValue("ApplicationName", appName);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
                capabilities.SetValue("ApplicationDescription", description);
#pragma warning restore CA1416 // Validate platform compatibility

                if (fileTypes.Length > 0)
                {
#pragma warning disable CA1416 // Validate platform compatibility
                    using (RegistryKey fileAssociationsKey = capabilities.CreateSubKey("FileAssociations"))
#pragma warning restore CA1416 // Validate platform compatibility
                    {
                        foreach (FileTypeRegistration fileType in fileTypes)
                        {
                            string progId = CreateProgId(appName, fileType);
#pragma warning disable CA1416 // Validate platform compatibility
                            fileAssociationsKey.SetValue(fileType.Extension, progId);
#pragma warning restore CA1416 // Validate platform compatibility
                        }
                    }
                }
            }

#pragma warning disable CA1416 // Validate platform compatibility
            using (RegistryKey registeredApplicationsKey = currentUser.OpenSubKey(@"SOFTWARE\RegisteredApplications", true))
#pragma warning restore CA1416 // Validate platform compatibility
            {
#pragma warning disable CA1416 // Validate platform compatibility
                registeredApplicationsKey.SetValue(appName, capabilitiesRegPath);
#pragma warning restore CA1416 // Validate platform compatibility
            }

            // Register ProgIDs
            foreach (FileTypeRegistration fileType in fileTypes)
            {
                string progId = CreateProgId(appName, fileType);
                string regPath = string.Format(@"SOFTWARE\Classes\{0}", progId);
#pragma warning disable CA1416 // Validate platform compatibility
                using (RegistryKey extKey = currentUser.CreateSubKey(regPath))
#pragma warning restore CA1416 // Validate platform compatibility
                {
                    if (!String.IsNullOrEmpty(fileType.Description))
                    {
#pragma warning disable CA1416 // Validate platform compatibility
                        extKey.SetValue(null, fileType.Description);
#pragma warning restore CA1416 // Validate platform compatibility
                    }

#pragma warning disable CA1416 // Validate platform compatibility
                    using (RegistryKey iconKey = extKey.CreateSubKey("DefaultIcon"))
#pragma warning restore CA1416 // Validate platform compatibility
                    {
#pragma warning disable CA1416 // Validate platform compatibility
                        iconKey.SetValue(null, appExeLocation);
#pragma warning restore CA1416 // Validate platform compatibility
                    }

#pragma warning disable CA1416 // Validate platform compatibility
                    using (RegistryKey commandKey = extKey.CreateSubKey(@"shell\open\command"))
#pragma warning restore CA1416 // Validate platform compatibility
                    {
#pragma warning disable CA1416 // Validate platform compatibility
                        commandKey.SetValue(null, string.Format("\"{0}\" \"%1\"", appExeLocation));
#pragma warning restore CA1416 // Validate platform compatibility
                    }
                }

                string fileExtensionKeyPath = string.Format(@"SOFTWARE\Classes\{0}\OpenWithProgids", fileType.Extension);
#pragma warning disable CA1416 // Validate platform compatibility
                using (RegistryKey fileExtensionKey = currentUser.CreateSubKey(fileExtensionKeyPath))
#pragma warning restore CA1416 // Validate platform compatibility
                {
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
                    fileExtensionKey.SetValue(progId, new byte[0], RegistryValueKind.Binary);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CA1416 // Validate platform compatibility
                }
            }
        }

        /// <summary>
        /// Creates the ProgId for a given application and file type..
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <returns>A prog id.</returns>
        private static string CreateProgId(string appName, FileTypeRegistration fileType)
        {
            string progId = String.Format("{0}{1}", appName, fileType.Extension);
            return progId;
        }

        /// <summary>
        /// Unegisters an application from the registry.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="registryPath">The registry path.</param>
        /// <param name="fileExtensions">The file extensions associated with that application.</param>
        public static void UnegisterApplication(string appName, string registryPath, params string[] fileExtensions)
        {
            Assert.ParamIsNotNull(appName, "appName");
            Assert.ParamIsNotNull(registryPath, "registryPath");

#pragma warning disable CA1416 // Validate platform compatibility
            RegistryKey currentUser = Registry.CurrentUser;
#pragma warning restore CA1416 // Validate platform compatibility
            string capabilitiesRegPath = string.Format(@"SOFTWARE\{0}\Capabilities", registryPath);
#pragma warning disable CA1416 // Validate platform compatibility
            currentUser.DeleteSubKeyTree(capabilitiesRegPath, false);
#pragma warning restore CA1416 // Validate platform compatibility

#pragma warning disable CA1416 // Validate platform compatibility
            using (RegistryKey registeredApplicationsKey = currentUser.OpenSubKey(@"SOFTWARE\RegisteredApplications", true))
#pragma warning restore CA1416 // Validate platform compatibility
            {
#pragma warning disable CA1416 // Validate platform compatibility
                registeredApplicationsKey.DeleteValue(appName, false);
#pragma warning restore CA1416 // Validate platform compatibility
            }

            foreach (string fileExtension in fileExtensions)
            {
                string progId = String.Format("{0}{1}", appName, fileExtension);
                string regPath = string.Format(@"SOFTWARE\Classes\{0}", progId);
#pragma warning disable CA1416 // Validate platform compatibility
                currentUser.DeleteSubKeyTree(regPath, false);
#pragma warning restore CA1416 // Validate platform compatibility

                string fileExtensionKeyPath = string.Format(@"SOFTWARE\Classes\{0}", fileExtension);
#pragma warning disable CA1416 // Validate platform compatibility
                currentUser.DeleteSubKeyTree(fileExtensionKeyPath, false);
#pragma warning restore CA1416 // Validate platform compatibility
            }
        }

        /// <summary>
        /// Sets whether a given application should run on startup.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="commandLine">The command line.</param>
        /// <param name="runOnStartup">if set to <c>true</c>, configures the application to run on startup. Otherwise, removes it from running on startup..</param>
        public static void SetRunOnStartup(string appName, string commandLine, bool runOnStartup = true)
        {
            Assert.ParamIsNotNull(appName, "appName");
            Assert.ParamIsNotNull(commandLine, "commandLine");

#pragma warning disable CA1416 // Validate platform compatibility
            RegistryKey currentUser = Registry.CurrentUser;
#pragma warning restore CA1416 // Validate platform compatibility
            if (runOnStartup)
            {
#pragma warning disable CA1416 // Validate platform compatibility
                using (RegistryKey runKey = currentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"))
#pragma warning restore CA1416 // Validate platform compatibility
                {
#pragma warning disable CA1416 // Validate platform compatibility
                    runKey.SetValue(appName, commandLine);
#pragma warning restore CA1416 // Validate platform compatibility
                }
            }
            else
            {
#pragma warning disable CA1416 // Validate platform compatibility
                using (RegistryKey runKey = currentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
#pragma warning restore CA1416 // Validate platform compatibility
                {
                    if (runKey != null)
                    {
#pragma warning disable CA1416 // Validate platform compatibility
                        runKey.DeleteValue(appName, false);
#pragma warning restore CA1416 // Validate platform compatibility
                    }
                }
            }
        }
    }

    /// <summary>
    /// Provides the registration information for a file type.
    /// </summary>
    public class FileTypeRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileTypeRegistration"/> class.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <param name="description">An optional description.</param>
        public FileTypeRegistration(string extension, string description = null)
        {
            Assert.ParamIsNotNullOrEmpty(extension, "extension");

            this.Extension = extension;
            this.Description = description;
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Gets an optional description.
        /// </summary>
        public string Description { get; private set; }
    }
}
