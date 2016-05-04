using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace TMS
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            XtraForm prompt = new XtraForm();
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.MaximumSize = new System.Drawing.Size(600, 200);
            prompt.MinimumSize = new System.Drawing.Size(500, 150);
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            LabelControl textLabel = new LabelControl() { Left = 50, Top = 20, Text = text };
            TextEdit textBox = new TextEdit() { Left = 50, Top = 40, Width = 400 };
            SimpleButton confirmation = new SimpleButton() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }
}
