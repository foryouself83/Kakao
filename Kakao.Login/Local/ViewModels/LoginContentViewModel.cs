using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Names;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Login.Local.ViewModels
{
    public partial class LoginContentViewModel : ObservableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;

        public LoginContentViewModel(IRegionManager gregionManager, IContainerProvider containerPovider) 
        {
            _regionManager = gregionManager;
            _containerPovider = containerPovider;
        }

        [RelayCommand]
        private void Login()
        {
            IRegion mainRegion = _regionManager.Regions[RegiontNamesManger.MainRegion];

            var mainContent = _containerPovider.Resolve<IViewable>(ContentNamesManger.Main);

            if (!mainRegion.Views.Contains(mainContent))
            {
                mainRegion.Add(mainContent);
            }

            mainRegion.Activate(mainContent);
        }
    }
}
