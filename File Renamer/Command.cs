using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace File_Renamer
{
    class Command
    {
        public string title = "RHIT File Renamer";
        public string website = "http://rhitsolution.com";
        public string facebook_site = "http://facebook.com/rhitsion";

        public void cetakSukses(string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void cetakGagal(string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool cetakTanya(string message)
        {
            bool status = false;

            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                status = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                status = false;
            }

            return status;
        }
    }
}