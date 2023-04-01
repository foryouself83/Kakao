using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Models;
using Kakao.Core.Names;
using Kakao.Core.Talks;
using Kakao.Friends.Local.Models;
using Kakao.Friends.UI.Views;
using Kakao.Talk.UI.Views;
using Prism.Ioc;
using Prism.Regions;

namespace Kakao.Friends.Local.ViewModels
{
    public partial class FriendsContentViewModel : ObservableBase
    {
        private readonly IEventHub _eventHub;
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerPovider;
        private readonly TalkWindowManager _talkWindowManager;

        [ObservableProperty]
        private List<FriendsModel> _favorites;


        public FriendsContentViewModel(IEventHub eventHub,
            IRegionManager gregionManager, 
            IContainerProvider containerPovider,
            TalkWindowManager talkWindowManager)
        {
            _eventHub = eventHub;
            _regionManager = gregionManager;
            _containerPovider = containerPovider;
            _talkWindowManager = talkWindowManager;

            _talkWindowManager.WindowCountChanged += _talkWindowManager_WindowCountChanged;

            Favorites = GetFavorites();
        }

        private void _talkWindowManager_WindowCountChanged(object? sender, EventArgs e)
        {
            _eventHub.Publish<RefreshTalkWIndowEvent, RefreshTalkWIndowArg>(new RefreshTalkWIndowArg());

        }

        private List<FriendsModel> GetFavorites()
        {
            List<FriendsModel> source = new();
            source.Add(new FriendsModel().DataGenerator(1, "James"));
            source.Add(new FriendsModel().DataGenerator(2, "James 1"));
            source.Add(new FriendsModel().DataGenerator(3, "James 2"));

            return source;
        }
        [RelayCommand]
        private void DoubleClick(FriendsModel data)
        {
            var content  = new TalkContent();

            TalkWindow talkWindow = _talkWindowManager.ResolveWindow<TalkWindow>(data.Id);
            talkWindow.Title = data.Name;
            talkWindow.Content = content;
            talkWindow.Width = 360;
            talkWindow.Height = 500;

            if (content.DataContext is IReceiverInfo info)
            {
                info.InitReceiver(data);
            }

            talkWindow.Show();
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

        [RelayCommand]
        private void ShowSimulator()
        {
            var view = _containerPovider.Resolve<IViewable>(ContentNamesManger.Simulator);

            if (view is JamesWindow window)
            {
                window.Show();
            }
        }
    }
}
