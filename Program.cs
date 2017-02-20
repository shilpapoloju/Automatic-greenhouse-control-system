using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;

namespace sesprint1
{
    public class Program
    {

       
        //main
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RoomList());

        }
    }
}
