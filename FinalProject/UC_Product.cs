using DevExpress.Utils.CommonDialogs;
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
    public partial class UC_Product : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Product()
        {
            InitializeComponent();
        }
        dotNET_FinalProjectEntities db;
        private byte[] imageData;
        private void UC_Product_Load(object sender, EventArgs e)
        {   
            db = new dotNET_FinalProjectEntities(); 
            db.Products.Load();
            db.Suppliers.Load();
            productBindingSource.DataSource = db.Products.Local;
            supplierBindingSource.DataSource = db.Suppliers.Local;
        }

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            productBindingSource.AddNew();
            btnUpload.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            productBindingSource.EndEdit();
            Product product = productBindingSource.Current as Product;
            if (product != null)
            {
                if (product.Ivalid)
                {
                    product.Image = imageData;
                    product.Quantity = 0;
                    db.SaveChanges();
                    XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    btnUpload.Enabled = false;
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (pictureEdit1 != null && pictureEdit1.EditValue != null)
            {
                Image image = pictureEdit1.EditValue as Image;
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
            Product product = productBindingSource.Current as Product;
            var deliveryDT = db.DeliveryDetails.Where(x => x.ProductID == product.ID).FirstOrDefault();
            var receivedDT = db.ReceivedDetails.Where(x => x.ProductID == product.ID).FirstOrDefault();
            if (deliveryDT != null || receivedDT != null)
            {
                XtraMessageBox.Show("Current Product cannot be deleted !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (XtraMessageBox.Show("Are you sure want to delete this product? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    productBindingSource.RemoveCurrent();
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
            productBindingSource.ResetBindings(false);
        }

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpload.Enabled = false;
            btnSave.Enabled = false;
            db = new dotNET_FinalProjectEntities();
            db.Products.Load();
            db.Suppliers.Load();
            productBindingSource.DataSource = db.Products.Local;
            supplierBindingSource.DataSource = db.Suppliers.Local;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Product.ExportToCsv(sf.FileName);
            }
        }
    }
}
