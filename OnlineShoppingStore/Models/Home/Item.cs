﻿using OnlineShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.Home
{
    public class Item
    {
        public Product Product { get; set; }
        public int Quantity{ get; set; }
    }
}