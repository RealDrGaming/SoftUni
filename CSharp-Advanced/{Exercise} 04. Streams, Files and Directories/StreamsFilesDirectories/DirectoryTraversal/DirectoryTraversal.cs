namespace DirectoryTraversal;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string reportFileName = @"\report.txt";

        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);

        WriteReportToDesktop(reportContent, reportFileName);
    }

    public static string TraverseDirectory(string inputFolderPath)
    {
        SortedDictionary<string, List<FileInfo>> files = new ();

        string[] fileNames = Directory.GetFiles(inputFolderPath);

        foreach (var fileName in fileNames)
        {
            FileInfo fileInfo = new(fileName);

            if (!files.ContainsKey(fileInfo.Extension)) 
            {
                files.Add(fileInfo.Extension, new List<FileInfo>());
            }

            files[fileInfo.Extension].Add(fileInfo);
        }

        StringBuilder sb = new();

        foreach (var extensionFiles in files.OrderByDescending(ef => ef.Value.Count))
        {
            sb.AppendLine(extensionFiles.Key);

            foreach (var file in extensionFiles.Value.OrderBy(f => f.Length))
            {
                sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024}kb");
            }
        }

        return sb.ToString();
    }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
        File.WriteAllText(filePath, textContent);
    }
}
