using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QRZXMLReference
{
    public partial class SettingsForm : Form
    {
        private MainForm mf;

        public SettingsForm(MainForm mmf)
        {
            mf = mmf;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusBar.Text = "";
            mf.username = usernameBox.Text.ToString();
            mf.password = passwordBox.Text.ToString();
            mf.dburl = serverBox.Text.ToString();
            mf.doLogin();
            if (mf.isOnline) this.Hide(); else statusBar.Text = mf.xmlError;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
