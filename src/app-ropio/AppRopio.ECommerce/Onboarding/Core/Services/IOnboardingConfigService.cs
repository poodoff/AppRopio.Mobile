using System;
using AppRopio.Base.Onboarding.Core.Models;

namespace AppRopio.Base.Onboarding.Core.Services
{
    public interface IOnboardingConfigService
    {
        OnboardingConfig Config { get; }
    }
}
