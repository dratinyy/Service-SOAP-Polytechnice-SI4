using ApplicationGUI.WS_Soap_Velib_Reference;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ServiceClient serviceReference;
        private Composite_StationVelib[] stationList;

        public Form1()
        {
            serviceReference = new ServiceClient();
            InitializeComponent();
            foreach (Composite_City i in serviceReference.GetContracts())
                listBox1.Items.Add(i.Name + " [" + i.Country_code + "]");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = ((string)listBox1.SelectedItem).Substring(0, ((string)listBox1.SelectedItem).IndexOf(" "));
            stationList = serviceReference.GetAllInformationForContract(selectedCity);
            listBox2.Items.Clear();
            for(int k = 0; k < stationList.Length; k++)
            {
                listBox2.Items.Add(k + "\t[ " + stationList[k].Name + " ]");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Composite_StationVelib selectedStation = stationList[int.Parse(((string)listBox2.SelectedItem).Substring(0, ((string)listBox2.SelectedItem).IndexOf("\t")))];
                label3.Text = "Station :\n" + selectedStation.Name + "\n\nAdresse :\n" + selectedStation.Address + "\n\nStatut :\n" + selectedStation.Status + "\n\nVélos disponibles :\n"
                    + selectedStation.Available_bikes + " sur " + selectedStation.Bike_stands + "\n\nEmplacements libres :\n" + selectedStation.Available_bike_stands + " emplacements";
            }
        }
    }
}
