using System;
using NuGet.Versioning;

namespace NVM
{
    public static class VersionParser
    {
        public static Version Parse(string rawVersion)
        {
            rawVersion = CleanRawVersion(rawVersion);
            var version = FloatRange.Parse(rawVersion);
            if (version is null)
            {
                throw new ArgumentException($"Unable to parse version: {rawVersion}");
            }

            return new Version(version.ToString());
        }

        public static Version StrictParse(string rawVersion)
        {
            rawVersion = CleanRawVersion(rawVersion);
            try
            {
                return new Version(rawVersion);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Unable to parse version: {rawVersion}");
            }
        }

        private static string CleanRawVersion(string rawVersion)
        {
            if (rawVersion[0].ToString().ToLower() == "v")
            {
                rawVersion = rawVersion[1..];
            }

            return rawVersion;
        }
    }
}