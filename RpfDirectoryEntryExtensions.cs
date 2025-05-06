// Move the extension method `FindEntry` to a non-generic static class as required by the CS1106 diagnostic.
public static class RpfDirectoryEntryExtensions
{
    public static RpfEntry FindEntry(this RpfDirectoryEntry directory, string path)
    {
        if (directory == null || string.IsNullOrEmpty(path))
            return null;

        // Normalize the path for comparison
        string normalizedPath = path.Replace("\\", "/").ToLowerInvariant();

        // Search for a matching file entry
        if (directory.Files != null)
        {
            foreach (var file in directory.Files)
            {
                if (file.Path.ToLowerInvariant() == normalizedPath)
                {
                    return file;
                }
            }
        }

        // Search for a matching directory entry
        if (directory.Directories != null)
        {
            foreach (var subDirectory in directory.Directories)
            {
                if (subDirectory.Path.ToLowerInvariant() == normalizedPath)
                {
                    return subDirectory;
                }
            }
        }

        return null;
    }
}
