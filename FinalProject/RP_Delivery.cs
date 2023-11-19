using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FinalProject
{
    public partial class RP_Delivery : DevExpress.XtraReports.UI.XtraReport
    {
        public RP_Delivery()
        {
            InitializeComponent();
        }
        public void InitData(List<DeliveryDetail> data)
        {
            bindingSource1.DataSource = data;
        }
    }
}
