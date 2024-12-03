using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Kcske
{
    public partial class Form1 : Form
    {
        List<Kecske> kecskek = new List<Kecske>();
        public Form1()
        {
            InitializeComponent();
            Start();
            button1.Click += buttonClick;
        }
        async void Start()
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/allat";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string message = await response.Content.ReadAsStringAsync();
                List<KecskeClass> data = JsonConvert.DeserializeObject<List<KecskeClass>>(message);
                //listBox1.Items.Clear();
                panel1.Controls.Clear();
                kecskek.Clear();
                foreach(KecskeClass item in data)
                {
                    //listBox1.Items.Add($"Kecske neve: {item.nev}, kora: {item.honapos}, súlya: {item.suly}, magassága: {item.magassag}, neme: {item.nem}");
                    kecskek.Add(new Kecske(item));
                    int allwidth = kecskek[0].Width * kecskek.Count;
                    //int rowNum = allwidth / panel1.Width;
                    int kecskePerRow = panel1.Width / kecskek[0].Width * kecskek[0].Width;
                    int rowNum = (int)Math.Ceiling((double)allwidth / kecskePerRow);
                    panel1.Controls.Add(kecskek.Last());
                    kecskek.Last().Left = allwidth % kecskePerRow - kecskek[0].Width;
                    kecskek.Last().Top = (rowNum - 1) * kecskek[0].Height;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        async void buttonClick(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/allat";
            try
            {
                var jsonObject = new
                {
                    honapos = int.Parse(ageTextBox.Text),
                    magassag = int.Parse(heightTextBox.Text),
                    suly = int.Parse(sulyTextBox.Text),
                    nem = genderTextBox.Text,
                    nev = nevTextBox.Text
                };
                string jsonString = JsonConvert.SerializeObject(jsonObject);
                StringContent sendThis = new StringContent(jsonString,Encoding.UTF8,"application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                Start();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }
    }
}
