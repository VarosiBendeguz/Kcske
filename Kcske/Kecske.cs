using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Kcske
{
    public class Kecske:UserControl
    {
        private Label nameLabel;
        private Label weightLabel;
        private Label ageLabel;
        private Label genderLabel;
        private Button button1;
        private Label heightLabel;

        int id = -1;

        public Kecske(KecskeClass oneKecske)
        {
            InitializeComponent();
            id = oneKecske.id;
            button1.Click += buttonClick;
            nameLabel.Text += oneKecske.nev;
            weightLabel.Text += oneKecske.suly;
            ageLabel.Text += oneKecske.honapos;
            genderLabel.Text += oneKecske.nem;
            heightLabel.Text += oneKecske.magassag;
        }
        async void buttonClick(object s, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "http://127.1.1.1:3000/allat/" + id;
            var jsonObject = new
            {
                id = this.id
            };
            string jsonString = JsonConvert.SerializeObject(jsonObject);
            StringContent data = new StringContent(jsonString, Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            this.Dispose();
        }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(27, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(30, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Név:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(27, 56);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(30, 13);
            this.weightLabel.TabIndex = 1;
            this.weightLabel.Text = "Súly:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(27, 83);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(26, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Kor:";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(27, 120);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(32, 13);
            this.genderLabel.TabIndex = 3;
            this.genderLabel.Text = "Nem:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(27, 152);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(59, 13);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Magasság:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Levágás";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Kecske
            // 
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "Kecske";
            this.Size = new System.Drawing.Size(127, 209);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
