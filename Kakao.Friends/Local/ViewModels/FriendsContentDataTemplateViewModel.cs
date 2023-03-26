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
    public partial class FriendsContentDataTemplateViewModel : ObservableBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;

        [ObservableProperty]
        private ObservableCollection<Friend> _birthdayFriends;

        [ObservableProperty]
        private ObservableCollection<Friend> _favoriteFriends;

        public FriendsContentDataTemplateViewModel(IRegionManager gregionManager, IContainerProvider containerPovider)
        {
            _regionManager = gregionManager;
            _containerPovider = containerPovider;
            _birthdayFriends = new ObservableCollection<Friend>()
            {
                new Friend() { Types = FriendsItemType.BirthDay ,Name = "TEST 1", Description = "TESTING 1"},
                new Friend() { Types = FriendsItemType.BirthDay ,Name = "TEST 2", Description = "TESTING 2"},
                new Friend() { Types = FriendsItemType.BirthDay ,Name = "TEST 3", Description = "TESTING 3"},
            };

            _favoriteFriends = new ObservableCollection<Friend>()
            {
                new Friend() { Types = FriendsItemType.Favorite ,Name = "FAVORITE 1", Description = "FAVORITE TEST 1"},
                new Friend() { Types = FriendsItemType.Favorite ,Name = "FAVORITE 2", Description = "FAVORITE TEST 2"},
                new Friend() { Types = FriendsItemType.Favorite ,Name = "FAVORITE 3", Description = "FAVORITE TEST 3"},
            };
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
