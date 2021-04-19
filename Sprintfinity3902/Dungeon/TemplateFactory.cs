using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Dungeon
{
    public class TemplateFactory
    {

        private static TemplateFactory instance;

        public static TemplateFactory Instance {
            get {
                if (instance == null) {
                    instance = new TemplateFactory();
                }
                return instance;
            }
        }

        private TemplateFactory() { 

        }


    }
}
