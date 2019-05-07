using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewPoints.Backend.DataAccess.StorageRepository;
using ViewPoints.Backend.DataAccess.WebRepository;
using ViewPoints.Backend.Models;

namespace ViewPoints.Backend.Managers
{
    public class ViewPointManager
    {
        /// <summary>
        /// Načte ze serveru data a uloží je na zadanou cestu
        /// </summary>
        /// <param name="directory">cesta k souboru</param>
        /// <param name="filename">název souboru i s příponou</param>
        /// <returns>seznam rozhleden</returns>
        public async Task<List<ViewPoint>> GetViewPoints(string directory, string filename)
        {
            var id = UserManager.CurrentUser.Id;

            //načte rozhledny z API
            var webRepository = new ViewPointsWebRepository();
            var result = await webRepository.GetViewPoints(id);

            //uloží do interního úložiště
            await this.SaveViewPoints(result, directory, filename);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPoints"></param>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task SaveViewPoints(List<ViewPoint> viewPoints, string directory, string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                var storageRepository = new ViewPointsStorageRepository();
                storageRepository.Save(new ViewPointsList() {ViewPoints = viewPoints}, directory, filename);
            }
        }
    }
}
