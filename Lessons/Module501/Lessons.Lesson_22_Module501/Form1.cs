using Dapper;
using Lessons.Lesson_22_Module501.Dtos;
using Lessons.Lesson_22_Module501.Repositories;
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

namespace Lessons.Lesson_22_Module501
{
    public partial class Form1 : Form
    {
        private readonly IProductRepository _productRepository;
        public Form1()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = await _productRepository.GetAllAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            CreateProductDto createProductDto = new CreateProductDto()
            {
                Name = txtName.Text,
                Stock = int.Parse(txtStock.Text),
                Price = decimal.Parse(txtPrice.Text),
                CategoryName = txtCategory.Text,
            };
            await _productRepository.CreateAsync(createProductDto);
            MessageBox.Show("Başarıyla eklendi.");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await _productRepository.DeleteAsync(int.Parse(txtId.Text));
            MessageBox.Show("Başarıyla silindi.");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProductDto updateProductDto = new UpdateProductDto()
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = int.Parse(txtStock.Text),
                CategoryName = txtCategory.Text
            };
            await _productRepository.UpdateAsync(updateProductDto);
            MessageBox.Show("Başarıyla güncellendi.");
        }

        private async void btnGetById_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<ResultProductDto>() { await _productRepository.GetByIdAsync(int.Parse(txtId.Text)) };
        }
    }
}
