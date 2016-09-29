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
            //Combine sabira  verniq pat s pravilniq sintaksis taka 4e 
            //ta raboti s all OS
            // iskame da e taka Program\Settings\settings.txt
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                            /*"test.txt"*/ "Settings");// test.txt  e imeto na faila v c:\AulaNew\primeri.csharp.IO
            path = System.IO.Path.Combine(path, "settings.txt");
            /*
            //Drugi vidove directorii
            string user = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            Console.WriteLine(user);
            string luser = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Console.WriteLine(luser);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(desktop);
            string startmenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            Console.WriteLine(startmenu);
            */
            return path;
        }
        // zasdavame bool method za da moje da proverim dali ima zapis
        // if use only System.IO.File.WriteAllText - nqma da znaem dali naistina e zapisan
        // save!=write
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
        //open!=read
        public bool open()
        {
            try
            {
                iniSettings();
                string temp = "", filePath = GethPath();
                if (System.IO.File.Exists(filePath)) //proverka dali path e validen
                {
                    System.IO.File.ReadAllText(filePath);
                    //split use only char! zatova mahame \r
                    string[] table = temp.Replace("\r", "").Split('\n');
                    for (int i = 0; i < table.Length; i++)
                    {
                        nstable.stable[i] = table[i];
                    }
                }
                else {
                   // Console.WriteLine("the path is NOT exists"); iniSettings();
                    return false;
                }
                return true;
            }catch { }
            return false;
        }
        private void iniSettings()
        {
            try
            {
                bool fileExist = System.IO.File.Exists(GethPath());
                if(!fileExist)
                {
                    string directory = System.IO.Path.GetDirectoryName(GethPath());
                    //zastrahovame se 4e the  directory exists
                    if(!System.IO.Directory.Exists(directory))
                    {
                        System.IO.Directory.CreateDirectory(directory);
                    }
                    //zapametiavame sadarjanieto na faila 
                    //na praktika pravim restore settings-vrashtame parvona4alnoto sadatjanie na tablicata
                    save();
                }
            }
            catch { }

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