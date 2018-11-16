using System.Threading.Tasks;
using AppRopio.Base.Core.Extentions;
using AppRopio.Base.Core.Models.Navigation;
using AppRopio.Base.Core.Services.ViewModelLookup;
using AppRopio.Base.Core.ViewModels;
using AppRopio.Base.Onboarding.Core.Models.Bundle;
using AppRopio.Base.Onboarding.Core.Services;
using AppRopio.Base.Onboarding.Core.ViewModels.Items;
using AppRopio.Base.Onboarding.Core.ViewModels.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace AppRopio.Base.Onboarding.Core.ViewModels
{
    public class OnboardingViewModel : BaseViewModel, IOnboardingViewModel
    {
        #region Properties

        private bool _isOnFirstLaunch;
        public bool IsOnFirstLaunch
        {
            get => _isOnFirstLaunch;
            set => SetProperty(ref _isOnFirstLaunch, value, nameof(IsOnFirstLaunch));
        }

        private MvxObservableCollection<IOnboardingPageVM> _pages;
        public MvxObservableCollection<IOnboardingPageVM> Pages
        {
            get => _pages;
            protected set => SetProperty(ref _pages, value, nameof(Pages));
        }

        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                SetProperty(ref _currentPage, value, nameof(CurrentPage));
                IsLastPage = (value == Pages.Count - 1);
            }
        }

        private bool _isLastPage;
        public bool IsLastPage
        {
            get => _isLastPage;
            set => SetProperty(ref _isLastPage, value, nameof(IsLastPage));
        }
        
        #endregion

        #region Commands

        private IMvxCommand _previousCommand;
        public IMvxCommand PreviousCommand => _previousCommand ?? (_previousCommand = new MvxCommand(OnPreviousExecute));

        private IMvxCommand _nextCommand;
        public IMvxCommand NextCommand => _nextCommand ?? (_nextCommand = new MvxCommand(OnNextExecute));

        private IMvxCommand _skipCommand;
        public IMvxCommand SkipCommand => _skipCommand ?? (_skipCommand = new MvxCommand(OnSkipExecute));

        #endregion

        #region Services

        protected IOnboardingVmService VmService { get { return Mvx.Resolve<IOnboardingVmService>(); } }
        protected IOnboardingConfigService ConfigService { get { return Mvx.Resolve<IOnboardingConfigService>(); } }

        #endregion

        #region Constructor

        public OnboardingViewModel()
        {
            IsOnFirstLaunch = true;
            VmNavigationType = NavigationType.PresentModal;
        }

        #endregion

        #region Protected

        #region Init

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var onboardingBundle = parameters.ReadAs<OnboardingBundle>();
            this.InitFromBundle(onboardingBundle);
        }

        protected virtual void InitFromBundle(OnboardingBundle bundle)
        {
            IsOnFirstLaunch = bundle.IsOnFirstLaunch;
            VmNavigationType = bundle.NavigationType == NavigationType.None ? NavigationType.PresentModal : bundle.NavigationType;
        }

        #endregion

        protected virtual async Task LoadContent()
        {
            //Loading = true;

            var pages = await VmService.LoadOnboardingPages();
            InvokeOnMainThread(() =>
            {
                Pages = pages;
                CurrentPage = 0;
            });

            //Loading = false;
        }

        protected virtual void OnPreviousExecute()
        {
            if (CurrentPage > 0)
                CurrentPage = CurrentPage - 1;
        }

        protected virtual void OnNextExecute()
        {
            if (IsLastPage)
            {
                if (IsOnFirstLaunch)
                {
                    var nextVm = Mvx.Resolve<IViewModelLookupService>().Resolve(ConfigService.Config.AfterFirstLaunchType);
                    ShowViewModel(nextVm);
                }
                else
                    OnSkipExecute();
            }
            else
            {
                if (CurrentPage < Pages.Count - 1)
                    CurrentPage = CurrentPage + 1;
            }
        }

        protected virtual void OnSkipExecute()
        {
            Close(this);
        }

        #endregion

        #region Public

        public override void Start()
        {
            base.Start();

            LoadContent();
        }

        #endregion

    }
}
