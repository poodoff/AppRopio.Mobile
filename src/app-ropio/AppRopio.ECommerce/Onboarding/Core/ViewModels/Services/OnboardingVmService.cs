using System;
using System.Threading.Tasks;
using AppRopio.Base.Core.ViewModels.Services;
using AppRopio.Base.Onboarding.Core.ViewModels.Items;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using AppRopio.Base.Onboarding.Core.Services;
using System.Linq;

namespace AppRopio.Base.Onboarding.Core.ViewModels.Services
{
    public class OnboardingVmService : BaseVmService, IOnboardingVmService
    {
        #region Services

        protected IOnboardingConfigService ConfigService { get { return Mvx.Resolve<IOnboardingConfigService>(); } }

        #endregion

        public async Task<MvxObservableCollection<IOnboardingPageVM>> LoadOnboardingPages()
        {
            MvxObservableCollection<IOnboardingPageVM> pages = null;

            //in some future we can load it by API

            var items = ConfigService.Config.OnboardingPages.Select(x => new OnboardingPageVM(x));
            pages = new MvxObservableCollection<IOnboardingPageVM>(items);

            return pages;
        }
    }
}
