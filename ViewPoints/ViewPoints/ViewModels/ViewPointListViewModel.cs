using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewPoints.Backend.Managers;
using ViewPoints.Backend.Models;
using ViewPoints.DependencyServices;
using ViewPoints.ViewModels.Abstract;
using ViewPoints.ViewModels.ItemViewModel;
using Xamarin.Forms;

namespace ViewPoints.ViewModels
{
    class ViewPointListViewModel : ViewModel
    {
        public const string ViewPointsDefaultFilename = "viewpoints.xml";
        public const string ViewPointsDefaultSubDirectory = "Viewpoints";
        
        public ViewPointListViewModel()
        {
            this.ExportCommand = new Command(this.ExportCommand_Execute);
        }
        
        private List<ViewPointItemViewModel> viewPoints;
        private List<ViewPoint> viewPointsData;

        public async Task LoadData()
        {
            var manager = new ViewPointManager();
            var list = new List<ViewPointItemViewModel>();

            viewPointsData = await manager.GetViewPoints(GetInternalPath(), ViewPointsDefaultFilename);

            foreach (var viewPoint in viewPointsData)
            {
                list.Add(new ViewPointItemViewModel(viewPoint));
            }

            this.ViewPoints = list;
        }

        public List<ViewPointItemViewModel> ViewPoints
        {
            get => this.viewPoints;
            set
            {
                if (this.viewPoints != value)
                {
                    this.viewPoints = value;
                    this.OnPropertyChanged(nameof(this.ViewPoints));
                }
            }
        }

        public Command ExportCommand { get; private set; }

        private async void ExportCommand_Execute()
        {
            var manager = new ViewPointManager();
            await manager.SaveViewPoints(viewPointsData, GetDocumentsPath(), ViewPointsDefaultFilename);
        }

        private string GetInternalPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return System.IO.Path.Combine(path, ViewPointsDefaultSubDirectory);
        }

        private string GetDocumentsPath()
        {
            string path = DependencyService.Get<IPathHelper>().GetDocumentsDirectoryPath();
            return System.IO.Path.Combine(path, ViewPointsDefaultSubDirectory);
        }
    }
}
