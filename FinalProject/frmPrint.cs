using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        public void PrintReceived(List<ReceivedDetail> data)
        {
            RP_Received report = new RP_Received();
            report.InitData(data);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        public void PrintDevivery(List<DeliveryDetail> data)
        {
            RP_Delivery report = new RP_Delivery();
            report.InitData(data);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}