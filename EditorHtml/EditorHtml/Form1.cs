using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorHtml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Image img = new Bitmap(@"C:\Users\Luqman\Desktop\bgimage.jpg");
            this.BackgroundImage = img;
            string path = @"C:\Users\Luqman\Desktop\EditorHtml\stylecode.txt";
            string riga;
            // ciclo per inserire una parte del codice in modo da far funzionare il css
            StreamReader sr = new StreamReader(path);
            while((riga=sr.ReadLine())!=null)
            {
                rtb1.Text = rtb1.Text + riga;
            }
        }

        private void UpdateBrowser()
        {
            //rappresentazione in tempo reale del webbrowser
            webBrowser1.DocumentText = rtb1.Text.Replace("@RenderCSS", rtb2.Text);
        }

        private void rtb1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateBrowser();
        }

        private void rtb1_KeyUp_1(object sender, KeyEventArgs e)
        {
            UpdateBrowser();
        }

        private void rtb2_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateBrowser();
        }

        private void rtb1_TextChanged(object sender, EventArgs e)
        {
            UpdateBrowser();
        }

        private void rtb2_TextChanged(object sender, EventArgs e)
        {
            UpdateBrowser();
        }

        //metodo salataggio file html
        private void save_html_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgsave = new SaveFileDialog();
            dlgsave.Filter = "txt Files (*.txt)|*.txt|All files (*.*)|*.*| Html (*.html)|*.html";
            try
            {
                if(dlgsave.ShowDialog()==DialogResult.OK)
                {
                    using(Stream s=File.Open(dlgsave.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(rtb1.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error saving Code...");
            }
        }

        //metodo salataggio file css
        private void save_css_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgsave = new SaveFileDialog();
            dlgsave.Filter = "txt Files (*.txt)|*.txt|All files (*.*)|*.*";
            try
            {
                if (dlgsave.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(dlgsave.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.WriteLine(rtb2.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error saving Code...");
            }
        }

        //metodo carica file esistenti html
        private void load_html_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfile = new OpenFileDialog();
            if(opnfile.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(opnfile.FileName));
                rtb1.Text = sr.ReadToEnd();
                sr.Dispose();
            }
        }

        //metodo cariva file esistenti css
        private void Load_css_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfile = new OpenFileDialog();
            if(opnfile.ShowDialog()==DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(opnfile.FileName));
                rtb2.Text = sr.ReadToEnd();
                sr.Dispose();
            }
        }

        //bottone per uscire dal programma
        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
