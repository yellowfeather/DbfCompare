namespace DbfCompare
{
  using System.IO;

  using SocialExplorer.IO.FastDBF;

  public class DbfConverter
  {
    public static void ToCsv(string filepath)
    {
      if (string.IsNullOrEmpty(filepath))
      {
        return;
      }

      var destination = filepath.Replace(".DBF", ".csv");

      using (Stream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
      using (TextWriter writer = new StreamWriter(destination))
      {
        var reader = new DbfReader(stream);

        while (reader.Read())
        {
          var record = reader.DbfRecord;

          for (var i = 0; i < record.ColumnCount; ++i)
          {
            writer.Write(record[i].Trim());

            if (i != record.ColumnCount - 1)
            {
              writer.Write(",");
            }
          }

          writer.WriteLine();
        }

        writer.Flush();
      }
    }
  }
}