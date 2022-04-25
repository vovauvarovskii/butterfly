using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buterfly.Info;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace buterfly.Admin
{
    internal class AdminFly
    {
        public List<InfoFly> Buts { get; set; } //записи
        private string _path;  // путь  к файлу  

        public AdminFly(string path)
        {
            _path = path;
            Buts = RunRecord();
        }
        /// <summary>
        /// загрузка из файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<InfoFly> RunRecord()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<InfoFly> rec = formatter.Deserialize(fs) as List<InfoFly>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<InfoFly>();
                }
            }
            catch (SerializationException ex)
            {
                return new List<InfoFly>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveRecorFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Buts);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string name, string view, string live, string definition, string location)
        {
            Buts.Add(new InfoFly(name,view,live,definition,location));
            try
            {
                SaveRecorFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}