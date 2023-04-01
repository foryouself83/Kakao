using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.Core.Talks
{
    public class TalkWindowManager
    {
        private Dictionary<int, JamesWindow> _windows;
        public event EventHandler<EventArgs>? WindowCountChanged;

        public TalkWindowManager()
        {
            _windows = new();
        }
        public List<KeyValuePair<int, JamesWindow>> GetAllWindow()
        {
            return _windows.ToList();
        }
        public T ResolveWindow<T>(int id) where T : JamesWindow, new()
        {
            if (_windows.ContainsKey(id))
            {

                return (T)_windows[id];
            }

            var window = new T();
            window.Closed += (s, e) =>
            {
                UnRegisterWindow(id);
            };
            _windows.Add(id, window);

            WindowCountChanged?.Invoke(this, EventArgs.Empty);

            return window;
        }

        private void UnRegisterWindow(int id)
        {
            if (_windows.ContainsKey(id))
                _windows.Remove(id);

            WindowCountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
