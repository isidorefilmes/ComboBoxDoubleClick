namespace ComboBoxDoubleClickDemo
{
  partial class MainForm
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
      this.closeButton = new System.Windows.Forms.Button();
      this.allowDoubleClickCheckBox = new System.Windows.Forms.CheckBox();
      this.demoGroupBox = new System.Windows.Forms.GroupBox();
      this.eventsGroupBox = new System.Windows.Forms.GroupBox();
      this.eventsListBox = new ComboBoxDoubleClickDemo.EventsListBox();
      this.simpleComboBox = new ComboBoxDoubleClickDemo.ComboBox();
      this.demoGroupBox.SuspendLayout();
      this.eventsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // closeButton
      // 
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(483, 390);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 2;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // allowDoubleClickCheckBox
      // 
      this.allowDoubleClickCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.allowDoubleClickCheckBox.AutoSize = true;
      this.allowDoubleClickCheckBox.Checked = true;
      this.allowDoubleClickCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.allowDoubleClickCheckBox.Location = new System.Drawing.Point(6, 157);
      this.allowDoubleClickCheckBox.Name = "allowDoubleClickCheckBox";
      this.allowDoubleClickCheckBox.Size = new System.Drawing.Size(111, 17);
      this.allowDoubleClickCheckBox.TabIndex = 1;
      this.allowDoubleClickCheckBox.Text = "Allow &double click";
      this.allowDoubleClickCheckBox.UseVisualStyleBackColor = true;
      this.allowDoubleClickCheckBox.CheckedChanged += new System.EventHandler(this.allowDoubleClickCheckBox_CheckedChanged);
      // 
      // demoGroupBox
      // 
      this.demoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.demoGroupBox.Controls.Add(this.allowDoubleClickCheckBox);
      this.demoGroupBox.Controls.Add(this.simpleComboBox);
      this.demoGroupBox.Location = new System.Drawing.Point(12, 12);
      this.demoGroupBox.Name = "demoGroupBox";
      this.demoGroupBox.Size = new System.Drawing.Size(546, 180);
      this.demoGroupBox.TabIndex = 0;
      this.demoGroupBox.TabStop = false;
      this.demoGroupBox.Text = "Demonstration";
      // 
      // eventsGroupBox
      // 
      this.eventsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.eventsGroupBox.Controls.Add(this.eventsListBox);
      this.eventsGroupBox.Location = new System.Drawing.Point(12, 198);
      this.eventsGroupBox.Name = "eventsGroupBox";
      this.eventsGroupBox.Size = new System.Drawing.Size(546, 186);
      this.eventsGroupBox.TabIndex = 1;
      this.eventsGroupBox.TabStop = false;
      this.eventsGroupBox.Text = "Events";
      // 
      // eventsListBox
      // 
      this.eventsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.eventsListBox.FormattingEnabled = true;
      this.eventsListBox.IntegralHeight = false;
      this.eventsListBox.Location = new System.Drawing.Point(6, 19);
      this.eventsListBox.Name = "eventsListBox";
      this.eventsListBox.Size = new System.Drawing.Size(534, 161);
      this.eventsListBox.TabIndex = 0;
      // 
      // simpleComboBox
      // 
      this.simpleComboBox.AllowDoubleClick = true;
      this.simpleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
      this.simpleComboBox.FormattingEnabled = true;
      this.simpleComboBox.IntegralHeight = false;
      this.simpleComboBox.Location = new System.Drawing.Point(6, 19);
      this.simpleComboBox.Name = "simpleComboBox";
      this.simpleComboBox.Size = new System.Drawing.Size(534, 132);
      this.simpleComboBox.TabIndex = 0;
      this.simpleComboBox.DoubleClick += new System.EventHandler(this.simpleComboBox_DoubleClick);
      this.simpleComboBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.simpleComboBox_MouseDoubleClick);
      // 
      // MainForm
      // 
      this.AcceptButton = this.closeButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(570, 425);
      this.Controls.Add(this.eventsGroupBox);
      this.Controls.Add(this.demoGroupBox);
      this.Controls.Add(this.closeButton);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ComboBox Double Click Demonstration";
      this.demoGroupBox.ResumeLayout(false);
      this.demoGroupBox.PerformLayout();
      this.eventsGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private ComboBoxDoubleClickDemo.ComboBox simpleComboBox;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.CheckBox allowDoubleClickCheckBox;
    private EventsListBox eventsListBox;
    private System.Windows.Forms.GroupBox demoGroupBox;
    private System.Windows.Forms.GroupBox eventsGroupBox;
  }
}

