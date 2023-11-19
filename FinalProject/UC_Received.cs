using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
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
    public partial class UC_Received : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_Received()
        {
            InitializeComponent();
        }
        dotNET_FinalProjectEntities db;
        
        private void UC_Received_Load(object sender, EventArgs e)
        {
            db = new dotNET_FinalProjectEntities();
            db.Receiveds.Load();
            db.Suppliers.Load();
            db.Products.Load();
            db.Employees.Load();
            receivedBindingSource.DataSource = db.Receiveds.Local;
            supplierBindingSource.DataSource = db.Suppliers.Local;
            employeeBindingSource.DataSource = db.Employees.Local;

            // Load data to grid look up edit
            repositoryProduct.DataSource = db.Products.Local;
            repositoryProduct.ValueMember = "ID";
            repositoryProduct.DisplayMember = "Name";
            repositoryProduct.NullText = @"Choose Product";
            colProID.ColumnEdit = repositoryProduct;

            GV_ReceivedDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            SupplierIDTextEdit.Enabled = false;
            ReceivedDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false;
        }

        private void refresh()
        {
            
            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            db = new dotNET_FinalProjectEntities();
            db.Receiveds.Load();
            db.Suppliers.Load();
            db.Products.Load();

            repositoryProduct.DataSource = db.Products.Local;
            receivedBindingSource.DataSource = db.Receiveds.Local;
            supplierBindingSource.DataSource = db.Suppliers.Local;
            employeeBindingSource.DataSource = db.Employees.Local;
            btnSave.Enabled = false;
            
            
        }

        private void barBtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            receivedDetailBindingSource.AddNew();
            receivedBindingSource.AddNew();
            DateTime now = DateTime.Now;
            long uniqueNumber = now.Ticks % 1000000;
            string ReceivedDTID = "RID-" + uniqueNumber.ToString();
            IDTextEdit.Text= ReceivedDTID;
            
            btnSave.Enabled = true;
            btnAddItem.Enabled = true;

            SupplierIDTextEdit.Enabled = true;
            ReceivedDateDateEdit.Enabled = true;
            DescriptionTextEdit.Enabled = true;
            IDTextEdit.Enabled = true;
            IDTextEdit.Focus();
            GV_ReceivedDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

        }

        

        private void barBtn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refresh();
        }

        private void GV_ReceivedDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            receivedDetailBindingSource.AddNew();
            DateTime now = DateTime.Now;
            long uniqueNumber = now.Ticks % 1000000;
            string ReceivedDTID = "RDT-" + uniqueNumber.ToString();
            GV_ReceivedDetail.SetRowCellValue(e.RowHandle, "ReceivedID", IDTextEdit.Text);
            GV_ReceivedDetail.SetRowCellValue(e.RowHandle, "ID", ReceivedDTID);

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            SupplierIDTextEdit.Enabled = false;
            ReceivedDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false;

            repositoryProduct.DataSource = db.Products.Where(x => x.SupplierID == SupplierIDTextEdit.EditValue.ToString()).ToList();

            colProductID.OptionsColumn.AllowEdit = true;
            colDelete.OptionsColumn.AllowEdit = true;
            colQuantity.OptionsColumn.AllowEdit = true;

            GV_ReceivedDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            var receivedDetail = db.ReceivedDetails.Where(x => x.ReceivedID == IDTextEdit.Text).ToList();
            ReceivedDetailsGridControl.DataSource = new BindingList<ReceivedDetail>(receivedDetail);
            
            btnAddItem.Enabled = false;
            btnSave.Enabled = true;
            colProductID.OptionsColumn.AllowEdit = true;
            receivedBindingSource.EndEdit();

            Received received = receivedBindingSource.Current as Received;
            received.EmployeeID = Program.userID;
            received.TotalAmount = 0;
            if (received != null)
            {
                if (received.Ivalid)
                {
                    IDTextEdit.Enabled = false;
                    db.SaveChanges();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            receivedBindingSource.EndEdit();
            Received received = receivedBindingSource.Current as Received;
            received.EmployeeID = Program.userID;
            if (received != null)
            {
                if (received.Ivalid)
                {
                    db.SaveChanges();
                    XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    colProductID.OptionsColumn.AllowEdit = false;
                    colDelete.OptionsColumn.AllowEdit = false;
                    colQuantity.OptionsColumn.AllowEdit = false;
                    btnSave.Enabled = false;
                    refresh();  
                }
            } else
            {
                XtraMessageBox.Show("Please chooes product !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barBtn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure want to delete this order? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                receivedBindingSource.RemoveCurrent();
                db.SaveChanges();
                XtraMessageBox.Show("Your data has been successfully saved !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                colProductID.OptionsColumn.AllowEdit = false;
                colDelete.OptionsColumn.AllowEdit = false;
                colQuantity.OptionsColumn.AllowEdit = false;
                btnSave.Enabled = false;
                btnAddItem.Enabled = false;
            }
        }
        private void GV_ReceivedDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridColumn colQuantity = GV_ReceivedDetail.Columns["Quantity"];
            int quantity = Convert.ToInt16(GV_ReceivedDetail.GetRowCellValue(GV_ReceivedDetail.FocusedRowHandle, colQuantity));

            if (quantity < 1)
            {
                GV_ReceivedDetail.SetColumnError(colQuantity, "Quantity Invalid");
                e.Valid = false;
                e.ErrorText = "Quantity Invalid";
            }

        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"Are you sure want to delete {(GV_ReceivedDetail.GetFocusedRow() as ReceivedDetail).ID}? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedRowHandle = GV_ReceivedDetail.FocusedRowHandle;
                GV_ReceivedDetail.DeleteRow(selectedRowHandle);
            }
        }

        private void GV_Received_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            colProductID.OptionsColumn.AllowEdit = false;
            colDelete.OptionsColumn.AllowEdit = false;
            colQuantity.OptionsColumn.AllowEdit = false;

            SupplierIDTextEdit.Enabled = false;
            ReceivedDateDateEdit.Enabled = false;
            DescriptionTextEdit.Enabled = false;
            IDTextEdit.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "CSV file(.csv) | *.csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GV_Received.ExportToCsv(sf.FileName);
            }
        }

        // Print Received Note
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Received currentReceived = receivedBindingSource.Current as Received;
            if (currentReceived != null)
            {
                using (frmPrint frm = new frmPrint())
                {
                    List<ReceivedDetail> data = db.ReceivedDetails.Where(x => x.ReceivedID == currentReceived.ID).ToList();
                    frm.PrintReceived(data);
                    frm.ShowDialog();
                }
            }
        }

        
    }
}
