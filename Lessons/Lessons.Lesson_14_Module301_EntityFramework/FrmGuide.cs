using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lessons.Lesson_14_Module301_EntityFramework
{
    public partial class FrmGuide : Form
    {
        public FrmGuide()
        {
            InitializeComponent();
        }

        EgitimKampiEntityFrameworkDbEntities context = new EgitimKampiEntityFrameworkDbEntities();

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            List<Guide> values = context.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
            };
            context.Guide.Add(guide);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Guide deletedValue = context.Guide.Find(id);
            context.Guide.Remove(deletedValue);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Guide updatedValue = context.Guide.Find(id);
            updatedValue.Name = txtName.Text;
            updatedValue.Surname = txtSurname.Text;
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Guide value = context.Guide.Where(x => x.Id == id).FirstOrDefault();
            dataGridView1.DataSource = value;
        }
    }
}
