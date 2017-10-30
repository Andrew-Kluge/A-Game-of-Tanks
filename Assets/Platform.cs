using UnityEngine;

namespace Assets.Code
{
    /// <summary>
    /// Represents a what platform (e.g. OS) we're running on
    /// </summary>
    public enum PlatformType
    {
        Windows,
        Mac,
        Linux,
    }

    /// <summary>
    /// Utilities for determining what platform (e.g. Mac vs Windows) we're running on.
    /// Determining the controller "axis" bindings for the particular platform we're on.
    /// This lets the rest of the game ignore whether we're running on Max or Windows.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Determine what platform we're presently running on.
        /// </summary>
        /// <returns>What platform we're running on</returns>
        public static PlatformType GetPlatform () {
            // TODO fill me in
            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer)
            {
                //Debug.Log("Win");
                return PlatformType.Windows;
            }
            else if (Application.platform == RuntimePlatform.OSXEditor ||
                     Application.platform == RuntimePlatform.OSXPlayer)
            {
                //Debug.Log("Mac");
                return PlatformType.Mac;
            }
            else
            {
                return PlatformType.Linux;
            }
             // not necessarily true
        }

        /// <summary>
        /// Returns the name of the platform appropriate input axis for firing.
        /// Windows has a different binding for the right trigger than OSX/Linux.
        /// </summary>
        /// <returns>Name of the "fire" axis</returns>
        public static string GetFireAxis() {
            return GetPlatform() == PlatformType.Windows ? "Fire1Win" : "Fire1Mac"; // OSX/Linux bind right trigger the same way
        }

        public static string GetFireAxis2()
        {
            return GetPlatform() == PlatformType.Windows ? "Fire2Win" : "Fire2Mac"; // OSX/Linux bind right trigger the same way
        }

    }

}