using System;
using System.Runtime.InteropServices;

// Adding Double Click support to the ComboBox control
// http://www.cyotek.com/blog/adding-double-click-support-to-the-combobox-control

namespace ComboBoxDoubleClickDemo
{
  internal class NativeMethods
  {
    // ReSharper disable InconsistentNaming

    #region Constants

    public const int WM_LBUTTONUP = 0x0202;

    #endregion

    #region Public Class Members

    [DllImport("user32.dll")]
    public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);

    #endregion

    #region Nested Types

    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO
    {
      public int cbSize;

      public RECT rcItem;

      public RECT rcButton;

      public int stateButton;

      public IntPtr hwndCombo;

      public IntPtr hwndEdit;

      public IntPtr hwndList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int left;

      public int top;

      public int right;

      public int bottom;
    }

    #endregion

    // ReSharper restore InconsistentNaming
  }
}
