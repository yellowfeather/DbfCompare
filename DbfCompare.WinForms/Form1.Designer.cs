namespace DbfCompare.WinForms
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.txtFilePath1 = new System.Windows.Forms.TextBox();
            this.txtFilePath2 = new System.Windows.Forms.TextBox();
            this.bntBrowse2 = new System.Windows.Forms.Button();
            this.btnConvertCsv = new System.Windows.Forms.Button();
            this.btnFastCompare = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse1.Location = new System.Drawing.Point(456, 13);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse1.TabIndex = 0;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // txtFilePath1
            // 
            this.txtFilePath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath1.Location = new System.Drawing.Point(13, 15);
            this.txtFilePath1.Name = "txtFilePath1";
            this.txtFilePath1.Size = new System.Drawing.Size(437, 20);
            this.txtFilePath1.TabIndex = 1;
            // 
            // txtFilePath2
            // 
            this.txtFilePath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath2.Location = new System.Drawing.Point(12, 41);
            this.txtFilePath2.Name = "txtFilePath2";
            this.txtFilePath2.Size = new System.Drawing.Size(437, 20);
            this.txtFilePath2.TabIndex = 3;
            // 
            // bntBrowse2
            // 
            this.bntBrowse2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntBrowse2.Location = new System.Drawing.Point(455, 39);
            this.bntBrowse2.Name = "bntBrowse2";
            this.bntBrowse2.Size = new System.Drawing.Size(75, 23);
            this.bntBrowse2.TabIndex = 2;
            this.bntBrowse2.Text = "Browse";
            this.bntBrowse2.UseVisualStyleBackColor = true;
            this.bntBrowse2.Click += new System.EventHandler(this.bntBrowse2_Click);
            // 
            // btnConvertCsv
            // 
            this.btnConvertCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertCsv.AutoSize = true;
            this.btnConvertCsv.Location = new System.Drawing.Point(10, 68);
            this.btnConvertCsv.Name = "btnConvertCsv";
            this.btnConvertCsv.Size = new System.Drawing.Size(78, 23);
            this.btnConvertCsv.TabIndex = 8;
            this.btnConvertCsv.Text = "Convert CSV";
            this.btnConvertCsv.UseVisualStyleBackColor = true;
            this.btnConvertCsv.Click += new System.EventHandler(this.btnConvertCsv_Click);
            // 
            // btnFastCompare
            // 
            this.btnFastCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFastCompare.AutoSize = true;
            this.btnFastCompare.Location = new System.Drawing.Point(454, 68);
            this.btnFastCompare.Name = "btnFastCompare";
            this.btnFastCompare.Size = new System.Drawing.Size(75, 23);
            this.btnFastCompare.TabIndex = 11;
            this.btnFastCompare.Text = "Compare";
            this.btnFastCompare.UseVisualStyleBackColor = true;
            this.btnFastCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(13, 97);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(516, 457);
            this.txtResults.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 566);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnFastCompare);
            this.Controls.Add(this.btnConvertCsv);
            this.Controls.Add(this.txtFilePath2);
            this.Controls.Add(this.bntBrowse2);
            this.Controls.Add(this.txtFilePath1);
            this.Controls.Add(this.btnBrowse1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnBrowse1;
    private System.Windows.Forms.TextBox txtFilePath1;
    private System.Windows.Forms.TextBox txtFilePath2;
    private System.Windows.Forms.Button bntBrowse2;
    private System.Windows.Forms.Button btnConvertCsv;
    private System.Windows.Forms.Button btnFastCompare;
    private System.Windows.Forms.TextBox txtResults;
  }
}

