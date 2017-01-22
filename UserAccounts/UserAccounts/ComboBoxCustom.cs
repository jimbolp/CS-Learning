using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAccounts
{
    internal class ComboBoxCustom : ComboBox
    {
        public ComboBoxCustom()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            ComboBoxItem item = (ComboBoxItem)this.Items[e.Index];
            Font font = e.Font;
            if (item.BoldFont)
            {
                font = new Font(font, FontStyle.Bold);
            }
            Brush brush = new SolidBrush(item.ForeColor);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { brush = Brushes.Yellow; }
            e.Graphics.DrawString(item.Text, font, brush, e.Bounds.X, e.Bounds.Y);
        }
        object selectedValue = null;
        public new Object SelectedValue
        {
            get
            {
                object ret = null;
                if (this.SelectedIndex >= 0)
                {
                    ret = ((ComboBoxItem)this.SelectedItem).Value;
                }
                return ret;
            }
            set { selectedValue = value; }
        }//*/
    }
    public class ComboBoxItem
    {
        public ComboBoxItem() { }

        public ComboBoxItem(string pText, object pValue)
        {
            text = pText; val = pValue;
        }

        public ComboBoxItem(string pText, object pValue, Color pColor, bool bold)
        {
            text = pText; val = pValue; foreColor = pColor;
             BoldFont = bold;
        }

        public bool BoldFont { get; set; }

        string text = "";
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        object val;
        public object Value
        {
            get { return val; }
            set { val = value; }
        }

        Color foreColor = Color.Black;
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        public override string ToString()
        {
            return text;
        }
    }
}
