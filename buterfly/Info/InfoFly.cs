using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buterfly.Admin;

namespace buterfly.Info
{
    
    
        [Serializable] //  сериализация
       
        internal class InfoFly
        {
            public string Name { get; set; }
            public string View { get; set; }
            public string Live { get; set; }
            public string Definition { get; set; }
            public string Location { get; set; }

            public InfoFly(string name, string view, string live, string definition, string location) // конструктор
            {
              Name = name;
              View = view;
              Live = live;
              Definition = definition;
              Location = location;    

            }

            public override string ToString()
            {
                return $"\n\tназвание : {Name}, \n\tвид: {View}\n\t" +$"время жизни: {Live}" + $"\n\tкраткое описание: {Definition}" + $"\n\tместо обитания: {Location}";
            }
        }
    
}


