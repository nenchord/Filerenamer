using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_Renamer
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        Command cmd = new Command();        

        public Form1()
        {
            InitializeComponent();
            Validator val = new Validator();
            val.isValidateFree();
            tabControl1.SelectedTab = tabPage1;
            disableTextboxt(true);
            this.Text = cmd.title;
            
        }

        private void textboxClear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void disableTextboxt(bool status)
        {
            textBox2.Enabled = !status;
            textBox3.Enabled = !status;
        }

        private void disableTextboxtab1(bool status)
        {
            textBox5.Enabled = !status;
            textBox4.Enabled = !status;
        }

        private void startURL()
        {
            System.Diagnostics.Process.Start(cmd.website);
            System.Diagnostics.Process.Start(cmd.facebook_site);
        }

        private void openFolderDir()
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    textBox1.Text = fbd.SelectedPath;
                    textBox6.Clear();
                }
                else
                {
                    textBox6.Text = fbd.SelectedPath;
                    textBox1.Clear();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openFolderDir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFolderDir();
        }        

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                cmd.cetakGagal("Select the Directory First");
            }
            else
            {
                Rename(textBox2.Text, textBox1.Text, textBox3.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                cmd.cetakGagal("Select the Directory First");
            }
            else
            {
                if (textBox5.Text.Equals(""))
                {
                    cmd.cetakGagal("Fill in the replace field");
                }
                else
                {
                    Replace(textBox5.Text, textBox6.Text, textBox4.Text);
                }
            }

        }

        private string filetrimmer(string filepath)
        {
            int backslash = filepath.LastIndexOf('\\');
            string trim = filepath.Substring(0, backslash + 1);
            return trim;
        }

        private void Rename(string prefix, string filepath, string suffix)
        {
            DirectoryInfo d = new DirectoryInfo(filepath);
            FileInfo[] file = d.GetFiles();
            

            if (cmd.cetakTanya("The whole filename will be renamed, are you sure ?"))
            {
                try
                {
                    foreach (FileInfo f in file)
                    {
                        string namafile = Path.GetFileNameWithoutExtension(f.FullName);
                        string ext = Path.GetExtension(f.FullName);
                        File.Move(f.FullName, filepath + '\\' + (prefix + namafile + suffix) +ext);
                    }
                }
                catch (Exception e)
                {
                    cmd.cetakGagal(e.ToString());
                }

                cmd.cetakSukses("Rename Success");                
            }
        }

        private void Replace(string replace, string filepath, string by)
        {
            DirectoryInfo d = new DirectoryInfo(filepath);
            FileInfo[] file = d.GetFiles();

            if (cmd.cetakTanya("The whole filename will be replaced, are you sure ?"))
            {
                try
                {
                    foreach (FileInfo f in file)
                    {
                        string namafile = Path.GetFileNameWithoutExtension(f.FullName);
                        string ext = Path.GetExtension(f.FullName);
                        string replaced = namafile.Replace(replace, by);

                        File.Move(f.FullName, filepath + '\\' + replaced + ext);
                    }
                }
                catch (Exception e)
                {
                    cmd.cetakGagal(e.ToString());
                }

                cmd.cetakSukses("Rename Success");
                startURL();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                disableTextboxt(true);
            }
            else
            {
                disableTextboxt(false);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                disableTextboxt(true);
                disableTextboxtab1(false);
            }
            else
            {
                disableTextboxt(false);
                disableTextboxtab1(true);
            }
            textboxClear();            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                disableTextboxtab1(true);
            }
            else
            {
                disableTextboxtab1(false);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cmd.cetakTanya("Are you sure you want to exit ?"))
            {
                cmd.cetakSukses("Thank you for using " + cmd.title);
                startURL();
            }
        }
    }
}
