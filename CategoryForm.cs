using System;
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
    public partial class CategoryForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try  
            {
                string insertQuery = "INSERT INTO Category VALUES(" + TextBox_id.Text + ",'" + TextBox_name.Text + "','" + TextBox_description.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully!");
                dBCon.CloseCon();
            } 
            catch (Exception ex)  
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
