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
    public partial class Room : Form
    {
        Sensor sen = new Sensor();
        //private RoomList.Node n;
        double amount;
        int count = 0;
        //these are the parameters of each room 
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
        static List<Node> rlist = new List<Node>();
        Node rm = new Node();

        //this constructors is used to make list of the rooms with parameters  and they are saved in 
        //a .csv 
        public Room(Optimal_Values.Node s)
        {
            rlist.Clear();
            readfile();

            rm.roomName = s.roomName;
            rm.temperature = s.O_Vtemperature;
            rm.Water = s.O_VWater;
            rm.Humidity = s.O_VHumidity;
            rm.SoilAcidity = s.O_VHumidity;
            rm.PlantBed = s.O_VPlantBed;
            rm.Fertilizer = s.O_VFertilizer;
            rm.Lighting = s.O_VLighting;
            rm.cost = 0;
            rlist.Add(rm);
            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv";

            List<string> roomname = new List<string>();
            List<double> temp = new List<double>();
            List<double> water = new List<double>();
            List<double> humidity = new List<double>();
            List<double> plantbed = new List<double>();
            List<double> soil = new List<double>();
            List<double> fert = new List<double>();
            List<double> lig = new List<double>();
            List<double> cot = new List<double>();
            foreach (Node n in rlist)
            {
                //var rm = new Node();

                roomname.Add(n.roomName);
                temp.Add(n.temperature);
                water.Add(n.Water);
                humidity.Add(n.Humidity);
                plantbed.Add(n.PlantBed);
                soil.Add(n.SoilAcidity);

                fert.Add(n.Fertilizer);
                lig.Add(n.Lighting);
                cot.Add(0);
            }
            var writer = new StringBuilder();
            for (int i = 0; i < rlist.Count(); i++)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", roomname.ElementAt(i).ToString(), temp.ElementAt(i).ToString(), water.ElementAt(i).ToString(), humidity.ElementAt(i).ToString(), plantbed.ElementAt(i).ToString(), soil.ElementAt(i).ToString(), fert.ElementAt(i).ToString(), lig.ElementAt(i).ToString(), cot.ElementAt(i).ToString(), Environment.NewLine);
                writer.Append(newLine);
            }
            File.WriteAllText(file, writer.ToString());

        }

        //when we start execution then first the previous data is loaded to the list with its parameters
        public void readfile()
        {
            var file = new StreamReader(File.OpenRead(@"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv"));
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                var values = line.Split(',');
                var rm = new Node();
                rm.roomName = values[0];
                rm.temperature = Double.Parse(values[1]);
                rm.Water = Double.Parse(values[2]);
                rm.Humidity = Double.Parse(values[3]);
                rm.SoilAcidity = Double.Parse(values[4]);
                rm.PlantBed = Double.Parse(values[5]);
                rm.Fertilizer = Double.Parse(values[6]);
                rm.Lighting = Double.Parse(values[7]);
                rm.cost = Double.Parse(values[8]);
                rlist.Add(rm);

            }
            file.Close();
        }

        //when we ask the system to show the performance of the particular room the it compares
        //the roomname and shows the performance of the room
        public Room(string s)
        {

            InitializeComponent();
            rlist.Clear();
            readfile();

            foreach (Node n in rlist)
            {
                if (n.roomName.Equals(s.ToString()))
                {
                    rm_lbl1.Text = n.temperature.ToString();
                    rm_lbl2.Text = n.Water.ToString();
                    rm_lbl3.Text = n.Humidity.ToString();
                    rm_lbl4.Text = n.SoilAcidity.ToString();
                    rm_lbl5.Text = n.PlantBed.ToString();
                    rm_lbl6.Text = n.Fertilizer.ToString();
                    rm_lbl7.Text = n.Lighting.ToString();
                    ov_lbl8.Text = n.cost.ToString();
                    amount = n.cost;
                    this.Text = n.roomName.ToString();
                }
            }
            // Rnadomize this part based on the label value 
            Random rnd = new Random();
            ov_lbl1.Text = rnd.Next(Int32.Parse(rm_lbl1.Text) - 2, Int32.Parse(rm_lbl1.Text) + 2).ToString();//sen.sensortemperature().ToString();
            ov_lbl2.Text = rnd.Next(Int32.Parse(rm_lbl2.Text) - 2, Int32.Parse(rm_lbl2.Text) + 2).ToString(); //sen.sensorWater().ToString();
            ov_lbl3.Text = rnd.Next(Int32.Parse(rm_lbl3.Text) - 2, Int32.Parse(rm_lbl3.Text) + 2).ToString();// sen.sensorHumidity().ToString();
            ov_lbl4.Text = rnd.Next(Int32.Parse(rm_lbl4.Text) - 2, Int32.Parse(rm_lbl4.Text) + 2).ToString();// sen.sensorSoilAcidity().ToString();
            ov_lbl5.Text = rnd.Next(Int32.Parse(rm_lbl5.Text) - 2, Int32.Parse(rm_lbl5.Text) + 2).ToString(); //sen.sensorPlantBed().ToString();
            ov_lbl6.Text = rnd.Next(Int32.Parse(rm_lbl6.Text) - 2, Int32.Parse(rm_lbl6.Text) + 2).ToString();//sen.sensorFertilizer().ToString();
            ov_lbl7.Text = rnd.Next(Int32.Parse(rm_lbl7.Text) - 2, Int32.Parse(rm_lbl7.Text) + 2).ToString();//sen.sensorLighting().ToString();

        }

       
        //this constructor is used when the values of a particular room are edited 
        //this will edit the list and the cvs file where we store the parameters 
        //and name of the room.
        public Room(ModifyRoom.Node s)
        {
            foreach (Node n in rlist)
            {
                if (n.roomName.ToString().Equals(s.roomName))
                {
                    rlist.Remove(n);
                    var rm = new Node();
                    rm.roomName = s.roomName;
                    rm.temperature = s.temperature;
                    rm.Water = s.Water;
                    rm.Humidity = s.Humidity;
                    rm.SoilAcidity = s.SoilAcidity;
                    rm.PlantBed = s.PlantBed;
                    rm.Fertilizer = s.Fertilizer;
                    rm.Lighting = s.Lighting;
                    rm.cost = s.cost;
                    rlist.Add(rm);

                    break;
                }
            }
            InitializeComponent();
            //  TextLabelUpdates(s);
            this.Text = s.roomName.ToString();
            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv";


            List<string> roomname = new List<string>();
            List<double> temp = new List<double>();
            List<double> water = new List<double>();
            List<double> humidity = new List<double>();
            List<double> plantbed = new List<double>();
            List<double> soil = new List<double>();
            List<double> fert = new List<double>();
            List<double> lig = new List<double>();
            List<double> cot = new List<double>();
            foreach (Node n in rlist)
            {
                //var rm = new Node();

                roomname.Add(n.roomName);
                temp.Add(n.temperature);
                water.Add(n.Water);
                humidity.Add(n.Humidity);
                plantbed.Add(n.PlantBed);
                soil.Add(n.SoilAcidity);
                fert.Add(n.Fertilizer);
                lig.Add(n.Lighting);
                cot.Add(n.cost);

            }
            var writer = new StringBuilder();
            for (int i = 0; i < rlist.Count(); i++)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", roomname.ElementAt(i).ToString(), temp.ElementAt(i).ToString(), water.ElementAt(i).ToString(), humidity.ElementAt(i).ToString(), plantbed.ElementAt(i).ToString(), soil.ElementAt(i).ToString(), fert.ElementAt(i).ToString(), lig.ElementAt(i).ToString(), cot.ElementAt(i).ToString(), Environment.NewLine);
                writer.Append(newLine);
            }
            File.WriteAllText(file, writer.ToString());

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        //this function will compare the parameters and activate the controllers for each parameters
        //if there values are equal then the controllers are off and if they are not equal then the 
        //controllers are on and if the controllers are on then the amount spend on that particualr 
        //room is increased.
        private void RadioUpdates()
        {
            count++;
            // checking the conditions
            if (ov_lbl1.Text.ToString().Equals(rm_lbl1.Text.ToString()))
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;

            }
            else
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
                amount++;
            }
            if (ov_lbl2.Text.ToString().Equals(rm_lbl2.Text.ToString()))
            {
                radioButton3.Checked = false;
                radioButton4.Checked = true;
            }
            else
            {
                radioButton4.Checked = false;
                radioButton3.Checked = true;
                amount++;
            }
            if (ov_lbl3.Text.ToString().Equals(rm_lbl3.Text.ToString()))
            {
                radioButton5.Checked = false;
                radioButton6.Checked = true;
            }
            else
            {
                radioButton6.Checked = false;
                radioButton5.Checked = true;
                amount++;
            }
            if (ov_lbl4.Text.ToString().Equals(rm_lbl4.Text.ToString()))
            {
                radioButton7.Checked = false;
                radioButton8.Checked = true;
            }
            else
            {
                radioButton8.Checked = false;
                radioButton7.Checked = true;
                amount++;
            }
            if (ov_lbl5.Text.ToString().Equals(rm_lbl5.Text.ToString()))
            {
                radioButton9.Checked = false;
                radioButton10.Checked = true;
            }
            else
            {
                radioButton10.Checked = false;
                radioButton9.Checked = true;
                amount++;
            }
            if (ov_lbl6.Text.ToString().Equals(rm_lbl6.Text.ToString()))
            {
                radioButton11.Checked = false;
                radioButton12.Checked = true;
            }
            else
            {
                radioButton12.Checked = false;
                radioButton11.Checked = true;
                amount++;
            }
            if (ov_lbl7.Text.ToString().Equals(rm_lbl7.Text.ToString()))
            {
                radioButton13.Checked = false;
                radioButton14.Checked = true;
            }
            else
            {
                radioButton14.Checked = false;
                radioButton13.Checked = true;
                amount++;
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {
            RadioUpdates();
            timer1.Start();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        //if we click delete button then the room will be deleted from the list and .cvs file.
        //and shows the home screen.
        private void button3_Click(object sender, EventArgs e)
        {

            string roomName = this.Text.ToString();
            // Deleting the content
            try
            {
                foreach (Node n in rlist)
                {
                    if (roomName.Equals(n.roomName.ToString()))
                    {
                        rlist.Remove(n);
                        break;
                    }
                }
                var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv";


                List<string> roomname = new List<string>();
                List<double> temp = new List<double>();
                List<double> water = new List<double>();
                List<double> humidity = new List<double>();
                List<double> plantbed = new List<double>();
                List<double> soil = new List<double>();
                List<double> fert = new List<double>();
                List<double> lig = new List<double>();
                List<double> cot = new List<double>();
                foreach (Node s in rlist)
                {
                    //var rm = new Node();

                    roomname.Add(s.roomName);
                    temp.Add(s.temperature);
                    water.Add(s.Water);
                    humidity.Add(s.Humidity);
                    plantbed.Add(s.PlantBed);
                    soil.Add(s.SoilAcidity);

                    fert.Add(s.Fertilizer);
                    lig.Add(s.Lighting);
                    cot.Add(s.cost);
                }
                var writer = new StringBuilder();
                for (int i = 0; i < rlist.Count(); i++)
                {
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", roomname.ElementAt(i).ToString(), temp.ElementAt(i).ToString(), water.ElementAt(i).ToString(), humidity.ElementAt(i).ToString(), plantbed.ElementAt(i).ToString(), soil.ElementAt(i).ToString(), fert.ElementAt(i).ToString(), lig.ElementAt(i).ToString(), cot.ElementAt(i).ToString(), Environment.NewLine);
                    writer.Append(newLine);
                }
                File.WriteAllText(file, writer.ToString());

            }
            catch (Exception)
            { }
            this.Hide();
            RoomList f1 = new RoomList(roomName);
           // f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Node n in rlist)
            {
                if (n.roomName.ToString().Equals(this.Text))
                {
                    rlist.Remove(n);
                    var rm = new Node();
                    rm.roomName = n.roomName;
                    rm.temperature = n.temperature;
                    rm.Water = n.Water;
                    rm.Humidity = n.Humidity;
                    rm.SoilAcidity = n.SoilAcidity;
                    rm.PlantBed = n.PlantBed;
                    rm.Fertilizer = n.Fertilizer;
                    rm.Lighting = n.Lighting;
                    rm.cost = amount;
                    rlist.Add(rm);

                    break;
                }
            }

            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv";


            List<string> roomname = new List<string>();
            List<double> temp = new List<double>();
            List<double> water = new List<double>();
            List<double> humidity = new List<double>();
            List<double> plantbed = new List<double>();
            List<double> soil = new List<double>();
            List<double> fert = new List<double>();
            List<double> lig = new List<double>();
            List<double> cot = new List<double>();
            foreach (Node n in rlist)
            {
                //var rm = new Node();

                roomname.Add(n.roomName);
                temp.Add(n.temperature);
                water.Add(n.Water);
                humidity.Add(n.Humidity);
                plantbed.Add(n.PlantBed);
                soil.Add(n.SoilAcidity);
                fert.Add(n.Fertilizer);
                lig.Add(n.Lighting);
                cot.Add(n.cost);

            }
            var writer = new StringBuilder();
            for (int i = 0; i < rlist.Count(); i++)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", roomname.ElementAt(i).ToString(), temp.ElementAt(i).ToString(), water.ElementAt(i).ToString(), humidity.ElementAt(i).ToString(), plantbed.ElementAt(i).ToString(), soil.ElementAt(i).ToString(), fert.ElementAt(i).ToString(), lig.ElementAt(i).ToString(), cot.ElementAt(i).ToString(), Environment.NewLine);
                writer.Append(newLine);
            }
            File.WriteAllText(file, writer.ToString());

            this.Hide();
            RoomList f1 = new RoomList();
           // f1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomName = this.Text.ToString();
            // Deleting the content
            try
            {
                foreach (Node n in rlist)
                {
                    if (roomName.Equals(n.roomName.ToString()))
                    {
                        this.Hide();

                        ModifyRoom f2 = new ModifyRoom(n.roomName, n.temperature, n.Water, n.Humidity, n.SoilAcidity, n.PlantBed, n.Fertilizer, n.Lighting, amount);
                        f2.Show();
                    }
                }
            }
            catch (Exception)
            { }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        //simulation is done over after ever 2 second it takes sensor values(random values) and compare the optimal values 
        //and sensor values and controls the controls which are show on screen by radio buttons and after every 10 seconds 
        //the some of the parameters will increase there values by one.(for visual purpose we have done it for 2 seconds and 10 seconds).
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ov_lbl1.Text = rnd.Next(Int32.Parse(rm_lbl1.Text) - 2, Int32.Parse(rm_lbl1.Text) + 2).ToString();//sen.sensortemperature().ToString();
            ov_lbl2.Text = rnd.Next(Int32.Parse(rm_lbl2.Text) - 2, Int32.Parse(rm_lbl2.Text) + 2).ToString(); //sen.sensorWater().ToString();
            ov_lbl3.Text = rnd.Next(Int32.Parse(rm_lbl3.Text) - 2, Int32.Parse(rm_lbl3.Text) + 2).ToString();// sen.sensorHumidity().ToString();
            ov_lbl4.Text = rnd.Next(Int32.Parse(rm_lbl4.Text) - 2, Int32.Parse(rm_lbl4.Text) + 2).ToString();// sen.sensorSoilAcidity().ToString();
            ov_lbl5.Text = rnd.Next(Int32.Parse(rm_lbl5.Text) - 2, Int32.Parse(rm_lbl5.Text) + 2).ToString(); //sen.sensorPlantBed().ToString();
            ov_lbl6.Text = rnd.Next(Int32.Parse(rm_lbl6.Text) - 2, Int32.Parse(rm_lbl6.Text) + 2).ToString();//sen.sensorFertilizer().ToString();
            ov_lbl7.Text = rnd.Next(Int32.Parse(rm_lbl7.Text) - 2, Int32.Parse(rm_lbl7.Text) + 2).ToString();//sen.sensorLighting().ToString();
            RadioUpdates();
            ov_lbl8.Text = amount.ToString();
            
            if (count == 5)
            {
                foreach (Node n in rlist)
                {
                    if (n.roomName.ToString().Equals(this.Text))
                    {


                        var rm = new Node();
                        rm.roomName = n.roomName;
                        rm.temperature = n.temperature;
                        rm.Water = n.Water + 1;
                        rm.Humidity = n.Humidity;
                        rm.SoilAcidity = n.SoilAcidity + 1;
                        rm.PlantBed = n.PlantBed;
                        rm.Fertilizer = n.Fertilizer + 1;
                        rm.Lighting = n.Lighting;
                        rm.cost = amount;
                        rlist.Remove(n);
                        rlist.Add(rm);

                        break;
                    }
                }

                var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\rooms.csv";


                List<string> roomname = new List<string>();
                List<double> temp = new List<double>();
                List<double> water = new List<double>();
                List<double> humidity = new List<double>();
                List<double> plantbed = new List<double>();
                List<double> soil = new List<double>();
                List<double> fert = new List<double>();
                List<double> lig = new List<double>();
                List<double> cot = new List<double>();
                foreach (Node a in rlist)
                {
                    //var rm = new Node();

                    roomname.Add(a.roomName);
                    temp.Add(a.temperature);
                    water.Add(a.Water);
                    humidity.Add(a.Humidity);
                    plantbed.Add(a.PlantBed);
                    soil.Add(a.SoilAcidity);
                    fert.Add(a.Fertilizer);
                    lig.Add(a.Lighting);
                    cot.Add(a.cost);

                }
                var writer = new StringBuilder();
                for (int i = 0; i < rlist.Count(); i++)
                {
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", roomname.ElementAt(i).ToString(), temp.ElementAt(i).ToString(), water.ElementAt(i).ToString(), humidity.ElementAt(i).ToString(), plantbed.ElementAt(i).ToString(), soil.ElementAt(i).ToString(), fert.ElementAt(i).ToString(), lig.ElementAt(i).ToString(), cot.ElementAt(i).ToString(), Environment.NewLine);
                    writer.Append(newLine);
                }
                File.WriteAllText(file, writer.ToString());

                foreach (Node n in rlist)
                {
                    if (n.roomName.ToString().Equals(this.Text))
                    {
                        rm_lbl1.Text = n.temperature.ToString();
                        rm_lbl2.Text = n.Water.ToString();
                        rm_lbl3.Text = n.Humidity.ToString();
                        rm_lbl4.Text = n.SoilAcidity.ToString();
                        rm_lbl5.Text = n.PlantBed.ToString();
                        rm_lbl6.Text = n.Fertilizer.ToString();
                        rm_lbl7.Text = n.Lighting.ToString();
                       
                        
                    }
                }
                count = 0;
                   

         /**/   }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
    
