using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        EgitimKampiFinancialCrmDbEntities db = new EgitimKampiFinancialCrmDbEntities();

        void GetAll()
        {
            List<Bills> values = db.Bills.ToList();
            var dataSource = values.Select(x => new
            {
                Id = x.Id,
                Ödeme_Adı = x.Title,
                Fiyatı = x.Amount,
                Periyot = x.Period
            }).ToList();
            dataGridView1.DataSource = dataSource;
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            Bills bills = new Bills()
            {
                Title = txtTitle.Text,
                Period = txtPeriod.Text,
                Amount = decimal.Parse(txtAmount.Text),
            };
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ekleme başarılı.", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAll();
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            Bills deleteValue = db.Bills.Find(int.Parse(txtId.Text));
            db.Bills.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Silme başarılı.", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAll();
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            Bills updateValue = db.Bills.Find(int.Parse(txtId.Text));
            updateValue.Title = txtTitle.Text;
            updateValue.Period = txtPeriod.Text;
            updateValue.Amount = decimal.Parse(txtAmount.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme başarılı.", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetAll();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Close();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
