// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppRopio.Base.Onboarding.iOS.Views
{
	[Register ("OnboardingViewController")]
	partial class OnboardingViewController
	{
		[Outlet]
		UIKit.UICollectionView _collectionView { get; set; }

		[Outlet]
		UIKit.UIButton _nextButton { get; set; }

		[Outlet]
		UIKit.UIPageControl _pageControl { get; set; }

		[Outlet]
		UIKit.UIButton _skipButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_skipButton != null) {
				_skipButton.Dispose ();
				_skipButton = null;
			}

			if (_collectionView != null) {
				_collectionView.Dispose ();
				_collectionView = null;
			}

			if (_nextButton != null) {
				_nextButton.Dispose ();
				_nextButton = null;
			}

			if (_pageControl != null) {
				_pageControl.Dispose ();
				_pageControl = null;
			}
		}
	}
}
