
using AppRopio.Base.Core.Converters;
using AppRopio.Base.iOS;
using AppRopio.Base.iOS.UIExtentions;
using AppRopio.Base.iOS.Views;
using AppRopio.Base.Onboarding.Core.ViewModels;
using AppRopio.Base.Onboarding.iOS.Models;
using AppRopio.Base.Onboarding.iOS.Services;
using AppRopio.Base.Onboarding.iOS.Views.Cells;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using UIKit;
using AppRopio.Base.iOS.ViewSources;
using Foundation;

namespace AppRopio.Base.Onboarding.iOS.Views
{
    public partial class OnboardingViewController : CommonViewController<IOnboardingViewModel>
    {
        protected OnboardingThemeConfig ThemeConfig { get { return Mvx.Resolve<IOnboardingThemeConfigService>().ThemeConfig; } }

        public OnboardingViewController() : base("OnboardingViewController", null)
        {
        }

        #region CommonViewController implementation

        protected override void InitializeControls()
        {
            Title = "";

            View.BackgroundColor = Theme.ColorPalette.Background.ToUIColor();

            //FIXME Change all style initialization to ThemeConfig

            SetupCollectionView(_collectionView);
            SetupPageControl(_pageControl);
            //SetupPreviousButton(_previousButton);
            SetupNextButton(_nextButton);
            SetupSkipButton(_skipButton);
        }

        protected override void BindControls()
        {
            var set = this.CreateBindingSet<OnboardingViewController, IOnboardingViewModel>();

            BindCollectionView(_collectionView, set);
            BindPageControl(_pageControl, set);
            //BindPreviousButton(_previousButton, set);
            BindNextButton(_nextButton, set);
            BindSkipButton(_skipButton, set);

            set.Apply();
        }

        #endregion

        #region InitializationControls

        protected virtual void SetupCollectionView(UICollectionView collectionView)
        {
            collectionView.RegisterNibForCell(OnboardingPageCell.Nib, OnboardingPageCell.Key);

            collectionView.BackgroundColor = View.BackgroundColor;

            var flowLayout = collectionView.CollectionViewLayout as UICollectionViewFlowLayout;
            flowLayout.ItemSize = new CGSize(DeviceInfo.ScreenWidth, DeviceInfo.ScreenHeight);
        }

        protected virtual void SetupPageControl(UIPageControl pageControl)
        {
            pageControl.PageIndicatorTintColor = "8E959C".ToUIColor();
            pageControl.CurrentPageIndicatorTintColor = "1E2C3A".ToUIColor();
        }

        protected virtual void SetupPreviousButton(UIButton previousButton)
        {
            previousButton.SetupStyle(Theme.ControlPalette.Button.Base);
        }

        protected virtual void SetupNextButton(UIButton nextButton)
        {
            nextButton.SetupStyle(Theme.ControlPalette.Button.Base);
        }

        protected virtual void SetupSkipButton(UIButton skipButton)
        {

        }

        #endregion

        #region BinfingControls

        protected virtual HorizontalPagingCollectionViewSource SetupCollectionViewSource(UICollectionView collectionView)
        {
            return new HorizontalPagingCollectionViewSource(collectionView, OnboardingPageCell.Key) { AutoScrollAfterChangingPage = true };
        }

        protected virtual void BindCollectionView(UICollectionView collectionView, MvxFluentBindingDescriptionSet<OnboardingViewController, IOnboardingViewModel> set)
        {
            var dataSource = SetupCollectionViewSource(collectionView);

            set.Bind(dataSource).To(vm => vm.Pages);
            set.Bind(dataSource).For(ds => ds.Page).To(vm => vm.CurrentPage);

            collectionView.Source = dataSource;
            collectionView.ReloadData();
        }

        protected virtual void BindPageControl(UIPageControl pageControl, MvxFluentBindingDescriptionSet<OnboardingViewController, IOnboardingViewModel> set)
        {
            set.Bind(pageControl).For("Pages").To(vm => vm.Pages.Count);
            set.Bind(pageControl).For(v => v.CurrentPage).To(vm => vm.CurrentPage).OneWay();
        }

        protected virtual void BindPreviousButton(UIButton previousButton, MvxFluentBindingDescriptionSet<OnboardingViewController, IOnboardingViewModel> set)
        {
            set.Bind(previousButton).To(vm => vm.PreviousCommand);
        }

        protected virtual void BindNextButton(UIButton nextButton, MvxFluentBindingDescriptionSet<OnboardingViewController, IOnboardingViewModel> set)
        {
            set.Bind(nextButton).To(vm => vm.NextCommand);
            set.Bind(nextButton).For("Title").To(vm => vm.IsLastPage).WithConversion("TrueFalse", new TrueFalseParameter { True = "Все ясно".ToUpper(), False = "Далее".ToUpper() });
            set.Bind(nextButton).For("Visibility").To(vm => vm.IsOnFirstLaunch).WithConversion("Visibility");
        }

        protected virtual void BindSkipButton(UIButton skipButton, MvxFluentBindingDescriptionSet<OnboardingViewController, IOnboardingViewModel> set)
        {
            set.Bind(skipButton).To(vm => vm.SkipCommand);
            set.Bind(skipButton).For("Visibility").To(vm => vm.IsOnFirstLaunch).WithConversion("InvertedVisibility");
        }

        #endregion
    }
}

