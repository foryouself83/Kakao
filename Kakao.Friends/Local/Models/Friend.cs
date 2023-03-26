using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Mvvm;

namespace Kakao.Friends.Local.Models
{
    public partial class Friend : ObservableObject
    {
        private string _id { get; set; }

        [ObservableProperty]
        private FriendsItemType _types;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private string _imagePath;

        [ObservableProperty]
        private string _songPath;

        public Friend()
        {
            _id = Guid.NewGuid().ToString();
            _types = FriendsItemType.None;
            _name = string.Empty;
            _description = string.Empty;
            _imagePath = string.Empty;
            _songPath = string.Empty;
        }
    }
}
