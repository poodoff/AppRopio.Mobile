using System;
using AppRopio.Base.Onboarding.Core.Enums;
using AppRopio.Base.Onboarding.Core.Models;
using MvvmCross.Core.ViewModels;
namespace AppRopio.Base.Onboarding.Core.ViewModels.Items
{
    public class OnboardingPageVM : MvxViewModel, IOnboardingPageVM
    {
        #region Properties

        private string _title;
        public string Title
        {
            get => _title;
            protected set => SetProperty(ref _title, value, nameof(Title));
        }

        private string _image;
        public string Image
        {
            get => _image;
            protected set => SetProperty(ref _image, value, nameof(Image));
        }

        private string _description;
        public string Description
        {
            get => _description;
            protected set => SetProperty(ref _description, value, nameof(Description));
        }

        private OnboardingPageType _type;
        public OnboardingPageType Type
        {
            get => _type;
            protected set => SetProperty(ref _type, value, nameof(Type));
        }

        #endregion

        #region Commands

        private IMvxCommand _typeCommand;
        public IMvxCommand TypeCommand => _typeCommand ?? (_typeCommand = new MvxCommand(OnTypeExecute));

        #endregion

        public OnboardingPageVM(OnboardingPage page)
        {
            Title = page.Title;
            Image = page.Image;
            Description = page.Description;
            Type = page.Type;
        }

        protected virtual void OnTypeExecute()
        {
            switch (Type)
            {
                case OnboardingPageType.Push:
                    //TODO ask push permission
                    break;
                case OnboardingPageType.Location:
                    //TODO ask location permission
                    break;
                default:
                    break;
            }
        }
    }
}
