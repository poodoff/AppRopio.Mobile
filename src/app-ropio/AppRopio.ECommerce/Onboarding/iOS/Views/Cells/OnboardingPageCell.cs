using System;
using AppRopio.Base.Onboarding.Core.ViewModels.Items;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace AppRopio.Base.Onboarding.iOS.Views.Cells
{
    public partial class OnboardingPageCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("OnboardingPageCell");
        public static readonly UINib Nib = UINib.FromName("OnboardingPageCell", NSBundle.MainBundle);

        protected OnboardingPageCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                InitializeControls();
                BindControls();
            });
        }
        #region InitializationControls

        protected virtual void InitializeControls() 
        {
        }

        #endregion

        #region BindingControls

        protected virtual void BindControls()
        {
            var set = this.CreateBindingSet<OnboardingPageCell, IOnboardingPageVM>();

            //BindTitleLabel(_titleLabel, set);
            BindImageView(_imageView, set);
            BindDescriptionLabel(_descriptionLabel, set);

            set.Apply();
        }

        protected virtual void BindTitleLabel(UILabel titleLabel, MvxFluentBindingDescriptionSet<OnboardingPageCell, IOnboardingPageVM> set)
        {
            set.Bind(titleLabel).To(vm => vm.Title);
        }

        protected virtual void BindImageView(UIImageView imageView, MvxFluentBindingDescriptionSet<OnboardingPageCell, IOnboardingPageVM> set)
        {
            var imageLoader = new MvxImageViewLoader(() => imageView);

            set.Bind(imageLoader).To(vm => vm.Image);
        }

        protected virtual void BindDescriptionLabel(UILabel descriptionLabel, MvxFluentBindingDescriptionSet<OnboardingPageCell, IOnboardingPageVM> set)
        {
            set.Bind(descriptionLabel).To(vm => vm.Description);
        }

        #endregion
    }
}
