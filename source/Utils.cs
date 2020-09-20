using System.IO;

namespace ostranauts_modding
{
    public static class Utils
    {
        public static void CopyDirectoryAndContentsToLocation(string from, string to)
        {
            var diSource = new DirectoryInfo(from);
            var diTarget = new DirectoryInfo(to);
    
            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
    
            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                try
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name));
                }
                catch (System.Exception)
                {                   
                    
                }
            }
    
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}