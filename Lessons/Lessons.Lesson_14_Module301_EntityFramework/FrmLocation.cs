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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEntityFrameworkDbEntities context = new EgitimKampiEntityFrameworkDbEntities();

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            List<Location> values = context.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Location updatedValue = context.Location.Find(id);
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.GuideId = int.Parse(cbGuide.SelectedValue.ToString());
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Location deletedValue = context.Location.Find(id);
            context.Location.Remove(deletedValue);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location()
            {
                Capacity = byte.Parse(nudCapacity.Value.ToString()),
                City = txtCity.Text,
                Country = txtCountry.Text,
                DayNight = txtDayNight.Text,
                Price = decimal.Parse(txtPrice.Text),
                GuideId = int.Parse(cbGuide.SelectedValue.ToString())
            };
            context.Location.Add(location);
            context.SaveChanges();
            MessageBox.Show("İşlem Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = context.Guide.Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                x.Id
            }).ToList();
            cbGuide.DisplayMember = "FullName";
            cbGuide.ValueMember = "Id";
            cbGuide.DataSource = values;
        }
    }
}
