using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTextFiles
{
    class IOTextFile
    {
       
        static void Main(string[] args)
        {
            STable nSTable = new STable();
            IOSettings nio = new IOSettings(nSTable);
           // Console.WriteLine(nSTable.stable[0]);
            // if (nio.save()) WriteLine("The table is saved");
            if (nio.open()) Console.WriteLine("The table is readed");
            else Console.WriteLine("The table is NOT readed");
            Console.WriteLine(nSTable.stable[2]);
        }
    }
}
