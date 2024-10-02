using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Zadanie15_2_Tarasenkov
{
    public partial class Form1 : Form
    {
        private MonthCalendar Calendar_of_year;
        private MonthCalendar Calendar_of_easters;
        private int selectedYear;

        public Form1()
        {
            InitializeComponent();
            Calendar_of_year = monthCalendar1;
            Calendar_of_easters = monthCalendar2;
            selectedYear = DateTime.Now.Year;
            Calendar_of_year.ShowToday = false;
            Calendar_of_year.MaxSelectionCount = 1;
            Calendar_of_easters.MaxSelectionCount = 1;
            Calendar_of_year.DateChanged += Calendar_of_year_DateChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Задание №15. Тарасенков А.Д. Календарь Пасхи";
        }

        private void Calendar_of_year_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedYear = Calendar_of_year.SelectionRange.Start.Year; Calendar_of_easters.RemoveAllBoldedDates();
            string[] weekendDays = File.ReadAllLines("Days_of_Easters.txt");
            foreach (string day in weekendDays)
            {
                DateTime date = DateTime.ParseExact(day, "dd.MM.yyyy", null);

                if (date.Year == selectedYear)
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Calendar_of_easters.AddBoldedDate(date);
                    }
                }
            }
            Calendar_of_easters.SetDate(new DateTime(selectedYear, 1, 1));
        }
    }
}