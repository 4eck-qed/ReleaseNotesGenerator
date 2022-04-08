using System;
using System.IO;
using System.Text;

namespace ReleaseNotesGenerator
{
    /// <summary>
    /// Generates release notes so for you so you don't have to!
    /// </summary>
    public static class ReleaseNoteGenerator
    {
        /// <summary>
        /// Generates a release notes file.
        /// </summary>
        /// <param name="destination">File destination</param>
        public static void Generate(string destination)
        {
            var file = destination + "/release_notes.xml";
            var fileStream = File.Create(file);
            fileStream.Write(Encoding.UTF8.GetBytes("<ReleaseNotes>\n</ReleaseNotes>"));
            fileStream.Close();
        }

        /// <summary>
        /// Generates and appends a release note to given file.
        /// </summary>
        /// <param name="file">Release notes file</param>
        /// <param name="note">Release note</param>
        /// <param name="version">Version of this change</param>
        /// <param name="type">Type of this change</param>
        public static void AddChange(string file, string note, string version, string type)
        {
            var guid = Guid.NewGuid();
            var date = $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}";
            var changeSet = $"\t<ChangeSet guid=\"{guid}\" version=\"{version}\" date=\"{date}\">\n" +
                            $"\t\t<change type=\"{type}\">{note}</change>\n" +
                            "\t</ChangeSet>\n";

            var releaseNotes = File.ReadAllLines(file);
            var output = "";
            foreach (var line in releaseNotes)
            {
                if (line.Contains("</ReleaseNotes>")) output += changeSet;
                output += line + '\n';
            }

            File.WriteAllText(file, output);
        }
    }
}
