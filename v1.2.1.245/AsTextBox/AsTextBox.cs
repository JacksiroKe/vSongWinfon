using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AsTextBox
{
    //[ToolboxItem(true)]
    //[ToolboxBitmap(typeof(AsTextBox), "AsTextBox.bmp")]
    public class AsTextBox : TextBox
    {
        private string My_Default_Text = string.Empty;
        public string DefaultText
        {
            get
            {
                return My_Default_Text;
            }
            set
            {
                My_Default_Text = value;
                MyDefault_Text();
            }
        }

        public AsTextBox()
        {
            this.GotFocus += (sender, e) =>
            { if (this.Text.Equals(DefaultText)) { this.Text = string.Empty; } };
            this.LostFocus += (sender, e) => { MyDefault_Text(); };
        }
        private void MyDefault_Text()
        {
            if (this.Text.Trim().Length == 0)
                this.Text = DefaultText;
        }
    }
}
