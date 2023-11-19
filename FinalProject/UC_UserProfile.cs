using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class UC_UserProfile : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_UserProfile()
        {
            InitializeComponent();
        }

        dotNET_FinalProjectEntities db;
        private void UC_UserProfile_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Employees.Load();
            employeeBindingSource.DataSource = db.Employees.Where(x => x.ID == Program.userID).FirstOrDefault();
            
        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                PasswordTextEdit.Properties.UseSystemPasswordChar= false;
            } else
            {
                PasswordTextEdit.Properties.UseSystemPasswordChar = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
