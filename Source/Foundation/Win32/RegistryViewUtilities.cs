using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace Microsoft.Tools.TeamMate.Foundation.Win32
{
    /// <summary>
    /// Provides utility methods for manipulating the registry in 32 and 64-bit environments.
    /// </summary>
    public static class RegistryViewUtilities
    {
        /// <summary>
        /// Returns a set of all of the available Classes Root registry keys (32-bit and 64-bit if appropriate).
        /// </summary>
        public static IEnumerable<RegistryKey> OpenAllClassesRootKeys()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            return OpenBaseKeys(RegistryHive.ClassesRoot);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Returns a set of all of the available Current User registry keys (32-bit and 64-bit if appropriate).
        /// </summary>
        public static IEnumerable<RegistryKey> OpenAllCurrentUserKeys()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            return OpenBaseKeys(RegistryHive.CurrentUser);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Returns a set of all of the available Local Machine registry keys (32-bit and 64-bit if appropriate).
        /// </summary>
        public static IEnumerable<RegistryKey> OpenAllLocalMachineKeys()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            return OpenBaseKeys(RegistryHive.LocalMachine);
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Returns a set of all of the available registry keys (32-bit and 64-bit if appropriate) for a given hive.
        /// </summary>
        /// <param name="hive">The hive.</param>
        private static IEnumerable<RegistryKey> OpenBaseKeys(RegistryHive hive)
        {
            if (Environment.Is64BitProcess)
            {
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
                yield return RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CA1416 // Validate platform compatibility
            }
            else if (Environment.Is64BitOperatingSystem)
            {
#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
                yield return RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CA1416 // Validate platform compatibility
            }

#pragma warning disable CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            yield return RegistryKey.OpenBaseKey(hive, RegistryView.Registry32);
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
