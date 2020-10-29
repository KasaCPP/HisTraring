using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HIS.Maping;
using Newtonsoft.Json;

namespace HIS
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            String user = this.username.Text;
            String password = this.pass.Text;
            MD5 m = MD5.Create();
            byte[] buffer = Encoding.Default.GetBytes(password);
            byte[] md5buffer = m.ComputeHash(buffer);
            string passMd5 = null;
            foreach (byte b in md5buffer) 
            {
                passMd5 += b.ToString("x2");
            }
            List<packaging> loginList = new List<packaging>();
            User login = new User()
            {
                id = user,
                passwords = passMd5
            };
            packaging packaging = new packaging() 
            {
                Function="login",
                info=login
            };
            loginList.Add(packaging);
            string jsonString = JsonConvert.SerializeObject(loginList);
            MessageBox.Show(jsonString);
            //unit.Connection(jsonString);
        }

        private void zk_Click(object sender, EventArgs e)
        {
            this.username.Text = null;
            this.pass.Text = null;
        }

    }
}
