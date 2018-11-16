using System;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using AppRopio.Base.Onboarding.iOS.Services;
using AppRopio.Base.Onboarding.iOS.Services.Implementation;
using AppRopio.Base.Core.Services.ViewLookup;
using AppRopio.Base.Onboarding.Core.ViewModels;
using AppRopio.Base.Onboarding.iOS.Views;

namespace AppRopio.Base.Onboarding.iOS
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IOnboardingThemeConfigService>(() => new OnboardingThemeConfigService());

            var viewLookupService = Mvx.Resolve<IViewLookupService>();
            viewLookupService.Register<IOnboardingViewModel, OnboardingViewController>();
        }
    }
}
