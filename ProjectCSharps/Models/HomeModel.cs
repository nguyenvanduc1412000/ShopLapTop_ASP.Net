﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCSharps.Context;
namespace ProjectCSharps.Models
{
    public class HomeModel
    {
        public List<product> listP { get; set; }
        public List<category> listC { get; set; }

    }
}