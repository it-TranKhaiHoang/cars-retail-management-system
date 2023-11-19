using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        UC_Product UC_Product;
        UC_Supplier UC_Supplier;
        UC_Agency UC_Agency;
        UC_Employee UC_Employee;
        UC_Delivery UC_Delivery;
        UC_Received UC_Received;
        UC_UserProfile UC_UserProfile;
        UC_Dashboard UC_Dashboard;
        UC_EmployeeDashBoard UC_EmployeeDashBoard;
        private void control_Product_Click(object sender, EventArgs e)
        {
            if ( UC_Product == null )
            {
                UC_Product= new UC_Product();
                UC_Product.Dock= DockStyle.Fill;
                mainContainer.Controls.Add( UC_Product );
                UC_Product.BringToFront();
            } else
            {
                UC_Product.BringToFront();
            }
        }

        private void control_Applier_Click(object sender, EventArgs e)
        {
            if (UC_Supplier == null)
            {
                UC_Supplier = new UC_Supplier();
                UC_Supplier.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Supplier);
                UC_Supplier.BringToFront();
            }
            else
            {
                UC_Supplier.BringToFront();
            }
        }

        private void control_Agency_Click(object sender, EventArgs e)
        {
            if (UC_Agency == null)
            {
                UC_Agency = new UC_Agency();
                UC_Agency.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Agency);
                UC_Agency.BringToFront();
            }
            else
            {
                UC_Agency.BringToFront();
            }
        }

        private void control_Employee_Click(object sender, EventArgs e)
        {
            if (UC_Employee == null)
            {
                UC_Employee = new UC_Employee();
                UC_Employee.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Employee);
                UC_Employee.BringToFront();
            }
            else
            {
                UC_Employee.BringToFront();
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (UC_Received == null)
            {
                UC_Received = new UC_Received();
                UC_Received.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Received);
                UC_Received.BringToFront();
            }
            else
            {
                UC_Received.BringToFront();
            }
        }

        private void control_Delivery_Click(object sender, EventArgs e)
        {
            if (UC_Delivery == null)
            {
                UC_Delivery = new UC_Delivery();
                UC_Delivery.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_Delivery);
                UC_Delivery.BringToFront();
            }
            else
            {
                UC_Delivery.BringToFront();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            if (Program.userPosition == "ADMIN")
            {
                if (UC_Dashboard == null)
                {
                    UC_Dashboard = new UC_Dashboard();
                    UC_Dashboard.Dock = DockStyle.Fill;
                    mainContainer.Controls.Add(UC_Dashboard);
                    UC_Dashboard.BringToFront();
                }
                else
                {
                    UC_Dashboard.BringToFront();
                }
            } else
            {
                accordionControlElement1.Visible= false;
                control_Employee.Visible= false;
                control_Product.Visible = false;
                if (UC_EmployeeDashBoard == null)
                {
                    UC_EmployeeDashBoard = new UC_EmployeeDashBoard();
                    UC_EmployeeDashBoard.Dock = DockStyle.Fill;
                    mainContainer.Controls.Add(UC_EmployeeDashBoard);
                    UC_EmployeeDashBoard.BringToFront();
                }
                else
                {
                    UC_EmployeeDashBoard.BringToFront();
                }
            }
        }


        private void control_Logout_Click(object sender, EventArgs e)
        {
            Program.userID = "";
            Program.userPosition = "";
            Application.Restart();
            
        }

        private void control_Profile_Click(object sender, EventArgs e)
        {
            if (UC_UserProfile == null)
            {
                UC_UserProfile = new UC_UserProfile();
                UC_UserProfile.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(UC_UserProfile);
                UC_UserProfile.BringToFront();
            }
            else
            {
                UC_UserProfile.BringToFront();
            }
        }

        private void accordionControlElement2_Click_1(object sender, EventArgs e)
        {
            if (Program.userPosition == "ADMIN")
            {
                if (UC_Dashboard == null)
                {
                    UC_Dashboard = new UC_Dashboard();
                    UC_Dashboard.Dock = DockStyle.Fill;
                    mainContainer.Controls.Add(UC_Dashboard);
                    UC_Dashboard.BringToFront();
                }
                else
                {
                    UC_Dashboard.BringToFront();
                }
            } else
            {
                if (UC_EmployeeDashBoard == null)
                {
                    UC_EmployeeDashBoard = new UC_EmployeeDashBoard();
                    UC_EmployeeDashBoard.Dock = DockStyle.Fill;
                    mainContainer.Controls.Add(UC_EmployeeDashBoard);
                    UC_EmployeeDashBoard.BringToFront();
                }
                else
                {
                    UC_EmployeeDashBoard.BringToFront();
                }
            }
            
        }
    }
}
