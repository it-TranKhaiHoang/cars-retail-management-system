namespace FinalProject
{
    partial class Dashboard2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Measure measure2 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.ChartPane chartPane1 = new DevExpress.DashboardCommon.ChartPane();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries1 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries2 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.Measure measure3 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Card card1 = new DevExpress.DashboardCommon.Card();
            DevExpress.DashboardCommon.CardLightweightLayoutTemplate cardLightweightLayoutTemplate1 = new DevExpress.DashboardCommon.CardLightweightLayoutTemplate();
            DevExpress.DashboardCommon.Measure measure4 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Card card2 = new DevExpress.DashboardCommon.Card();
            DevExpress.DashboardCommon.CardLightweightLayoutTemplate cardLightweightLayoutTemplate2 = new DevExpress.DashboardCommon.CardLightweightLayoutTemplate();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure5 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup3 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem4 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.chartDashboardItem1 = new DevExpress.DashboardCommon.ChartDashboardItem();
            this.cardDashboardItem1 = new DevExpress.DashboardCommon.CardDashboardItem();
            this.cardDashboardItem2 = new DevExpress.DashboardCommon.CardDashboardItem();
            this.pieDashboardItem1 = new DevExpress.DashboardCommon.PieDashboardItem();
            this.dashboardObjectDataSource2 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // chartDashboardItem1
            // 
            dimension1.DataMember = "Delivery.DeliveryDate";
            dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month;
            this.chartDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1});
            this.chartDashboardItem1.AxisX.TitleVisible = false;
            this.chartDashboardItem1.ComponentName = "chartDashboardItem1";
            measure1.DataMember = "Delivery.ID";
            measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Count;
            measure2.DataMember = "Delivery.TotalAmount";
            this.chartDashboardItem1.DataItemRepository.Clear();
            this.chartDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.chartDashboardItem1.DataItemRepository.Add(measure1, "DataItem1");
            this.chartDashboardItem1.DataItemRepository.Add(measure2, "DataItem2");
            this.chartDashboardItem1.DataSource = this.dashboardObjectDataSource2;
            this.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.chartDashboardItem1.Name = "Employee Performance";
            chartPane1.Name = "Pane 1";
            chartPane1.PrimaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.PrimaryAxisY.ShowGridLines = true;
            chartPane1.PrimaryAxisY.TitleVisible = true;
            chartPane1.SecondaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.SecondaryAxisY.ShowGridLines = false;
            chartPane1.SecondaryAxisY.TitleVisible = true;
            simpleSeries1.Name = "Number of Delivery Note";
            simpleSeries1.AddDataItem("Value", measure1);
            simpleSeries2.Name = "Total Amount";
            simpleSeries2.AddDataItem("Value", measure2);
            chartPane1.Series.AddRange(new DevExpress.DashboardCommon.ChartSeries[] {
            simpleSeries1,
            simpleSeries2});
            this.chartDashboardItem1.Panes.AddRange(new DevExpress.DashboardCommon.ChartPane[] {
            chartPane1});
            this.chartDashboardItem1.ShowCaption = true;
            // 
            // cardDashboardItem1
            // 
            measure3.DataMember = "Delivery.TotalAmount";
            measure3.NumericFormat.CustomFormatString = "";
            cardLightweightLayoutTemplate1.BottomValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate1.BottomValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle;
            cardLightweightLayoutTemplate1.BottomValue.Visible = true;
            cardLightweightLayoutTemplate1.DeltaIndicator.Visible = true;
            cardLightweightLayoutTemplate1.MainValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate1.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue;
            cardLightweightLayoutTemplate1.MainValue.Visible = true;
            cardLightweightLayoutTemplate1.MaxWidth = 150;
            cardLightweightLayoutTemplate1.MinWidth = 100;
            cardLightweightLayoutTemplate1.Sparkline.Visible = true;
            cardLightweightLayoutTemplate1.SubValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate1.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title;
            cardLightweightLayoutTemplate1.SubValue.Visible = true;
            card1.LayoutTemplate = cardLightweightLayoutTemplate1;
            card1.Name = "Total Amount";
            card1.AddDataItem("TargetValue", measure3);
            this.cardDashboardItem1.Cards.AddRange(new DevExpress.DashboardCommon.Card[] {
            card1});
            this.cardDashboardItem1.ComponentName = "cardDashboardItem1";
            this.cardDashboardItem1.DataItemRepository.Clear();
            this.cardDashboardItem1.DataItemRepository.Add(measure3, "DataItem0");
            this.cardDashboardItem1.DataSource = this.dashboardObjectDataSource2;
            this.cardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.cardDashboardItem1.Name = "Cards 1";
            this.cardDashboardItem1.ShowCaption = false;
            // 
            // cardDashboardItem2
            // 
            measure4.DataMember = "DeliveryID";
            measure4.NumericFormat.CustomFormatString = "";
            measure4.SummaryType = DevExpress.DashboardCommon.SummaryType.Count;
            cardLightweightLayoutTemplate2.BottomValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate2.BottomValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle;
            cardLightweightLayoutTemplate2.BottomValue.Visible = true;
            cardLightweightLayoutTemplate2.DeltaIndicator.Visible = true;
            cardLightweightLayoutTemplate2.MainValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate2.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue;
            cardLightweightLayoutTemplate2.MainValue.Visible = true;
            cardLightweightLayoutTemplate2.MaxWidth = 150;
            cardLightweightLayoutTemplate2.MinWidth = 100;
            cardLightweightLayoutTemplate2.Sparkline.Visible = false;
            cardLightweightLayoutTemplate2.SubValue.DimensionIndex = 0;
            cardLightweightLayoutTemplate2.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title;
            cardLightweightLayoutTemplate2.SubValue.Visible = true;
            card2.LayoutTemplate = cardLightweightLayoutTemplate2;
            card2.Name = "Number of Delivery Note";
            card2.AddDataItem("ActualValue", measure4);
            this.cardDashboardItem2.Cards.AddRange(new DevExpress.DashboardCommon.Card[] {
            card2});
            this.cardDashboardItem2.ComponentName = "cardDashboardItem2";
            this.cardDashboardItem2.DataItemRepository.Clear();
            this.cardDashboardItem2.DataItemRepository.Add(measure4, "DataItem0");
            this.cardDashboardItem2.DataSource = this.dashboardObjectDataSource2;
            this.cardDashboardItem2.InteractivityOptions.IgnoreMasterFilters = false;
            this.cardDashboardItem2.Name = "Cards 2";
            this.cardDashboardItem2.ShowCaption = false;
            // 
            // pieDashboardItem1
            // 
            dimension2.DataMember = "Product.Name";
            this.pieDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension2});
            this.pieDashboardItem1.ComponentName = "pieDashboardItem1";
            measure5.DataMember = "Quantity";
            this.pieDashboardItem1.DataItemRepository.Clear();
            this.pieDashboardItem1.DataItemRepository.Add(dimension2, "DataItem0");
            this.pieDashboardItem1.DataItemRepository.Add(measure5, "DataItem1");
            this.pieDashboardItem1.DataSource = this.dashboardObjectDataSource2;
            this.pieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.pieDashboardItem1.Name = "Percent of Exports";
            this.pieDashboardItem1.ShowCaption = true;
            this.pieDashboardItem1.Values.AddRange(new DevExpress.DashboardCommon.Measure[] {
            measure5});
            // 
            // dashboardObjectDataSource2
            // 
            this.dashboardObjectDataSource2.ComponentName = "dashboardObjectDataSource2";
            this.dashboardObjectDataSource2.DataSource = typeof(FinalProject.DeliveryDetail);
            this.dashboardObjectDataSource2.Name = "Object Data Source 1";
            // 
            // Dashboard2
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource2});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.chartDashboardItem1,
            this.cardDashboardItem1,
            this.cardDashboardItem2,
            this.pieDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.cardDashboardItem2;
            dashboardLayoutItem1.Weight = 49.936467598475225D;
            dashboardLayoutItem2.DashboardItem = this.cardDashboardItem1;
            dashboardLayoutItem2.Weight = 50.063532401524775D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Weight = 40.428571428571431D;
            dashboardLayoutItem3.DashboardItem = this.pieDashboardItem1;
            dashboardLayoutItem3.Weight = 49.936467598475225D;
            dashboardLayoutItem4.DashboardItem = this.chartDashboardItem1;
            dashboardLayoutItem4.Weight = 50.063532401524775D;
            dashboardLayoutGroup3.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem3,
            dashboardLayoutItem4});
            dashboardLayoutGroup3.DashboardItem = null;
            dashboardLayoutGroup3.Weight = 59.571428571428569D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutGroup2,
            dashboardLayoutGroup3});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource2;
        private DevExpress.DashboardCommon.ChartDashboardItem chartDashboardItem1;
        private DevExpress.DashboardCommon.CardDashboardItem cardDashboardItem1;
        private DevExpress.DashboardCommon.CardDashboardItem cardDashboardItem2;
        private DevExpress.DashboardCommon.PieDashboardItem pieDashboardItem1;
    }
}
