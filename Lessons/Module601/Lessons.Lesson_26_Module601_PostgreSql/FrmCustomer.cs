using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lessons.Lesson_26_Module601_PostgreSql
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        NpgsqlConnection connection = new NpgsqlConnection("Server = localhost ; port = 5432 ; Database = CSharpKampYoutube ; user Id = postgres ; Password = 12345");

        void GetAll()
        {
            connection.Open();
            string query = "select * from Customers order by Id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "insert into Customers (Name,Surname,City) values (@name,@surname,@city)";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@surname", txtSurname.Text);
            command.Parameters.AddWithValue("@city", txtCity.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme başarılı");
            connection.Close();
            GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "delete from Customers where Id = @id";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            command.ExecuteNonQuery();
            MessageBox.Show("Silme başarılı");
            connection.Close();
            GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "update Customers set Name = @name, Surname = @surname, City = @city where Id = @id";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@surname", txtSurname.Text);
            command.Parameters.AddWithValue("@city", txtCity.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme başarılı");
            connection.Close();
            GetAll();
        }
    }
}
