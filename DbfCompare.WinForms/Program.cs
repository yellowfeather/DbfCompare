// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.WinForms
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// The program.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }
}
