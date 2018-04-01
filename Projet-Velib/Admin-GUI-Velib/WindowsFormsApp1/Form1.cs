using ApplicationGUI.WS_Soap_Velib_Reference;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Kauffmann_Client_Admin_Vélib : Form
    {
        private ServiceMonitoringClient serviceReference;

        public Kauffmann_Client_Admin_Vélib()
        {
            serviceReference = new ServiceMonitoringClient();
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            totalClients.Titles.Add("Clients du service");
            totalClientRequests.Titles.Add("Requêtes au service");
            totalServerRequests.Titles.Add("Requêtes à Vélib WS");
            totalClients.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            totalClients.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            totalClientRequests.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            totalClientRequests.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            totalServerRequests.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            totalServerRequests.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value, end = dateTimePicker2.Value;
            totalClients.Series["Clients"].Points.Clear();
            totalClientRequests.Series["Requetes"].Points.Clear();
            totalServerRequests.Series["Requetes"].Points.Clear();
            if (start.CompareTo(end) < 0)
            {
                label2.Text = "Total : " + serviceReference.GetClientsBetweenDates(start, end).ToString();
                label3.Text = "Total : " + serviceReference.GetClientRequestsBetweenDates(start, end).ToString();
                label4.Text = "Total : " + serviceReference.GetJCDecauxRequestsBetweenDates(start, end).ToString();
                label6.Text = serviceReference.GetJCDecauxAverageResponseTime(start, end).Milliseconds.ToString() + " ms";

                TimeSpan delta = new TimeSpan((end-start).Ticks/21);
                for (int i = 0, temp; i < 20; i++)
                {
                    temp = serviceReference.GetClientsBetweenDates(start, start + delta);
                    totalClients.Series["Clients"].Points.AddXY("", temp.ToString());
                    temp = serviceReference.GetClientRequestsBetweenDates(start, start + delta);
                    totalClientRequests.Series["Requetes"].Points.AddXY("", temp.ToString());
                    temp = serviceReference.GetJCDecauxRequestsBetweenDates(start, start + delta);
                    totalServerRequests.Series["Requetes"].Points.AddXY("", temp.ToString());
                    start += delta;
                }
            }
        }
    }
}
