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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void CategoryList()
        {
            List<Category> categories = _categoryService.TGetAll();
            dataGridView1.DataSource = categories;
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category()
            {
                Name = txtName.Text,
                Status = rbActive.Checked ? true : rbPassive.Checked ? false : false,
            };
            _categoryService.TInsert(category);
            MessageBox.Show("Başarıyla eklendi.");
            CategoryList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category deletedValues = _categoryService.TGetById(int.Parse(txtId.Text));
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Başarıyla silindi.");
            CategoryList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            Category value = _categoryService.TGetById(int.Parse(txtId.Text));
            dataGridView1.DataSource = new List<Category> { value };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updatedValue = _categoryService.TGetById(int.Parse(txtId.Text));
            updatedValue.Name = txtName.Text;
            updatedValue.Status = rbActive.Checked || (rbPassive.Checked && false);
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Başarıyla güncellendi.");
            CategoryList();
        }
    }
}
