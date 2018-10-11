using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Adding Double Click support to the ComboBox control
// http://www.cyotek.com/blog/adding-double-click-support-to-the-combobox-control

namespace ComboBoxDoubleClickDemo
{
  internal partial class MainForm : Form
  {
    #region Public Constructors

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Overridden Methods

    protected override void OnLoad(EventArgs e)
    {
      object[] words;

      base.OnLoad(e);

      words = new object[]
              {
                "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"
              };
      simpleComboBox.Items.AddRange(words);
    }

    #endregion

    #region Private Members

    private void GetEditHandle(IWin32Window control)
    {
      this.ShowComboBoxInfo(control, true);
    }

    private void GetListHandle(IWin32Window control)
    {
      this.ShowComboBoxInfo(control, false);
    }

    private void ShowComboBoxInfo(IWin32Window control, bool showEditHandle)
    {
      NativeMethods.COMBOBOXINFO info;

      info = new NativeMethods.COMBOBOXINFO();
      info.cbSize = Marshal.SizeOf(info);

      if (NativeMethods.GetComboBoxInfo(control.Handle, ref info))
      {
        IntPtr handle;

        handle = showEditHandle ? info.hwndEdit : info.hwndList;

        MessageBox.Show(handle == IntPtr.Zero ? "This control does not support this mode." : string.Format("The requested handle is {0}.", handle), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show("Failed to obtain requested information.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    #endregion

    #region Event Handlers

    private void allowDoubleClickCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      simpleComboBox.AllowDoubleClick = allowDoubleClickCheckBox.Checked;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void simpleComboBox_DoubleClick(object sender, EventArgs e)
    {
      eventsListBox.AddEvent(simpleComboBox, "DoubleClick", e);
    }

    private void simpleComboBox_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      eventsListBox.AddEvent(simpleComboBox, "MouseDoubleClick", e);
    }

    #endregion
  }
}
