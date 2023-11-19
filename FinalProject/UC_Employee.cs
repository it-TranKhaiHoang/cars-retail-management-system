using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class UC_Employee : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Employee()
        {
            InitializeComponent();
        }

        dotNET_FinalProjectEntities db;
        private byte[] imageData;

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Employees.Load();
            employeeBindingSource.DataSource = db.Employees.Local;
            db.Suppliers.Load();
            db.Agencies.Load();
            supplierBindingSource.DataSource = db.Suppliers.Local;
            agencyBindingSource.DataSource = db.Agencies.Local;
        }

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            employeeBindingSource.AddNew();
            btnUpload.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePictureEdit.Image = Image.FromFile(openFileDialog.FileName);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            employeeBindingSource.EndEdit();
            Employee employee = employeeBindingSource.Current as Employee;
            if (employee != null)
            {
                if (employee.Ivalid)
                {
                    string[] parts = EmailTextEdit.Text.Split('@');
                    string username = parts[0];
                    employee.Image = imageData;
                    employee.Username = username;
                    employee.Password = "123456";
                    db.SaveChanges();
                    XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    btnUpload.Enabled = false;
                }
            }
        }

        private void ImagePictureEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ImagePictureEdit != null && ImagePictureEdit.EditValue != null)
            {
                Image image = ImagePictureEdit.EditValue as Image;
                if (image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, ImageFormat.Jpeg);
                        imageData = ms.ToArray();
                    }
                }
            }
        }

        private void barBtn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSave.Enabled = false;
            btnUpload.Enabled = false;
            Employee employee = employeeBindingSource.Current as Employee;
            var delivery = db.Deliveries.Where(x => x.EmployeeID == employee.ID).FirstOrDefault();
            var received = db.Receiveds.Where(x => x.EmployeeID == employee.ID).FirstOrDefault();
            if (received != null || delivery != null)
            {
                XtraMessageBox.Show("Current Employee cannot be deleted !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (XtraMessageBox.Show("Are you sure want to delete this Employee? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    employeeBindingSource.RemoveCurrent();
                    db.SaveChanges();
                    XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void barBtn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpload.Enabled = false;
            btnSave.Enabled = false;
            var changed = db.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (var obj in changed)
            {
                switch (obj.State)
                {
                    case EntityState.Modified:
                        obj.CurrentValues.SetValues(obj.OriginalValues);
                        obj.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        obj.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        obj.State = EntityState.Unchanged;
                        break;
                }
            }
            employeeBindingSource.ResetBindings(false);
        }

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Employees.Load();
            employeeBindingSource.DataSource = db.Employees.Local;
            btnUpload.Enabled = false;
            btnSave.Enabled = false;
            db.Suppliers.Load();
            db.Agencies.Load();
            supplierBindingSource.DataSource = db.Suppliers.Local;
            agencyBindingSource.DataSource = db.Agencies.Local;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Employee.ExportToCsv(sf.FileName);
            }
        }
    }
}
