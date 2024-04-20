using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoleKempingowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCalendar(GetcalendarGridView());
        }

        private DataGridView GetcalendarGridView()
        {
            return calendarGridView;
        }

        private void InitializeCalendar(DataGridView calendarGridView)
        {
            // Dodaj kolumny do kontrolki DataGridView
            for (int i = -30; i <= 30; i++)
            {
                var date = DateTime.Today.AddDays(i);
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month);
                string dayOfWeekName = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);

                calendarGridView.Columns.Add($"Day_{date.Day}", $"{monthName}\n{dayOfWeekName}\n{date.Day}");
                calendarGridView.Columns[calendarGridView.Columns.Count - 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ustaw szerokość komórki z numerem pokoju
            calendarGridView.RowHeadersWidth = 140; // Ustaw szerokość na dowolną wartość, która Ci odpowiada

            // Dodaj wiersze do kontrolki DataGridView
            for (int i = 0; i < 24; i++)
            {
                calendarGridView.Rows.Add();
                calendarGridView.Rows[i].HeaderCell.Value = $"1{i:00}";
            }
        }

        private void klienciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.klienciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'databaseDataSet.Parcele' . Możesz go przenieść lub usunąć.
            this.parceleTableAdapter.Fill(this.databaseDataSet.Parcele);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'databaseDataSet.Klienci' . Możesz go przenieść lub usunąć.
            this.klienciTableAdapter.Fill(this.databaseDataSet.Klienci);

        }
    }
}
