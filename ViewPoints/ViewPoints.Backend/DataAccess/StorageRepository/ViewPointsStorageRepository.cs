using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ViewPoints.Backend.Models;

namespace ViewPoints.Backend.DataAccess.StorageRepository
{
    public class ViewPointsStorageRepository
    {
        /// <summary>
        /// Uloží data do úložiště telefonu
        /// </summary>
        /// <param name="data">data k uložení</param>
        /// <param name="directory">cesta k souboru</param>
        /// <param name="filename">název souboru i s příponou</param>
        public void Save(ViewPointsList data, string directory, string filename)
        {
            string absolutePath = Path.Combine(directory, filename);
            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));

            using (StreamWriter writer = new StreamWriter(absolutePath))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ViewPointsList));
                xml.Serialize(writer, data);
            }
        }
    }
}
