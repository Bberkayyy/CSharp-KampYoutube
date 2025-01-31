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
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        EgitimKampiFinancialCrmDbEntities db = new EgitimKampiFinancialCrmDbEntities();
        Random random = new Random();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.Balance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            var lastBankProcess = db.BankProcesses.OrderByDescending(x => x.Id).Take(1).Select(x => x.Amount).FirstOrDefault();
            lblLastBankProcess.Text = lastBankProcess.ToString() + " ₺";

            //chart1 (column)
            var bankData = db.Banks.Select(x => new { x.Title, x.Balance }).ToList();
            chartBanks.Series.Clear();
            chartBanks.Legends.Clear();
            chartBanks.Legends.Add(new Legend
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center
            });
            var chart1series = new Series
            {
                ChartType = SeriesChartType.Column,
                IsVisibleInLegend = false,
                IsValueShownAsLabel = true
            };
            foreach (var bank in bankData)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                int pointIndex = chart1series.Points.AddXY(bank.Title, bank.Balance);
                chart1series.Points[pointIndex].Color = randomColor;

                chartBanks.Legends[0].CustomItems.Add(new LegendItem
                {
                    Name = bank.Title,
                    Color = randomColor,
                    BorderColor = randomColor,
                });
            }
            chartBanks.Series.Add(chart1series);

            //chart2 (pie)
            var billData = db.Bills.Select(x => new { x.Title, x.Amount }).ToList();
            chartBills.Series.Clear();
            chartBills.Legends.Clear();
            chartBills.Legends.Add(new Legend
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center
            });
            var chart2series = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsVisibleInLegend = false,
                IsValueShownAsLabel = true
            };
            foreach (var bank in bankData)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                int pointIndex = chart2series.Points.AddXY(bank.Title, bank.Balance);
                chart2series.Points[pointIndex].Color = randomColor;

                chartBills.Legends[0].CustomItems.Add(new LegendItem
                {
                    Name = bank.Title,
                    Color = randomColor,
                    BorderColor = randomColor,
                });
            }
            chartBills.Series.Add(chart2series);
        }

        private void timerBill_Tick(object sender, EventArgs e)
        {
            var bills = db.Bills.Select(x => new { x.Title, x.Amount }).ToList();
            if (bills.Count == 0) return;

            var bill = bills[count % bills.Count];
            lblBillTitle.Text = bill.Title;
            lblBillAmount.Text = $"{bill.Amount} ₺";

            count++;
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Close();
        }

        private void btnBilling_Click(object sender, EventArgs e)
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
            this.Show();
        }
    }
}
