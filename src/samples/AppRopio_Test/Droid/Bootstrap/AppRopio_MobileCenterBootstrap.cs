﻿using System;
using MvvmCross.Platform.Plugins;

namespace AppRopio.Test.Droid.Bootstrap
{
    public class AppRopio_MobileCenterBootstrap 
        : MvxLoaderPluginBootstrapAction<AppRopio.Analytics.MobileCenter.Core.PluginLoader, AppRopio.Analytics.MobileCenter.Droid.Plugin>
    {
    }
}
