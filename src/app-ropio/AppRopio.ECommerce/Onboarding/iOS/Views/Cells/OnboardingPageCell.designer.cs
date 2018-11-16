// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Onboarding.iOS.Views.Cells
{
    [Register ("OnboardingPageCell")]
    partial class OnboardingPageCell
    {
        [Outlet]
        UIKit.UILabel _descriptionLabel { get; set; }


        [Outlet]
        UIKit.UIImageView _imageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_descriptionLabel != null) {
                _descriptionLabel.Dispose ();
                _descriptionLabel = null;
            }

            if (_imageView != null) {
                _imageView.Dispose ();
                _imageView = null;
            }
        }
    }
}