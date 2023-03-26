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
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Main.UI.Views;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Main.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;

        [ObservableProperty]
        private ObservableCollection<MenuModel> _menus;
        [ObservableProperty]
        private MenuModel? _menu;

        public MainContentViewModel(IRegionManager gregionManager, IContainerProvider containerPovider)
        {
            _regionManager = gregionManager;
            _containerPovider = containerPovider;

            _menus = GetMenus();
        }

        private ObservableCollection<MenuModel> GetMenus()
        {
            return new ObservableCollection<MenuModel>()
            {
                new MenuModel().DataGenerator(ContentNamesManger.Chats),
                new MenuModel().DataGenerator(ContentNamesManger.Friends),
                new MenuModel().DataGenerator(ContentNamesManger.More),
            };
        }
        partial void OnMenuChanged(MenuModel? value)
        {
            if (value is null) return;

            IRegion contentRegion = _regionManager.Regions[RegiontNamesManger.ContentRegion];

            var content = _containerPovider.Resolve<IViewable>(value.Id);

            if (!contentRegion.Views.Contains(content))
            {
                contentRegion.Add(content);
            }

            contentRegion.Activate(content);
        }

        [RelayCommand]
        private void Chats()
        {
            IRegion contentRegion = _regionManager.Regions[RegiontNamesManger.ContentRegion];

            var chatsContent = _containerPovider.Resolve<IViewable>(ContentNamesManger.Chats);

            if (!contentRegion.Views.Contains(chatsContent))
            {
                contentRegion.Add(chatsContent);
            }

            contentRegion.Activate(chatsContent);
        }

        [RelayCommand]
        private void Friends()
        {
            IRegion contentRegion = _regionManager.Regions[RegiontNamesManger.ContentRegion];

            var friendsContent = _containerPovider.Resolve<IViewable>(ContentNamesManger.Friends);

            if (!contentRegion.Views.Contains(friendsContent))
            {
                contentRegion.Add(friendsContent);
            }

            contentRegion.Activate(friendsContent);
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
