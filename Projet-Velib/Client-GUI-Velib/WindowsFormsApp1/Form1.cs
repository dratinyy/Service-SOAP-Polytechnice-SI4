using ApplicationGUI.WS_Soap_Velib_Reference;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Kauffmann_Client_Vélib : Form
    {
        private ServiceVelibClient serviceReference;
        private Composite_StationVelib[] stationList;
        private string selectedCity;
        private Composite_StationVelib selectedStation;

        public Kauffmann_Client_Vélib()
        {
            serviceReference = new ServiceVelibClient();
            InitializeComponent();
            foreach (Composite_City i in serviceReference.GetContracts())
                listBox1.Items.Add(i.Name + " [" + i.Country_code + "]");
            richTextBox1.ReadOnly = true;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.TabStop = false;
            richTextBox1.BackColor = Color.White;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCity = ((string)listBox1.SelectedItem).Substring(0, ((string)listBox1.SelectedItem).IndexOf(" "));
            stationList = serviceReference.GetAllInformationForContract(selectedCity);
            listBox2.Items.Clear();
            for (int k = 0; k < stationList.Length; k++)
            {
                listBox2.Items.Add(k + "\t[ " + stationList[k].Name + " ]");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                selectedStation = stationList[int.Parse(((string)listBox2.SelectedItem).Substring(0, ((string)listBox2.SelectedItem).IndexOf("\t")))];
                richTextBox1.Rtf =
                    @"{\rtf1\ansi \b Station :\b0\line " + selectedStation.Name
                    + @"\line\b Adresse :\b0\line " + selectedStation.Address
                    + @"\line\b Statut :\b0\line " + selectedStation.Status
                    + @"\line\b Vélos disponibles :\b0\line " + selectedStation.Available_bikes.ToString() + " sur " + selectedStation.Bike_stands.ToString()
                    + @"\line\b Emplacements libres :\b0\line " + selectedStation.Available_bike_stands.ToString() + " emplacements}";

                if (selectedStation.Address != string.Empty)
                {
                    googleMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                    GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                    googleMap.Zoom = 15;
                    googleMap.Position = new GMap.NET.PointLatLng(selectedStation.Position.Lat, selectedStation.Position.Lng);
                }
            }
        }

        private void googleMap_Load(object sender, EventArgs e)
        {

        }
    }
}
