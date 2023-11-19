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
    public partial class UC_Supplier : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Supplier()
        {
            InitializeComponent();
        }

        dotNET_FinalProjectEntities db;
        private byte[] imageData;

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            supplierBindingSource.AddNew();
            btnUpload.Enabled = true;
            btnSave.Enabled = true;
        }

        private void UC_Supplier_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Suppliers.Load();
            supplierBindingSource.DataSource = db.Suppliers.Local;
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
            supplierBindingSource.EndEdit();
            Supplier supplier = supplierBindingSource.Current as Supplier;
            if (supplier != null)
            {
                if (supplier.Ivalid)
                {
                    supplier.Image = imageData;
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
            Supplier supplier = supplierBindingSource.Current as Supplier;
            var product = db.Products.Where(x => x.SupplierID == supplier.ID).FirstOrDefault();
            if (product != null)
            {
                XtraMessageBox.Show("Current Supplier cannot be deleted !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            } else
            {
                if (XtraMessageBox.Show("Are you sure want to delete this Supplier? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    supplierBindingSource.RemoveCurrent();
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
            supplierBindingSource.ResetBindings(false);
        }

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpload.Enabled = false;
            btnSave.Enabled = false;
            db = new dotNET_FinalProjectEntities();
            db.Suppliers.Load();
            supplierBindingSource.DataSource = db.Suppliers.Local;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Supplier.ExportToCsv(sf.FileName);
            }
        }
    }
}
