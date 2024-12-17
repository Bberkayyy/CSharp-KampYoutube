using Lessons.Lesson_11_Module301_BusinessLayer.Abstract;
using Lessons.Lesson_11_Module301_BusinessLayer.Concrete;
using Lessons.Lesson_11_Module301_DataAccessLayer.EntityFramework;
using Lessons.Lesson_11_Module301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lessons.Lesson_11_Module301_PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void ProductList()
        {
            List<object> products = _productService.TGetProductsWithCategories();
            dataGridView1.DataSource = products;
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product deletedValue = _productService.TGetById(int.Parse(txtId.Text));
            _productService.TDelete(deletedValue);
            MessageBox.Show("Başarıyla silindi.");
            ProductList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                CategoryId = int.Parse(cbCategory.SelectedValue.ToString()),
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = int.Parse(txtStock.Text),
                Description = txtDescription.Text,
            };
            _productService.TInsert(product);
            MessageBox.Show("Başarıyla eklendi.");
            ProductList();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            List<Category> categories = _categoryService.TGetAll();
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product updatedValue = _productService.TGetById(int.Parse(txtId.Text));
            updatedValue.CategoryId = int.Parse(cbCategory.SelectedValue.ToString());
            updatedValue.Name = txtName.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.Stock = int.Parse(txtStock.Text);
            updatedValue.Description = txtDescription.Text;
            _productService.TUpdate(updatedValue);
            MessageBox.Show("Başarıyla güncellendi.");
            ProductList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            Product value = _productService.TGetById(int.Parse(txtId.Text));
            dataGridView1.DataSource = new List<Product> { value };
        }
    }
}
