using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        EgitimKampiFinancialCrmDbEntities db = new EgitimKampiFinancialCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            decimal? isBankBalance = db.Banks.Where(x => x.Title == "İş Bankası").Select(x => x.Balance).FirstOrDefault();
            decimal? yapiKrediBalance = db.Banks.Where(x => x.Title == "Yapı Kredi").Select(x => x.Balance).FirstOrDefault();
            decimal? vakifbankBalance = db.Banks.Where(x => x.Title == "Vakıfbank").Select(x => x.Balance).FirstOrDefault();

            lblIsBankBalance.Text = isBankBalance.ToString() + " ₺";
            lblYapiKrediBalance.Text = yapiKrediBalance.ToString() + " ₺";
            lblVakıfbankBalance.Text = vakifbankBalance.ToString() + " ₺";

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            lblMetin1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.Id).Take(2).Skip(1).FirstOrDefault();
            lblMetin2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.Id).Take(3).Skip(2).FirstOrDefault();
            lblMetin3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.Id).Take(4).Skip(3).FirstOrDefault();
            lblMetin4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.Id).Take(4).Skip(3).FirstOrDefault();
            lblMetin5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;

            var bankProcess6 = db.BankProcesses.OrderByDescending(x => x.Id).Take(5).Skip(4).FirstOrDefault();
            lblMetin6.Text = bankProcess6.Description + " " + bankProcess6.Amount + " " + bankProcess6.ProcessDate;


        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Close();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
