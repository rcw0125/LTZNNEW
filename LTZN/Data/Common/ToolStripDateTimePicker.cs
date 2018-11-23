using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;


namespace LTZN.Common
{
    
    public class ToolStripDateTimePicker : ToolStripControlHost
    {

        public ToolStripDateTimePicker() : base(new DateTimePicker()) { }
        public DateTimePicker DateTimePickerControl
        {
            get
            {
                return Control as DateTimePicker;
            }
        }

        public DateTime Value
        {
            get
            {
                return DateTimePickerControl.Value;
            }
            set { DateTimePickerControl.Value = value; }
        }
        public  int ControlWidth
        {
            get
            {
                return DateTimePickerControl.Width;
            }
            set { DateTimePickerControl.Width = value; }
        }
        public DateTimePickerFormat Format
        {
            get { return DateTimePickerControl.Format; }
            set { DateTimePickerControl.Format = value; }
        }
        public string CustomFormat 
        {
            get { return DateTimePickerControl.CustomFormat; }
            set { DateTimePickerControl.CustomFormat = value; }
        }

        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);

            // Cast the control to a DateTimePicker control.
            DateTimePicker DateTimePickerControl = (DateTimePicker)c;

            // Add the event.
            DateTimePickerControl.ValueChanged += new EventHandler(DateTimePickerValueChanged);
               
        }
        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a DateTimePicker control.
            DateTimePicker DateTimePickerControl = (DateTimePicker)c;
            
            // Remove the event.
            DateTimePickerControl.ValueChanged -=
                new EventHandler(DateTimePickerValueChanged);
        }

        // ΪҪ�������¼��ṩ��Ҫ�İ�װ��
        public event EventHandler ValueChanged;
        public void DateTimePickerValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

    }
}
