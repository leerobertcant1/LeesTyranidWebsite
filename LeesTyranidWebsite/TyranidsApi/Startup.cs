﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DataManager.Startup))]

namespace DataManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
