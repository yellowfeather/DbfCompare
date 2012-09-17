namespace DbfCompare
{
  using System;
  using System.Diagnostics;
  using System.Text;
  using System.Windows.Forms;

  using DbfCompare.DbfDiff;

  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void btnBrowse1_Click(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog { DefaultExt = "dbf", Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*" };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        txtFilePath1.Text = dialog.FileName;
      }
    }

    private void bntBrowse2_Click(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog { DefaultExt = "dbf", Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*" };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        txtFilePath2.Text = dialog.FileName;
      }
    }

    private void btnConvertCsv_Click(object sender, EventArgs e)
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      DbfConverter.ToCsv(txtFilePath1.Text);
      DbfConverter.ToCsv(txtFilePath2.Text);

      stopwatch.Stop();

      txtResults.Text = string.Format("<p>Time taken: {0}", stopwatch.Elapsed);
    }

    private void btnCompare_Click(object sender, EventArgs e)
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      var diffs = Engine.Compare(txtFilePath1.Text, txtFilePath2.Text);

      var sb = new StringBuilder();

      foreach (var diff in diffs)
      {
          sb.AppendLine(diff.ToString());
      }

      stopwatch.Stop();
      sb.AppendLine(string.Format("Time taken: {0}", stopwatch.Elapsed));

      txtResults.Text = sb.ToString();
    }
  }
}
