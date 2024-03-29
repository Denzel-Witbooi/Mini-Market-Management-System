﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Market_Management_System
{
    public partial class LoginForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
        }

        private void label_clear_MouseEnter(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Red;
        }

        private void label_clear_MouseLeave(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Goldenrod;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            TextBox_username.Clear();
            TextBox_password.Clear();
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (comboBox_role.SelectedItem.ToString() == "ADMIN")
            {
                if (TextBox_username.Text == "Admin" || TextBox_password.Text == "Admin123")
                {
                    ProductForm product = new ProductForm();
                    product.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("If you are Admin, Please Enter the correct Id and Password","Missing Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                string selectQuery = "SELECT * FROM Seller WHERE SellerName='" + TextBox_username.Text + "' AND SellerPass='" + TextBox_password.Text + "'";
                
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery,dBCon.GetCon());
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    SellingForm selling = new SellingForm();
                    selling.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or password","Wrong Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
