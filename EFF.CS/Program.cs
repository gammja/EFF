using System;
using System.IO;
using System.Linq;


namespace EFF
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\dev\EntityFramework";

            var excluded = new[] { @"\obj\Debug", @"\bin\Debug", @"\Properties" };
            Func<string, bool> isIncluded = (name) => excluded.All(e => !name.Contains(e));
            Func<DirectoryInfo, bool> witoutFiles = (di) => !di.GetFiles().Any();
            Func<DirectoryInfo, bool> witoutSubDir = (di) => !di.GetDirectories().Any();

            var dirs = new DirectoryInfo(path)
                .GetDirectories("*", SearchOption.AllDirectories)
                .Where(witoutFiles)
                .Where(witoutSubDir)
                .Select(di => di.FullName)
                .Where(isIncluded);

            dirs.ToList().ForEach(Console.WriteLine);
        }
    }
}
