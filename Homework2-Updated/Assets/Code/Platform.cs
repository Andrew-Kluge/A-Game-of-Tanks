﻿using UnityEngine;

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
        public static string GetFireAxis(bool isP1) {
            if (isP1)
            {
                return GetPlatform() == PlatformType.Windows
                    ? "FireWindows"
                    : "FireMac"; // OSX/Linux bind right trigger the same way
            }
            else
            {
                return GetPlatform() == PlatformType.Windows
                    ? "FireWindows2"
                    : "FireMac2"; // OSX/Linux bind right trigger the same way
            }
            
        }
        
        /// <summary>
        /// Returns the name of the platform appropriate input axis for saving.
        /// Start/Back are mapped to Save/Load. OSX uses a different button number than Windows/Linux.
        /// </summary>
        /// <returns>Name of the "save" axis</returns>
        public static string GetSaveAxis () {
            return GetPlatform() == PlatformType.Mac ? "SaveMac" : "SaveWindows"; 
        }
    }

}