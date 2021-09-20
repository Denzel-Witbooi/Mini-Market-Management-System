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
    public partial class ProductForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button_category_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            getCategory();
            getTable();
        }

        private void getCategory()  
        {      
            string selectQuery = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox_category.DataSource = table;
            comboBox_category.ValueMember = "CatName";
            comboBox_search.DataSource = table;
            comboBox_search.ValueMember = "CatName";

        }

        private void getTable()
        {
            string selectQuery = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }

        private void clear()
        {
            TextBox_id.Clear();
            TextBox_name.Clear();
            TextBox_price.Clear();
            TextBox_qty.Clear();
            comboBox_category.SelectedIndex = 0;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_price.Text == "" || TextBox_qty.Text == "" )
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insertQuery = "INSERT INTO Product VALUES(" + TextBox_id.Text + ",'" + TextBox_name.Text + "'," + TextBox_price.Text + ",'" + TextBox_qty.Text + "','" + comboBox_category.Text + "')";
                    SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Added Successfully!", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    getTable();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_price.Text == "" || TextBox_qty.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string updateQuery = "UPDATE Product SET ProdName='" + TextBox_name.Text + "', ProdPrice='" + TextBox_price.Text + "', ProdQty='" + TextBox_qty.Text + "', ProdCat='" + comboBox_category.Text + "'WHERE ProdId=" + TextBox_id.Text + "";
                    SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully!", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    getTable();
                    clear();                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_product_Click(object sender, EventArgs e)
        {
            TextBox_id.Text = DataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = DataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = DataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_qty.Text = DataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            comboBox_category.SelectedValue = DataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
        }
        private void label_logout_MouseEnter(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Red;
        }

        private void label_logout_MouseLeave(object sender, EventArgs e)
        {
            label_logout.ForeColor = Color.Goldenrod;
        }

        private void label_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string deleteQuery = "DELETE FROM Product WHERE ProdId=" + TextBox_id.Text + "";
                    SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully!", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    clear();
                    getTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void comboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Product WHERE ProdCat='"+comboBox_search.SelectedValue.ToString()+"'";
            SqlCommand command = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_product.DataSource = table;
        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }
    }
}
