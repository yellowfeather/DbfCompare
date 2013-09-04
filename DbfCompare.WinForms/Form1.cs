// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.WinForms
{
  using System;
  using System.Diagnostics;
  using System.Text;
  using System.Windows.Forms;

  using DbfCompare.Core;
  using DbfCompare.Core.DbfDiff;

  /// <summary>
  /// The form.
  /// </summary>
  public partial class Form1 : Form
  {
    /// <summary>
    /// Initialises a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
      this.InitializeComponent();
    }

    private void btnBrowse1_Click(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog { DefaultExt = "dbf", Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*" };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        this.txtFilePath1.Text = dialog.FileName;
      }
    }

    private void bntBrowse2_Click(object sender, EventArgs e)
    {
      var dialog = new OpenFileDialog { DefaultExt = "dbf", Filter = "DBF files (*.dbf)|*.dbf|All files (*.*)|*.*" };

      if (dialog.ShowDialog() == DialogResult.OK)
      {
        this.txtFilePath2.Text = dialog.FileName;
      }
    }

    private void btnConvertCsv_Click(object sender, EventArgs e)
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      DbfConverter.ToCsv(this.txtFilePath1.Text);
      DbfConverter.ToCsv(this.txtFilePath2.Text);

      stopwatch.Stop();

      this.txtResults.Text = string.Format("<p>Time taken: {0}", stopwatch.Elapsed);
    }

    private void btnCompare_Click(object sender, EventArgs e)
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      var diffs = Engine.Compare(this.txtFilePath1.Text, this.txtFilePath2.Text);

      var sb = new StringBuilder();

      foreach (var diff in diffs)
      {
          sb.AppendLine(diff.ToString());
      }

      stopwatch.Stop();
      sb.AppendLine(string.Format("Time taken: {0}", stopwatch.Elapsed));

      this.txtResults.Text = sb.ToString();
    }
  }
}
