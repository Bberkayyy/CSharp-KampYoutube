using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        EgitimKampiFinancialCrmDbEntities db = new EgitimKampiFinancialCrmDbEntities();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users user = db.Users.Where(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text).FirstOrDefault();
            if (user is null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();

        }
    }
}
