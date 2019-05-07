using System;
using System.Collections.Generic;
using System.Text;
using ViewPoints.Backend.Managers;
using ViewPoints.DependencyServices;
using ViewPoints.ViewModels.Abstract;
using ViewPoints.Views;
using Xamarin.Forms;

namespace ViewPoints.ViewModels
{
    class LoginViewModel : ViewModel
    {
        private const string NicknameKey = "ViewPoints.Nickname";

        public LoginViewModel()
        {
            SendCommand = new Command(SendCommand_Execute);
            this.Nickname = DependencyService.Get<ISettings>().GetVariable(NicknameKey, null);
        }

        public string Nickname { get; set; }

        public Command SendCommand { get; private set; }

        private async void SendCommand_Execute()
        {
            var userManager = new UserManager();
            if(await userManager.LoginUser(Nickname))
            {
                DependencyService.Get<ISettings>().SetVariable(this.Nickname, NicknameKey);
                App.Current.MainPage = new NavigationPage(new ViewPointListPage());
            }
        }
    }
}
