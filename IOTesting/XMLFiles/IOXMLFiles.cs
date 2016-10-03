using System;
using System.Xml;
using System.Xml.Linq;

namespace XMLFiles
{
    class IOXMLFiles
    {
        static void Main(string[] args)
        {
            string value = "simple value";
            string property = "simple property";
            //creating of path for our xml file
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xml");
            //reading of the file
            using (XmlReader reader = XmlReader.Create(path))
            {
                while(reader.Read())
                {
                    switch(reader.Name)
                    {
                        case "row":
                            property = reader["property"];
                                    value = reader.ReadInnerXml();
                            Console.WriteLine("property="+property);
                            Console.WriteLine("value="+value);
                            break;
                        case "simpleRow":
                                    value = reader.ReadInnerXml();
                            Console.WriteLine("value="+value);
                            break;
                    }
                }
            }
            


            /* //creating of xml file by using of XmlWriter
             //writing of the file
             using (XmlWriter writer = XmlWriter.Create(path))

             {  //write XML data
                 //struktorata e start doc/elem/elem/stoinost i end v obratna posledovatelnot
                 // imame vgrajdane element-podelement
                 writer.WriteStartDocument(); //start the document
                 writer.WriteStartElement("Settings");//start 1st elem.
                 //sadarjanie na file zapametiavame 1 property
                 writer.WriteStartElement("row");

                 writer.WriteAttributeString("property", property);//<row property="simple property">value</row>
                 writer.WriteString(value); //<row>value</row> начало на св-во<>, tag,край на св-то</>
                 //<name>Iliana</name>  e sintsksisa na xml file

                 writer.WriteEndElement();
                 writer.WriteEndElement();
                 writer.WriteEndDocument();
                 // <Settings><row property="simple property">simple value</row></Settings>   

             }
             // podrejdane na faila za da e chetim i lesno redaktiruem
            XDocument document = XDocument.Load(path);//create new xml doc trom the file
            document.Save(path); //save of new xml file
             //za startirane i pokazvane na xml file
             System.Diagnostics.Process.Start(path);
             */
            /*< Settings >
           < row property = "simple property" > simple value </ row >
           </ Settings >
            */

        }
    }
}
