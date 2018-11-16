using System;
using AppRopio.Base.Onboarding.Core.Enums;
using MvvmCross.Core.ViewModels;
namespace AppRopio.Base.Onboarding.Core.ViewModels.Items
{
    public interface IOnboardingPageVM : IMvxViewModel
    {
        string Title { get; }

        string Image { get; }

        string Description { get; }

        OnboardingPageType Type { get; }

        IMvxCommand TypeCommand { get; }
    }
}
