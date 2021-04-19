using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class TemplateFactory
    {


        private static TemplateFactory instance;
        public static TemplateFactory Instance
        {
            get {
                if (instance == null) {
                    instance = new TemplateFactory();
                }
                return instance;
            }
        }

        private TemplateFactory() { 

        }

        public void Initialize() { }

        public void CreateTemplateWithParams(string path=@"..\..\..\Content\GeneratedRooms\DefaultOut.csv") {
            File.Create(path);
            File.AppendAllText(path, "RMEX,,,,,,,,,,,,");
            File.AppendAllText(path, "RMIN,,,,,,,,,,,,");
            File.AppendAllText(path, @" , , , , , , , , , , , , 
 , , , , , , , , , , , ,
 , , , , ,WLD1, , , , , , ,
 , , , , , , , , , , , ,
 , , , , , , , , , , , ,
 , , , ,WLD1, , , , , , , ,
 , , , , , , , , , , , , 
");
            
        }

    }
}
