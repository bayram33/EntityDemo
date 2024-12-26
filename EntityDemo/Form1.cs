using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal productDal = new ProductDal();
        public void BringAllProduct()
        {
            dgwProduct.DataSource = productDal.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BringAllProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                Name = txtName.Text,
                UnitPrice = Convert.ToInt32(txtPrice.Text),
                StockAmount = Convert.ToInt32(txtAmount.Text),

            });
            MessageBox.Show("Added the Product");
            BringAllProduct();
        }

        private void dgwProduct_Click(object sender, EventArgs e)
        {
            txtNameUpdate.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            txtPriceUpdate.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            txtAmountUIpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product
            {

                Id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                Name = txtNameUpdate.Text,
                StockAmount = Convert.ToInt32(txtAmountUIpdate.Text),
                UnitPrice = Convert.ToInt32(txtPriceUpdate.Text),

            });
            BringAllProduct();
            MessageBox.Show("Updated!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDal.Delete(
                new Product
                {
                    Id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                });
            BringAllProduct() ;
            MessageBox.Show("Deleted!");

        }



        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

            var result= productDal.GetAll().Where(p=>p.Name.Contains(tbxSearch.Text)).ToList();
            dgwProduct.DataSource = result;
            
        }
    }
}
