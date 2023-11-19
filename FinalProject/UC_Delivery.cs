using DevExpress.ChartRangeControlClient.Core;
using DevExpress.DashboardWin.Design;
using DevExpress.PivotGrid.OLAP.SchemaEntities;
using DevExpress.PivotGrid.PivotTable;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class UC_Delivery : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Delivery()
        {
            InitializeComponent();
        }
        dotNET_FinalProjectEntities db;
        private void UC_Delivery_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Deliveries.Load();
            db.Agencies.Load();
            db.Products.Load();
            db.Employees.Load();
            db.Bills.Load();
            deliveryBindingSource.DataSource = db.Deliveries.Local;
            billBindingSource.DataSource = db.Bills.Local;
            
            agencyBindingSource.DataSource = db.Agencies.Local;
            employeeBindingSource.DataSource = db.Employees.Local;

            // Load data to grid look up edit
            repositoryProduct.DataSource = db.Products.Local;
            repositoryProduct.ValueMember = "ID";
            repositoryProduct.DisplayMember = "Name";
            repositoryProduct.NullText = @"Choose Product";
            colProID.ColumnEdit = repositoryProduct;

            GV_DeliveryDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            AngencyIDTextEdit.Enabled = false;
            DeliveryDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false; 
        }

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deliveryDetailBindingSource.AddNew();
            deliveryBindingSource.AddNew();
            DateTime now = DateTime.Now;
            long uniqueNumber = now.Ticks % 1000000;
            string ReceivedDTID = "RID-" + uniqueNumber.ToString();
            IDTextEdit.Text = ReceivedDTID;

            btnSave.Enabled = true;
            btnAddItem.Enabled = true;

            AngencyIDTextEdit.Enabled = true;
            DeliveryDateDateEdit.Enabled = true;
            DescriptionTextEdit.Enabled = true;
            IDTextEdit.Enabled = true;
            IDTextEdit.Focus();
            GV_DeliveryDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

        }

        private void refresh()
        {
            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            db = new dotNET_FinalProjectEntities();
            db.Deliveries.Load();
            db.Agencies.Load();
            db.Products.Load();
            
            repositoryProduct.DataSource = db.Products.Local;
            deliveryBindingSource.DataSource = db.Deliveries.Local;
            billBindingSource.DataSource = db.Bills.Local;
            agencyBindingSource.DataSource = db.Agencies.Local;
            employeeBindingSource.DataSource = db.Employees.Local;
            btnSave.Enabled = false;
        }

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh();
        }

        private void GV_DeliveryDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            deliveryDetailBindingSource.AddNew();
            DateTime now = DateTime.Now;
            long uniqueNumber = now.Ticks % 1000000;
            string DeliveryDTID = "DLV-" + uniqueNumber.ToString();
            GV_DeliveryDetail.SetRowCellValue(e.RowHandle, "DeliveryID", IDTextEdit.Text);
            GV_DeliveryDetail.SetRowCellValue(e.RowHandle, "ID", DeliveryDTID);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AngencyIDTextEdit.Enabled = false;
            DeliveryDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false;

            colProductID.OptionsColumn.AllowEdit = true;
            colDelete.OptionsColumn.AllowEdit = true;
            colQuantity.OptionsColumn.AllowEdit = true;

            GV_DeliveryDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            var deliveryDetail = db.DeliveryDetails.Where(x => x.DeliveryID == IDTextEdit.Text).ToList();
            DeliveryDetailsGridControl.DataSource = new BindingList<DeliveryDetail>(deliveryDetail);

            btnAddItem.Enabled = false;
            btnSave.Enabled = true;
            colProductID.OptionsColumn.AllowEdit = true;
            deliveryBindingSource.EndEdit();

            Delivery delivery = deliveryBindingSource.Current as Delivery;
            delivery.EmployeeID = Program.userID;
            delivery.TotalAmount = 0;
            if (delivery != null)
            {
                if (delivery.Ivalid)
                {
                    IDTextEdit.Enabled = false;
                    db.SaveChanges();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            deliveryBindingSource.EndEdit();
            Delivery delivery = deliveryBindingSource.Current as Delivery;
            delivery.EmployeeID = Program.userID;
            if (delivery != null)
            {
                if (delivery.Ivalid)
                {
                    db.SaveChanges();
                    XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    colProductID.OptionsColumn.AllowEdit = false;
                    colDelete.OptionsColumn.AllowEdit = false;
                    colQuantity.OptionsColumn.AllowEdit = false;
                    btnSave.Enabled = false;
                    refresh();
                }
            }
            else
            {
                XtraMessageBox.Show("Please chooes product !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barBtn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure want to delete this order? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deliveryBindingSource.RemoveCurrent();
                db.SaveChanges();
                XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                colProductID.OptionsColumn.AllowEdit = false;
                colDelete.OptionsColumn.AllowEdit = false;
                colQuantity.OptionsColumn.AllowEdit = false;
                btnSave.Enabled = false;
                btnAddItem.Enabled = false;
            }
        }

        private void GV_DeliveryDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridColumn colQuantity = GV_DeliveryDetail.Columns["Quantity"];
            int quantity = Convert.ToInt16(GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.FocusedRowHandle, colQuantity));

            GridColumn colProduct = GV_DeliveryDetail.Columns["ProductID"];
            String productID = GV_DeliveryDetail.GetRowCellValue(GV_DeliveryDetail.FocusedRowHandle, colProduct).ToString();
            Product product = db.Products.Where(x => x.ID == productID).FirstOrDefault(); 

            if (quantity < 1)
            {
                GV_DeliveryDetail.SetColumnError(colQuantity, "Quantity Invalid");
                e.Valid = false;
                e.ErrorText = "Quantity Invalid";
            } else if (quantity > product.Quantity)
            {
                GV_DeliveryDetail.SetColumnError(colQuantity, "Out of Stock");
                e.Valid = false;
                e.ErrorText = "This product is currently out of stock";
            }
            
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"Are you sure want to delete {(GV_DeliveryDetail.GetFocusedRow() as DeliveryDetail).ID}? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedRowHandle = GV_DeliveryDetail.FocusedRowHandle;
                GV_DeliveryDetail.DeleteRow(selectedRowHandle);
            }
        }

        private void GV_Delivery_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            AngencyIDTextEdit.Enabled = false;
            DeliveryDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Delivery.ExportToCsv(sf.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Delivery currentDelivery = deliveryBindingSource.Current as Delivery;
            if (currentDelivery != null)
            {
                using (frmPrint frm = new frmPrint())
                {
                    List<DeliveryDetail> data = db.DeliveryDetails.Where(x => x.DeliveryID == currentDelivery.ID).ToList();
                    frm.PrintDevivery(data);
                    frm.ShowDialog();
                }
            }
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            Delivery delivery = deliveryBindingSource.Current as Delivery;
            if (delivery != null)
            {
                DateTime now = DateTime.Now;
                long uniqueNumber = now.Ticks % 10000000;
                string ID = "BL-" + uniqueNumber.ToString();
                Bill bill = new Bill()
                {
                    ID = ID,
                    DeliveryID = delivery.ID,
                    AgencyID = delivery.AngencyID,
                    EmployeeID = delivery.EmployeeID,
                    TotalAmount = delivery.TotalAmount,
                    BillDate = now,
                };
                var existBill = db.Bills.Where(x => x.DeliveryID == bill.DeliveryID).FirstOrDefault();
                if (existBill == null)
                {
                    billBindingSource.Add(bill);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Current order has been genarated a bill");
                }
            }
        }

        private void repositoryProduct_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void GV_DeliveryDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            
            
        }
    }
}
