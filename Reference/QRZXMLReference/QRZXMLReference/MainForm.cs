using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace QRZXMLReference
{
    public partial class MainForm : Form
    {
        public string dburl = "http://www.qrz.com/dxml/xml.pl"; 
        
        public Form LoginForm;
        public string username = "";
        public string password = "";
        public string xmlSession = "";
        public string xmlError = "";
        public string xmlMessage = "";

        private WebClient wc = new WebClient();
        private DataSet QRZData = new DataSet("QData");
        public bool isOnline = false;

        public MainForm()
        {
            InitializeComponent();
            LoginForm = new SettingsForm(this);
            clearGroup();
            //if (!isOnline) LoginForm.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm.ShowDialog(this);
        }

        private string QRZField(DataRow row, string f)
        {
            if (row.Table.Columns.Contains(f))return row[f].ToString(); else return "";
        }

        public void callQRZ(string url)
        {
            Stream qrzstrm;
            try
            {
                QRZData.Clear();
                qrzstrm = wc.OpenRead(url);
                QRZData.ReadXml(qrzstrm, XmlReadMode.InferSchema);
                qrzstrm.Close();
                if (!QRZData.Tables.Contains("QRZDatabase")) {
                    MessageBox.Show("Error: failed to receive QRZDatabase object", "XML Server Error");
                    return;
                }
                DataRow dr = QRZData.Tables["QRZDatabase"].Rows[0];
                Lversion.Text = QRZField(dr, "version");
                DataTable sess = QRZData.Tables["Session"];
                DataRow sr = sess.Rows[0];
                xmlError = QRZField(sr, "Error");
                statusBar.Text = xmlError;
                xmlSession = QRZField(sr, "Key");
                xmlMessage = QRZField(sr, "Message");
                LGMTime.Text = QRZField(sr, "GMTime");
                Lcount.Text = QRZField(sr, "Count");
                LSubExp.Text = QRZField(sr, "SubExp");
                LKey.Text = xmlSession;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "XML Error");
            }
            isOnline = (xmlSession.Length > 0) ? true : false;

        }

        public void doLogin()
        {
             string url = dburl + "?username=" + username + ";password=" + password;
             callQRZ(url);
             if (isOnline)
             {
                 statusBar.Text = "Login OK";
             }
        }

        private void WriteBox()
        {
            if (! QRZData.Tables.Contains("Callsign")) return;
            DataTable callTable = QRZData.Tables["Callsign"];
            if (callTable.Rows.Count == 0) return;
            DataRow dr = callTable.Rows[0];

            searchBox.Text = "";

            Lcall.Text = QRZField(dr, "call");
            Lfullname.Text = QRZField(dr, "fname") + " " + QRZField(dr, "name");
            Laddr1.Text = QRZField(dr, "addr1");
            Laddr2.Text = QRZField(dr, "addr2") + " " + QRZField(dr, "state") + " " + QRZField(dr, "zip");
            Lcountry.Text = QRZField(dr, "country");

            Llat.Text = QRZField(dr, "lat");
            Llon.Text = QRZField(dr, "lon");
            Lgrid.Text = QRZField(dr, "grid");
            Lcounty.Text = QRZField(dr, "county");
            Lland.Text = QRZField(dr, "land");
            Lefdate.Text = QRZField(dr, "efdate");
            Lexpdate.Text = QRZField(dr, "expdate");
            Lp_call.Text = QRZField(dr, "p_call");
            Lborn.Text = QRZField(dr, "born");
            Ltrustee.Text = QRZField(dr, "trustee");
            Lclass.Text = QRZField(dr, "class");
            Lcodes.Text = QRZField(dr, "codes");
            Lqslmgr.Text = QRZField(dr, "qslmgr");
            Lemail.Text = QRZField(dr, "email");
            Lurl.Text = QRZField(dr, "url");
            Lu_views.Text = QRZField(dr, "u_views");
            Lbio.Text = QRZField(dr, "bio");
            Limage.Text = QRZField(dr, "image");
            Lmoddate.Text = QRZField(dr, "moddate");
            LAreaCode.Text = QRZField(dr, "AreaCode");
            LTimeZone.Text = QRZField(dr, "TimeZone");
            LGMTOffset.Text = QRZField(dr, "GMTOffset");
            LDST.Text = QRZField(dr, "DST");
            Leqsl.Text = QRZField(dr, "eqsl");
            Lmqsl.Text = QRZField(dr, "mqsl");
            Leqsl.Text = QRZField(dr, "eqsl");
            Lcqzone.Text = QRZField(dr, "cqzone");
            Lituzone.Text = QRZField(dr, "ituzone");
            Llocref.Text = QRZField(dr, "locref"); 
            Liota.Text = QRZField(dr, "iota");
            Llotw.Text = QRZField(dr, "lotw");
            Luser.Text = QRZField(dr, "user");
            Lfips.Text = QRZField(dr, "fips");
            Lland.Text = QRZField(dr, "land");
            LMSA.Text = QRZField(dr, "MSA");
        }

        private void GetCallsign(string cs)
        {
            if (cs.Length < 3) return;
            string url = dburl + "?s=" + xmlSession + ";callsign=" + cs;
            callQRZ(url);
            if (!isOnline)
            {
                LoginForm.ShowDialog(this);
                if (isOnline)
                {
                    GetCallsign(cs);
                }
                return;
            }
            WriteBox();
        }

        private void clearGroup()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if ((string)c.Tag == "x") c.Text = "";
            }
            this.Refresh();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            clearGroup();
            GetCallsign(searchBox.Text.ToString());
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
