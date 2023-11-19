using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FinalProject
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            dotNET_FinalProjectEntities db = new dotNET_FinalProjectEntities();
            var user = db.Employees.Where(x => x.Username == txtUsername.Text).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == txtPassword.Text)
                {
                    Program.userPosition = user.Position;
                    Program.userID = user.ID;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Login. Please check your Password!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Login. Please check your Username!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Program.userPosition = "";
            Program.userID = "";
            Application.Exit();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnLogin_Click(sender, e);
                //MessageBox.Show("Enter");
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                //MessageBox.Show("Enter");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                //MessageBox.Show("Enter");
            }
        }
    }
}
