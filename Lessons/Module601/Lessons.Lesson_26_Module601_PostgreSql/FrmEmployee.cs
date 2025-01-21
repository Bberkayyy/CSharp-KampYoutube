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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
        NpgsqlConnection connection = new NpgsqlConnection("Server = localhost ; port = 5432 ; Database = CSharpKampYoutube ; user Id = postgres ; Password = 12345");

        void GetAllEmployees()
        {
            connection.Open();
            string query = "select * from Employees order by Id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
        void GetAllDepartments()
        {
            connection.Open();
            string query = "select * from Dempartments order by Id";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cbDepartment.DisplayMember = "Name";
            cbDepartment.ValueMember = "Id";
            cbDepartment.DataSource = dataTable;
            connection.Close();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            GetAllEmployees();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            GetAllEmployees();
            GetAllDepartments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "insert into Employees (Name,Surname,Salary,DepartmentId) values (@name,@surname,@salary,@departmentId)";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@surname", txtSurname.Text);
            command.Parameters.AddWithValue("@salary", decimal.Parse(txtSalary.Text));
            command.Parameters.AddWithValue("@departmentId", int.Parse(cbDepartment.SelectedValue.ToString()));
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme başarılı");
            connection.Close();
            GetAllEmployees();
        }
    }
}
