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
    public partial class UC_Agency : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Agency()
        {
            InitializeComponent();
        }
        dotNET_FinalProjectEntities db;
        private byte[] imageData;

        private void UC_Agency_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Employees.Load();
            employeeBindingSource.DataSource = db.Employees.Local;
            db.Agencies.Load();
            agencyBindingSource.DataSource = db.Agencies.Local;
        }

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            agencyBindingSource.AddNew();
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
            agencyBindingSource.EndEdit();
            Agency agency = agencyBindingSource.Current as Agency;
            if (agency != null)
            {
                if (agency.Ivalid)
                {
                    agency.Image = imageData;
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
            Agency agency = agencyBindingSource.Current as Agency;
            var delevery = db.Deliveries.Where(x => x.AngencyID == agency.ID).FirstOrDefault();
            if (delevery != null)
            {
                XtraMessageBox.Show("Current Agency cannot be deleted !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (XtraMessageBox.Show("Are you sure want to delete this Supplier? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    agencyBindingSource.RemoveCurrent();
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
            agencyBindingSource.ResetBindings(false);
        }

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpload.Enabled = false;
            btnSave.Enabled = false;
            db = new dotNET_FinalProjectEntities();
            db.Agencies.Load();
            agencyBindingSource.DataSource = db.Agencies.Local;
            db.Employees.Load();
            employeeBindingSource.DataSource = db.Employees.Local;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Agency.ExportToCsv(sf.FileName);
            }
        }
    }
}
