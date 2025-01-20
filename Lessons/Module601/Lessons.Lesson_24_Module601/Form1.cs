using Lessons.Lesson_24_Module601.Entities;
using Lessons.Lesson_24_Module601.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lessons.Lesson_24_Module601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations = new CustomerOperations();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                City = txtCity.Text,
                Balance = decimal.Parse(txtBalance.Text),
                ShoppingCount = int.Parse(txtShoppingCount.Text),
            };
            customerOperations.Add(customer);
            MessageBox.Show("Ekleme başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAll();
            dataGridView1.DataSource = customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            customerOperations.Delete(txtId.ToString());
            MessageBox.Show("Silme başarılı.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer updateCustomer = new Customer
            {
                Id = txtId.Text,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                City = txtCity.Text,
                Balance = decimal.Parse(txtBalance.Text),
                ShoppingCount = int.Parse(txtShoppingCount.Text),
            };
            customerOperations.Update(updateCustomer);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<Customer> { customerOperations.GetById(txtId.Text) };
        }
    }
}
