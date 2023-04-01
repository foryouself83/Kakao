using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Kakao.Core.Args;
using Kakao.Core.Events;
using Kakao.Core.Interfaces;
using Kakao.Core.Names;
using Kakao.Core.Talks;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace Kakao.Tests.Local.ViewModels
{
    public partial class SimulatorWindowViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _eventHub;
        private readonly TalkWindowManager _talkWindowManager;

        [ObservableProperty]
        private List<KeyValuePair<int, JamesWindow>>? _talkWindows;

        [ObservableProperty]
        private KeyValuePair<int, JamesWindow> _selectedWindow;

        [ObservableProperty]
        private string _receiveText;

        public SimulatorWindowViewModel(IEventHub eventHub, TalkWindowManager talkWindowManager)
        {
            _eventHub = eventHub;
            _talkWindowManager = talkWindowManager;

            _receiveText = string.Empty;

            _eventHub.Subscribe<RefreshTalkWIndowEvent, RefreshTalkWIndowArg>((e) => Refresh());
        }

        public void OnLoaded(IViewable smartWindow)
        {
            Refresh();
        }

        [RelayCommand]
        private void Refresh()
        {
            TalkWindows = _talkWindowManager.GetAllWindow();
        }
        [RelayCommand]
        private void Receive()
        {
            if (SelectedWindow.Value is not JamesWindow window) return;
            if (window.Content is not FrameworkElement element) return;
            if (element.DataContext is not IReeivedMessage receiveMessage) return;

            receiveMessage.Receive(ReceiveText);

        }

    }
}
