using System;
using System.Text;

Console.Write("Enter folder path to search: ");
string rootPath = Console.ReadLine();

Console.Write("Enter files name(for example *.cs): ");
string[] files = Directory.GetFiles(rootPath, Console.ReadLine(), SearchOption.AllDirectories);

var result = files.Select(path => new { Name = Path.GetFileName(path), Contents = File.ReadAllText(path) })
                  .Select(info => info.Name + Environment.NewLine + info.Contents);

string singleStr = string.Join(Environment.NewLine, result);

Console.Write("Enter file path for result: ");
string outputPath = Console.ReadLine();

if (File.Exists(outputPath))
    File.WriteAllText(outputPath, singleStr, Encoding.UTF8);
else
    Console.WriteLine("Error: result file not found");