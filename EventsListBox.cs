using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

// Adding Double Click support to the ComboBox control
// http://www.cyotek.com/blog/adding-double-click-support-to-the-combobox-control

namespace ComboBoxDoubleClickDemo
{
  internal class EventsListBox : ListBox
  {
    #region Public Constructors

    public EventsListBox()
    {
      this.HorizontalScrollbar = true;
    }

    #endregion

    #region Public Properties

    [DefaultValue(true)]
    public new bool HorizontalScrollbar
    {
      get { return base.HorizontalScrollbar; }
      set { base.HorizontalScrollbar = value; }
    }

    #endregion

    #region Public Members

    public void AddEvent(Control sender, string eventName)
    {
      this.AddEvent(sender, eventName, null);
    }

    public void AddEvent(Control sender, string eventName, EventArgs args)
    {
      StringBuilder eventData;
      PropertyInfo[] properties;

      eventData = new StringBuilder();

      eventData.Append(DateTime.Now.ToLongTimeString());
      eventData.Append("\t");
      eventData.Append(sender.Name);
      eventData.Append(".");
      eventData.Append(eventName);
      eventData.Append(" (");

      properties = args.GetType().GetProperties();
      for (int i = 0; i < properties.Length; i++)
      {
        PropertyInfo property;
        string value;

        property = properties[i];

        try
        {
          object rawValue;

          rawValue = property.GetValue(args, null);

          value = rawValue != null ? rawValue.ToString() : null;
        }
        catch
        {
          value = null;
        }

        eventData.AppendFormat("{0} = {1}", property.Name, value);

        if (i < properties.Length - 1)
        {
          eventData.Append(", ");
        }
      }

      eventData.Append(")");

      this.Items.Add(eventData.ToString());
      this.TopIndex = this.Items.Count - (this.ClientSize.Height / this.ItemHeight);
    }

    #endregion
  }
}
