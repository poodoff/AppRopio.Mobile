using System.Collections.Generic;
using AppRopio.Base.Core.Models.Bundle;
using AppRopio.Base.Core.Models.Navigation;

namespace AppRopio.Base.Onboarding.Core.Models.Bundle
{
    public class OnboardingBundle : BaseBundle
    {
        public bool IsOnFirstLaunch { get; set; } = true;

        public OnboardingBundle()
        {
        }

        public OnboardingBundle(NavigationType navigationType)
            : this (true, navigationType)
        {
            
        }

        public OnboardingBundle(bool isOnFirstLaunch, NavigationType navigationType)
            : base(navigationType, new Dictionary<string, string> { { nameof(IsOnFirstLaunch), isOnFirstLaunch.ToString() } })
        {
            IsOnFirstLaunch = isOnFirstLaunch;
        }
    }
}
