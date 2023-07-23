using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeTabs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;
            if (textBox2.Text.Length == 0) return;

            var lines1 = textBox1.Text.Split(new[] {"\r\n","\r","\n"}, StringSplitOptions.None);
            var lines2 = textBox2.Text.Split(new[] {"\r\n","\r","\n"}, StringSplitOptions.None);

            var newLines = new StringBuilder();
            int i = 0;
            var lines2Count = lines2.Count();
            string splitter = textBox3.Text;
            foreach (var line1 in lines1)
            {
                var line = line1;

                if (i < lines2Count) line += splitter + lines2[i];

                i++;
                newLines.AppendLine(line);
            }

            textBox1.Text = newLines.ToString();
            textBox2.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox1.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox2.Text);
        }
    }
}
