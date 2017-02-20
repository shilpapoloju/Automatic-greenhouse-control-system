using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sesprint1
{
    public partial class Optimal_Values : Form
    {
        public struct Node
        {
            public string roomName { get; set; }
            public double O_Vtemperature { get; set; }
            public double O_VWater { get; set; }
            public double O_VSoilAcidity { get; set; }
            public double O_VHumidity { get; set; }
            public double O_VFertilizer { get; set; }
            public double O_VLighting { get; set; }
            public double O_VPlantBed { get; set; }
        }
        Double count;
        public Optimal_Values()
        {
           
            InitializeComponent();
            var file = new StreamReader(File.OpenRead(@"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\count.csv"));
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                count = Double.Parse(line);
               

            }
            file.Close();
        }

        private void Optimal_Values_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\count.csv";

            List<string> example = new List<string>();
           
            example.Add(count.ToString());
                                     
            File.WriteAllLines(file, example);
            Boolean errorFlag = false;
            var rm = new Node();
            try
            {
                rm.roomName = textBox1.Text;
                rm.O_Vtemperature = Double.Parse(textBox2.Text);
                rm.O_VWater = Double.Parse(textBox3.Text);
               rm. O_VHumidity = Double.Parse(textBox4.Text);
               rm.O_VSoilAcidity = Double.Parse(textBox5.Text);
                rm.O_VPlantBed = Double.Parse(textBox6.Text);
                rm.O_VFertilizer = Double.Parse(textBox7.Text);
                rm.O_VLighting = Double.Parse(textBox8.Text);
                if (rm.roomName=="")
                {
                    rm.roomName = "room" +count;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter double datatype values");
                errorFlag = true;

            }
            catch (NullReferenceException)
            {
             //   textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            if (errorFlag == false)
            {

                MessageBox.Show("Room added successfully");
                this.Hide();
                
                RoomList f1 = new RoomList();
                Room f2 = new Room(rm);
                f1.createnode(rm.roomName);
                f1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomList f1 = new RoomList();

            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomList f1 = new RoomList();

            f1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
