using System;
using AppRopio.Base.iOS.Services.ThemeConfig;
using AppRopio.Base.Onboarding.Core;
using AppRopio.Base.Onboarding.iOS.Models;
namespace AppRopio.Base.Onboarding.iOS.Services.Implementation
{
    public class OnboardingThemeConfigService : BaseThemeConfigService<OnboardingThemeConfig>, IOnboardingThemeConfigService
    {
        protected override string ConfigName
        {
            get => OnboardingConstants.CONFIG_NAME;
        }
    }
}
