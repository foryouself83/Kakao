using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Kakao.Settings
{
    internal class DirectModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 이렇게 할 경우 LoginContent가 매번 생성된다
            // 한번만 생성해서 할 경우 이렇게하면 안된다.
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("MainRegion", "LoginContent");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
