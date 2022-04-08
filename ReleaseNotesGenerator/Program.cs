namespace ReleaseNotesGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string outPath = "../../../out";
            ReleaseNoteGenerator.Generate(outPath);
            ReleaseNoteGenerator.AddChange(outPath + "/release_notes.xml", "just another test", "123", "test");
        }
    }
}
