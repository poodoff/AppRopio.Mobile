using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using AppRopio.Base.Onboarding.Core.ViewModels.Items;
namespace AppRopio.Base.Onboarding.Core.ViewModels.Services
{
    public interface IOnboardingVmService
    {
        Task<MvxObservableCollection<IOnboardingPageVM>> LoadOnboardingPages();
    }
}
