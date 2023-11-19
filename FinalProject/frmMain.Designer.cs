namespace FinalProject
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Agency = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Supplier = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Received = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Delivery = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Product = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Employee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_User = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Profile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.control_Logout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(375, 46);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(661, 645);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement1,
            this.accordionControlElement5,
            this.control_Product,
            this.control_Employee,
            this.control_User});
            this.accordionControl1.Location = new System.Drawing.Point(0, 46);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(375, 645);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ImageOptions.Image = global::FinalProject.Properties.Resources.business_report;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Dashboard";
            this.accordionControlElement2.Click += new System.EventHandler(this.accordionControlElement2_Click_1);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.control_Agency,
            this.control_Supplier});
            this.accordionControlElement1.ImageOptions.Image = global::FinalProject.Properties.Resources.team_friends_partners_partner_icon_153084;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Partner";
            // 
            // control_Agency
            // 
            this.control_Agency.ImageOptions.Image = global::FinalProject.Properties.Resources.new_car;
            this.control_Agency.Name = "control_Agency";
            this.control_Agency.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Agency.Text = "Agency";
            this.control_Agency.Click += new System.EventHandler(this.control_Agency_Click);
            // 
            // control_Supplier
            // 
            this.control_Supplier.ImageOptions.Image = global::FinalProject.Properties.Resources.showroom;
            this.control_Supplier.Name = "control_Supplier";
            this.control_Supplier.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Supplier.Text = "Supplier";
            this.control_Supplier.Click += new System.EventHandler(this.control_Applier_Click);
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.control_Received,
            this.control_Delivery});
            this.accordionControlElement5.ImageOptions.Image = global::FinalProject.Properties.Resources.logistics;
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Text = "Import-Export";
            // 
            // control_Received
            // 
            this.control_Received.ImageOptions.Image = global::FinalProject.Properties.Resources.down_arrows;
            this.control_Received.Name = "control_Received";
            this.control_Received.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Received.Text = "Received";
            this.control_Received.Click += new System.EventHandler(this.accordionControlElement2_Click);
            // 
            // control_Delivery
            // 
            this.control_Delivery.ImageOptions.Image = global::FinalProject.Properties.Resources.fast_delivery__1_;
            this.control_Delivery.Name = "control_Delivery";
            this.control_Delivery.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Delivery.Text = "Delivery";
            this.control_Delivery.Click += new System.EventHandler(this.control_Delivery_Click);
            // 
            // control_Product
            // 
            this.control_Product.ImageOptions.Image = global::FinalProject.Properties.Resources.traffic_jam;
            this.control_Product.Name = "control_Product";
            this.control_Product.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Product.Text = "Product";
            this.control_Product.Click += new System.EventHandler(this.control_Product_Click);
            // 
            // control_Employee
            // 
            this.control_Employee.ImageOptions.Image = global::FinalProject.Properties.Resources.division;
            this.control_Employee.Name = "control_Employee";
            this.control_Employee.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Employee.Text = "Employee";
            this.control_Employee.Click += new System.EventHandler(this.control_Employee_Click);
            // 
            // control_User
            // 
            this.control_User.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.control_Profile,
            this.control_Logout});
            this.control_User.Expanded = true;
            this.control_User.ImageOptions.Image = global::FinalProject.Properties.Resources.profile;
            this.control_User.Name = "control_User";
            this.control_User.Text = "User";
            // 
            // control_Profile
            // 
            this.control_Profile.ImageOptions.Image = global::FinalProject.Properties.Resources.profile__1_;
            this.control_Profile.Name = "control_Profile";
            this.control_Profile.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Profile.Text = "Profile";
            this.control_Profile.Click += new System.EventHandler(this.control_Profile_Click);
            // 
            // control_Logout
            // 
            this.control_Logout.ImageOptions.Image = global::FinalProject.Properties.Resources.logout__1_;
            this.control_Logout.Name = "control_Logout";
            this.control_Logout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.control_Logout.Text = "Log Out";
            this.control_Logout.Click += new System.EventHandler(this.control_Logout_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1036, 46);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 691);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.Image = global::FinalProject.Properties.Resources.Screenshot_2023_02_23_215747_removebg_preview1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.Text = "KHAI HOANG AUTO";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Product;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Supplier;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Agency;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Employee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Received;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Delivery;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_User;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Logout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement control_Profile;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
    }
}