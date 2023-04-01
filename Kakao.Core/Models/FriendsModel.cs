using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FriendsModel()
        {
            Id = 0;
            Name = string.Empty;
        }
        public FriendsModel DataGenerator(int id, string name)
        {
            Id = id;
            Name = name;
            return this;
        }
    }
}
