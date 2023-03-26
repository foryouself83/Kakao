using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Jamesnet.Wpf.Controls;
using Kakao.Core.Names;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace Kakao.Forms.Local.ViewModels
{
    public class kakaoWindowViewModel : IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;

        public kakaoWindowViewModel(IRegionManager gregionManager, IContainerProvider containerPovider)
        {
            _regionManager = gregionManager;
            _containerPovider = containerPovider;
        }

        public void OnLoaded(IViewable view)
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
