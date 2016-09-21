using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTextFiles
{
    public class IOSettings
    {
        private STable nstable;
        public IOSettings(STable stable)
        {
            nstable = stable;
        }
        public string GethPath()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");
            return path;
        }
        // zasdavame bool method za da moje da proverim dali ima zapis
        // if use only System.IO.File.WriteAllText - nqma da znaem dali naistina e zapisan
        public bool save()
        {
            try
            {
                string temp = "";
                temp = String.Join("\r\n", nstable.stable);
                //zapis na textov file 
                //toi se namira v temp
               // System.IO.File.WriteAllText("c:\\AulaNew\\test.txt", temp);
                System.IO.File.WriteAllText(GethPath(), temp);
                return true;
            }catch { }
            return false;
        }
        public bool open()
        {
            try
            {
                string temp = System.IO.File.ReadAllText(GethPath());
                string[] table = temp.Replace("\r", "").Split('\n');
                for(int i=0; i<table.Length; i++)
                {
                    nstable.stable[i] = table[i];
                }
                return true;
            }catch { }
            return false;
        }
    }
}
/*
string file = //четеш го от някаде

string[] row = file.Split ('\n');

for (int i = 0; i < row.Lenght; i++)
{
     string[] value = row[i].Split ('\t');
     value[0] // Ще е стойността от първата колона на iтия ред
}
*/