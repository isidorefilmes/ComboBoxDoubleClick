using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Adding Double Click support to the ComboBox control
// http://www.cyotek.com/blog/adding-double-click-support-to-the-combobox-control

namespace ComboBoxDoubleClickDemo
{
  internal class ComboBox : System.Windows.Forms.ComboBox
  {
    #region Instance Fields

    private bool _allowDoubleClick;

    private ListBoxNativeWindow _listBoxWindow;

    #endregion

    #region Events

    /// <summary>
    /// Occurs when the AllowDoubleClick property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AllowDoubleClickChanged;

    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    public new event EventHandler DoubleClick
    {
      add { base.DoubleClick += value; }
      remove { base.DoubleClick -= value; }
    }

    #endregion

    #region Overridden Methods

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ComboBox"/> and optionally releases the managed resources. 
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.ReleaseHandle();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DropDownStyleChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnDropDownStyleChanged(EventArgs e)
    {
      base.OnDropDownStyleChanged(e);

      this.AttachHandle();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      this.AttachHandle();
    }

    #endregion

    #region Public Properties

    [Category("Behavior")]
    [DefaultValue(false)]
    public virtual bool AllowDoubleClick
    {
      get { return _allowDoubleClick; }
      set
      {
        if (this.AllowDoubleClick != value)
        {
          _allowDoubleClick = value;

          this.OnAllowDoubleClickChanged(EventArgs.Empty);
        }
      }
    }

    #endregion

    #region Internal Members

    internal void RaiseDoubleClick(MouseEventArgs e)
    {
      this.OnDoubleClick(EventArgs.Empty);

      this.OnMouseDoubleClick(e);
    }

    #endregion

    #region Protected Members

    /// <summary>
    /// Raises the <see cref="AllowDoubleClickChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnAllowDoubleClickChanged(EventArgs e)
    {
      EventHandler handler;

      this.AttachHandle();

      handler = this.AllowDoubleClickChanged;

      if (handler != null)
      {
        handler(this, e);
      }
    }

    #endregion

    #region Private Members

    private void AttachHandle()
    {
      this.ReleaseHandle();

      if (this.IsHandleCreated && this.AllowDoubleClick && this.DropDownStyle == ComboBoxStyle.Simple)
      {
        NativeMethods.COMBOBOXINFO info;

        info = new NativeMethods.COMBOBOXINFO();
        info.cbSize = Marshal.SizeOf(info);

        if (NativeMethods.GetComboBoxInfo(this.Handle, ref info))
        {
          IntPtr hWnd;

          hWnd = info.hwndList;

          _listBoxWindow = new ListBoxNativeWindow(this);

          _listBoxWindow.AssignHandle(hWnd);
        }
      }
    }

    private void ReleaseHandle()
    {
      if (_listBoxWindow != null)
      {
        _listBoxWindow.ReleaseHandle();
        _listBoxWindow = null;
      }
    }

    #endregion

    #region Nested Types

    private class ListBoxNativeWindow : NativeWindow
    {
      #region Instance Fields

      private readonly ComboBox _owner;

      private long _lastMessageTime;

      private Point _lastMousePosition;

      #endregion

      #region Public Constructors

      public ListBoxNativeWindow(ComboBox owner)
      {
        _owner = owner;
        _lastMousePosition = Point.Empty;
      }

      #endregion

      #region Overridden Methods

      /// <summary>
      /// Invokes the default window procedure associated with this window. 
      /// </summary>
      /// <param name="m">A <see cref="T:System.Windows.Forms.Message"/> that is associated with the current Windows message. </param>
      protected override void WndProc(ref Message m)
      {
        if (m.Msg == NativeMethods.WM_LBUTTONUP)
        {
          long previousMessageTime;
          long currentMessageTime;
          Point currentLocation;

          previousMessageTime = _lastMessageTime;
          currentMessageTime = DateTime.Now.Ticks;
          currentLocation = this.GetPoint(m.LParam);

          if (_lastMessageTime > 0)
          {
            Rectangle doubleClickBounds;
            Size doubleClickSize;

            doubleClickSize = SystemInformation.DoubleClickSize;
            doubleClickBounds = new Rectangle(_lastMousePosition.X - (doubleClickSize.Width / 2), _lastMousePosition.Y - (doubleClickSize.Height / 2), doubleClickSize.Width, doubleClickSize.Height);

            if (previousMessageTime + (SystemInformation.DoubleClickTime * TimeSpan.TicksPerMillisecond) > currentMessageTime && doubleClickBounds.Contains(currentLocation))
            {
              MouseEventArgs e;

              e = new MouseEventArgs(MouseButtons.Left, 2, currentLocation.X, currentLocation.Y, 0);

              _owner.RaiseDoubleClick(e);
            }
          }

          _lastMessageTime = currentMessageTime;
          _lastMousePosition = currentLocation;
        }

        base.WndProc(ref m);
      }

      #endregion

      #region Private Members

      private Point GetPoint(IntPtr lParam)
      {
        uint xy;
        int x;
        int y;

        //  http://stackoverflow.com/a/17902757/148962

        xy = unchecked(IntPtr.Size == 8 ? (uint)lParam.ToInt64() : (uint)lParam.ToInt32());
        x = unchecked((short)xy);
        y = unchecked((short)(xy >> 16));

        return new Point(x, y);
      }

      #endregion
    }

    #endregion
  }
}
