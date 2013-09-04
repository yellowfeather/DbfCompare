// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare
{
    using System;
    using System.IO;

  using DbfCompare.Core;
  using DbfCompare.Core.DbfDiff;

  /// <summary>
  /// The program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// The main entry point.
    /// </summary>
    public static void Main()
    {
        var commandLine = new CommandLine();
        var help = commandLine.GetArgument("help");
        if (help != null)
        {
            ShowUsage();
            return;
        }

      try
      {
          var oldFilepath = commandLine.GetArgument("old");
          var newFilepath = commandLine.GetArgument("new");
          var diffFilepath = commandLine.GetArgument("diff");

          if (!string.IsNullOrEmpty(oldFilepath) && 
              !string.IsNullOrEmpty(newFilepath) &&
              !string.IsNullOrEmpty(diffFilepath))
          {
              if (!File.Exists(oldFilepath))
              {
                  Console.WriteLine("Error: old file does not exist");
                  return;
              }

              if (!File.Exists(newFilepath))
              {
                  Console.WriteLine("Error: new file does not exist");
                  return;
              }

              Compare(oldFilepath, newFilepath, diffFilepath);
              return;
          }

          var dbfFilepath = commandLine.GetArgument("dbf");
          var csvFilepath = commandLine.GetArgument("csv");

          if (!string.IsNullOrEmpty(dbfFilepath) &&
              !string.IsNullOrEmpty(csvFilepath))
          {
              if (!File.Exists(dbfFilepath))
              {
                  Console.WriteLine("Error: dbf file does not exist");
                  return;
              }

              Convert(dbfFilepath, csvFilepath);
              return;
          }


          Console.WriteLine("Error: src argument not supplied");
          ShowUsage();
      }
      catch (Exception e)
      {
          Console.WriteLine("Exception: " + e);
      }

    }

    /// <summary>
    /// Shows the usage.
    /// </summary>
    private static void ShowUsage()
    {
        Console.WriteLine("Compares or converts DBF files.");
        Console.WriteLine("Usage:");
        Console.WriteLine(" -old   The path to the older DBF file");
        Console.WriteLine(" -new   The path to the newer DBF file");
        Console.WriteLine(" -diff  The path to the file to write the difference to (JSON format)");
        Console.WriteLine(" -dbf   The path to the DBF file to convert to CSV");
        Console.WriteLine(" -csv   The path to the file to write the converted file to");
        Console.WriteLine(" -help  Display this help message");
        Console.WriteLine(" e.g.      DbfCompare -old:\"E:\\Data\\old\\fusages.dbf\" -new:\"E:\\Data\\new\\fusages.dbf\" -diff:\"E:\\Data\\fusages-comparison.json\" ");
        Console.WriteLine("           DbfCompare -dbf:\"E:\\Data\\old\\fusages.dbf\" -csv:\"E:\\Data\\new\\fusages.csv\" ");
    }

      /// <summary>
      /// The convert.
      /// </summary>
      /// <param name="dbfFilepath">
      /// The path to the DBF file to convert.
      /// </param>
      /// <param name="csvFilepath">
      /// The path to the CSV file to write to.
      /// </param>
      private static void Convert(string dbfFilepath, string csvFilepath)
    {
        DbfConverter.ToCsv(dbfFilepath);
    }

    /// <summary>
    /// The compare.
    /// </summary>
    /// <param name="oldFilepath">
    /// The path to the old file.
    /// </param>
    /// <param name="newFilepath">
    /// The path to the new file.
    /// </param>
    /// <param name="outputFilepath">
    /// The path to write the output.
    /// </param>
    private static void Compare(string oldFilepath, string newFilepath, string outputFilepath)
    {
      var diffs = Engine.Compare(oldFilepath, newFilepath);

      using (TextWriter writer = new StreamWriter(outputFilepath))
      {
        foreach (var diff in diffs)
        {
          writer.WriteLine(diff.ToString());
        }
      }
    }
  }
}
