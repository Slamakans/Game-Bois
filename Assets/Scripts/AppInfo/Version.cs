using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AppInfo {
	
	[Serializable]
	public struct Version {
		public int major;
		public int minor;
		public int build;
		public Label label;
		public string formatted { get { return string.Format("{0} v{1}.{2}.{3}", label.ToString(), major, minor, build); } }

		public Version(Label label, int major, int minor, int build) {
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.label = label;
		}

		/// <summary>
		/// <para>Parse a formatted string representing a version.</para>
		/// <para>Accepted format: {LABEL} v{MAJOR}.{MINOR}.{BUILD}</para>
		/// See <see cref="AppInfo.Version.formatted"/>
		/// </summary>
		/// <exception cref="System.ArgumentException">Thrown if supplied with an empty string</exception>
		/// <exception cref="System.FormatException">Thrown if the string has an invalid format. <see cref="AppInfo.Version.formatted"/></exception>
		public static Version Parse(string s) {
			if (string.IsNullOrEmpty(s)) throw new ArgumentException("Missing value of string", "parseThis");
			s = s.Trim().ToLower();

			var match = Regex.Match(s, @"^([a-zA-Z]+) v?(\d+).(\d+).(\d+)$");
			if (!match.Success) throw new FormatException("Regex matched unsuccessfully");
			
			string grpLabel = match.Groups[1].Value;
			string grpMajor = match.Groups[2].Value;
			string grpMinor = match.Groups[3].Value;
			string grpBuild = match.Groups[4].Value;

			// Check if valid label
			List<Label> labels = new List<Label>((Label[])Enum.GetValues(typeof(Label)));
			int index = labels.FindIndex(x=>x.ToString().ToLower() == grpLabel);
			if (index == -1) throw new FormatException("Unknown label type '" + grpLabel + "'");

			// Got all values
			return new Version(
				label: labels[index],
				major: int.Parse(grpMajor),
				minor: int.Parse(grpMinor),
				build: int.Parse(grpBuild)
			);
		}

		public static bool TryParse(string s, out Version version) {
			version = new Version();
			try {
				version = Parse(s);
				return true;
			} catch {
				return false;
			}
		}
		
		public static int CompareTo(Version version, Version other) {
			if (version.label != other.label)
				return version.label > other.label ? 1 : -1;

			if (version.major != other.major)
				return version.major > other.major ? 1 : -1;

			if (version.minor != other.minor)
				return version.minor > other.minor ? 1 : -1;

			if (version.build != other.build)
				return version.build > other.build ? 1 : -1;

			return 0;
		}

		public enum Label {
			Prototype,
			Alpha,
			Beta,
			Release
		}
	}

}
