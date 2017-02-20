using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sesprint1
{
    public partial class ModifyRoom : Form
    {
        public struct Node
        {
            public string roomName { get; set; }
            public double temperature { get; set; }
            public double Water { get; set; }
            public double SoilAcidity { get; set; }
            public double Humidity { get; set; }
            public double Fertilizer { get; set; }
            public double Lighting { get; set; }
            public double PlantBed { get; set; }
            public double cost { get; set; }
       }
        Node rm = new Node();
        public ModifyRoom(string roomName,double temperature,double Water,double Humidity,double SoilAcidity,double PlantBed,double Fertilizer,double Lighting,double cost)
        {
            InitializeComponent();
            try
            {
                this.Text = "Modify "+roomName.ToString() ;
                textBox1.Text = temperature.ToString();
                textBox2.Text = Water.ToString();
                textBox3.Text =Humidity.ToString();
                textBox4.Text = SoilAcidity.ToString();
                textBox5.Text = PlantBed.ToString();
                textBox6.Text = Fertilizer.ToString();
                textBox7.Text = Lighting.ToString();
                rm.roomName = roomName;
                rm.temperature = temperature;
                rm.Water = Water;
                rm.Humidity = Humidity;
                rm.SoilAcidity = SoilAcidity;
                rm.PlantBed = PlantBed;
                rm.Fertilizer = Fertilizer;
                rm.Lighting = Lighting;
                rm.cost = cost;
            }
            catch (Exception)
            {

            }
            
         }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            RoomList f1 = new RoomList();
          //  f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double t, w, h, so, p,f, l;
            Boolean errorFlag = false;
            try
            {
                t = Double.Parse(textBox1.Text);
                w = Double.Parse(textBox2.Text);

                h = Double.Parse(textBox3.Text);
                so = Double.Parse(textBox4.Text);
               p= Double.Parse(textBox5.Text);
               f = Double.Parse(textBox6.Text);
               l = Double.Parse(textBox7.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter double datatype values");
                errorFlag = true;

            }
            catch (NullReferenceException)
            {
                  textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
               // textBox8.Text = "";
            }
            if (errorFlag == false)
            {
                Node s = new Node();
                s.temperature = Double.Parse(textBox1.Text);
                s.Water = Double.Parse(textBox2.Text);
                s.Humidity = Double.Parse(textBox3.Text);
                s.SoilAcidity = Double.Parse(textBox4.Text);
                s.PlantBed = Double.Parse(textBox5.Text);
                s.Fertilizer = Double.Parse(textBox6.Text);
                s.Lighting = Double.Parse(textBox7.Text);
                s.roomName = rm.roomName;
                s.cost = rm.cost;
                MessageBox.Show("Room uptated successfully");
                this.Hide();
                Room f1 = new Room(s);
                Room f2 = new Room(s.roomName);
                f2.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomList f1 = new RoomList();
            f1.Show();
        }

        private void ModifyRoom_Load(object sender, EventArgs e)
        {

        }
    }
}