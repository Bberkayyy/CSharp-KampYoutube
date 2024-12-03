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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEntityFrameworkDbEntities context = new EgitimKampiEntityFrameworkDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = context.Location.Count().ToString();
            lblTotalCapacityCount.Text = context.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = context.Guide.Count().ToString();
            lblAvgCapacityCount.Text = context.Location.Average(x => x.Capacity).ToString();
            lblAvgLocationPrice.Text = context.Location.Average(x => x.Price)?.ToString("0.00");
            lblLastAddedCountry.Text = context.Location.OrderByDescending(x => x.Id).Select(x => x.Country).FirstOrDefault();
            lblCappadociaTourCapacity.Text = context.Location.Where(x => x.City == "Kapadokya").Select(x => x.Capacity).FirstOrDefault().ToString();
            lblTurkiyeTourAvgCapacity.Text = context.Location.Where(x => x.Country == "Türkiye").Average(x => x.Capacity).ToString();
            lblRomeGuideName.Text = (from location in context.Location
                                     join guide in context.Guide on location.GuideId equals guide.Id
                                     where location.City == "Roma"
                                     select guide.Name + " " + guide.Surname).FirstOrDefault();
            //lblRomeGuideName.Text = context.Location.
            //    Join(context.Guide,
            //    location => location.GuideId,
            //    guide => guide.Id,
            //    (location, guide) => new { location, guide }).Where(x => x.location.City == "Roma").Select(x => x.guide.Name + " " + x.guide.Surname).FirstOrDefault();
            lblMaxCapacityLocation.Text = context.Location.Where(x => x.Capacity == context.Location.Max(y => y.Capacity)).Select(x => x.City).FirstOrDefault();
            lblMaxPriceLocation.Text = context.Location.Where(x => x.Price == context.Location.Max(y => y.Price)).Select(x => x.City).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = context.Location.
                Join(context.Guide,
                location => location.GuideId,
                guide => guide.Id,
                (location, guide) => new { location, guide }).Where(x => x.guide.Name == "Ayşegül" && x.guide.Surname == "Çınar").Count().ToString();

        }
    }
}
