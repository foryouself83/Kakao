using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Names;
using Kakao.Friends.Local.Models;
using Kakao.Friends.UI.Views;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;

        public FriendsContentViewModel(IRegionManager gregionManager, IContainerProvider containerPovider)
        {
            _regionManager = gregionManager;
            _containerPovider = containerPovider;
        }

        [RelayCommand]
        private void Logout()
        {
            IRegion mainRegion = _regionManager.Regions[RegiontNamesManger.MainRegion];

            var loginContent = _containerPovider.Resolve<IViewable>(ContentNamesManger.Login);

            if (!mainRegion.Views.Contains(loginContent))
            {
                mainRegion.Add(loginContent);
            }

            mainRegion.Activate(loginContent);
        }
    }
}
