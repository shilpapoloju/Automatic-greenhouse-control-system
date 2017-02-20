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
    public partial class RoomList : Form
    {
        
        public struct Node
        {
            public string roomName { get; set; }
                    

        }
        Optimal_Values OV = new Optimal_Values();
       
        static List<Node> rlist = new List<Node>(); 
        //public string roomname;
       
        
        public RoomList()
        {
            InitializeComponent();
            rlist.Clear();
            readfile();
            
        }
        public void readfile()
        {
              var file = new StreamReader(File.OpenRead(@"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\roomlist.csv"));
            while (!file.EndOfStream)
            {
                var line = file.ReadLine();
                         
               var rm = new Node();
               rm.roomName = line;
               
               rlist.Add(rm);
                              
            }
            file.Close();
        }

        //delete
        public RoomList(string roomName)
        {
            
            foreach (Node n in rlist)
            {
                if (n.roomName.ToString().Equals(roomName))
                {
                    rlist.Remove(n);
                    break;
                }
            }
            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\roomlist.csv";
          
            List<string> example= new List<string>();
            foreach(Node n in rlist)
            {
              example.Add(n.roomName);
            }
               File.WriteAllLines(file,example);
         
            
        }

        //modify
        

        public void createnode(string Name)
        {

            var rm =new Node();
            rm.roomName= Name;
         
            rlist.Add(rm);
            var file = @"C:\Users\anusha\Documents\Visual Studio 2013\Projects\sesprint1\sesprint1\roomlist.csv";
           
	           StringBuilder sb = new StringBuilder();  
	                sb.AppendLine(string.Join(",",Name));
         File.AppendAllText(file,sb.ToString());

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (rlist.Count() < 7)
            {
                this.Hide();
                OV.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry no space in GreenHouse");
            }
        }
        public List<Node> GetList()
        {
            return rlist;
        }
        public System.Windows.Forms.LinkLabel AddNewlabel(string rName)
        {

            
            Boolean errorFlag = false;
            System.Windows.Forms.LinkLabel lbl = new System.Windows.Forms.LinkLabel();
            this.Controls.Add(lbl);
            lbl.Top = 150;
            //lbl.ForeColor(Control);
            lbl.Left = 50 + rlist.Count();
            try
            {
                lbl.Text = rName ;
            }
            catch (FormatException)
            {

                errorFlag = true;

            }
            catch (NullReferenceException)
            {

            }
            if (errorFlag == false)
            {

            }

            return lbl;

        }

        private void RoomList_Load(object sender, EventArgs e)
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                 listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                 flowLayoutPanel1.Controls.Remove(control);
                 control.Dispose();
            }

            
            //RoomNames
            foreach (Node s in rlist)
            {
                //AddNewlabel(s.roomName).Click += new EventHandler(p_Click);
                flowLayoutPanel1.Controls.Add(AddNewlabel(s.roomName));
                
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Label)
                    c.Click += p_Click;
            }
        }
        // Writing the click event function
        void p_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Label l = sender as Label;
            Room r=null;
            foreach(Node n in rlist){
                if (n.roomName.Equals(l.Text.ToString()))
                {
                    r = new Room(n.roomName);
                    r.Show();
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            RoomList_Load(sender,e );
             
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}