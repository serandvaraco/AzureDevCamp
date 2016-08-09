using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Blueyonder.Companion.Entities;

namespace Blueyonder.Desktop.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient c = new HttpClient();

            c.BaseAddress = new Uri("http://localhost:61986/");
            var _value = c.GetAsync("locations/1").Result;


            if (_value.IsSuccessStatusCode)
            {

                var response = _value.Content.ReadAsStringAsync().Result;

                var objects = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationDTO>(response);


                dataGridView1.DataSource = new List<LocationDTO>() { objects };
            }

        }
    }
}
