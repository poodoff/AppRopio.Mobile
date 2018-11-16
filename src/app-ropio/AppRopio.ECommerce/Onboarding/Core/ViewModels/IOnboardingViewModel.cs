using System;
using AppRopio.Base.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using AppRopio.Base.Onboarding.Core.ViewModels.Items;

namespace AppRopio.Base.Onboarding.Core.ViewModels
{
    public interface IOnboardingViewModel : IBaseViewModel
    {
        bool IsOnFirstLaunch { get; }

        MvxObservableCollection<IOnboardingPageVM> Pages { get; }

        int CurrentPage { get; set; }

        bool IsLastPage { get; }

        IMvxCommand PreviousCommand { get; }

        IMvxCommand NextCommand { get; }

        IMvxCommand SkipCommand { get; }
    }
}
