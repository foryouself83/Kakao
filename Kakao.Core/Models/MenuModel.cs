﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Kakao.Core.Models
{
    public class MenuModel
    {
        public string Id { get; set; }

        public MenuModel()
        {
            Id = string.Empty;
        }
        public MenuModel DataGenerator(string id)
        {
            Id = id;
            return this;
        }
    }
}
