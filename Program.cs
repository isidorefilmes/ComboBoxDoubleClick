using System;
using System.Windows.Forms;

// Adding Double Click support to the ComboBox control
// http://www.cyotek.com/blog/adding-double-click-support-to-the-combobox-control

namespace ComboBoxDoubleClickDemo
{
  internal static class Program
  {
    #region Private Class Members

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }

    #endregion
  }
}
