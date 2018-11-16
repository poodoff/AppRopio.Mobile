using System;
using AppRopio.Base.Core.Services.Router;
using AppRopio.Base.Core.Services.ViewModelLookup;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using AppRopio.Base.Onboarding.Core.ViewModels;
using AppRopio.Base.Onboarding.Core.Services.Implementation;
using AppRopio.Base.Onboarding.Core.ViewModels.Services;
using AppRopio.Base.Onboarding.Core.Services;

namespace AppRopio.Base.Onboarding.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IOnboardingConfigService>(() => new OnboardingConfigService());
            Mvx.RegisterSingleton<IOnboardingVmService>(() => new OnboardingVmService());

            var vmLookupService = Mvx.Resolve<IViewModelLookupService>();
            vmLookupService.Register<IOnboardingViewModel, OnboardingViewModel>();

            var routerService = Mvx.Resolve<IRouterService>();
            routerService.Register<IOnboardingViewModel>(new OnboardingRouterSubscriber());
        }
    }
}
