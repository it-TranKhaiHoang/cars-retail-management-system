using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace FinalProject
{
    public partial class RP_Received : DevExpress.XtraReports.UI.XtraReport
    {
        public RP_Received()
        {
            InitializeComponent();
        }

        public void InitData(List<ReceivedDetail> data)
        {
            bindingSource1.DataSource = data;
        }

    }
}
