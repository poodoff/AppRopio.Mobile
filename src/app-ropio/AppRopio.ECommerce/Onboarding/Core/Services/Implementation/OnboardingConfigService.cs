using System;
using System.IO;
using AppRopio.Base.Core;
using AppRopio.Base.Core.Services.Settings;
using AppRopio.Base.Onboarding.Core.Models;
using MvvmCross.Platform;

namespace AppRopio.Base.Onboarding.Core.Services.Implementation
{
    public class OnboardingConfigService : IOnboardingConfigService
    {
        #region Properties

        private OnboardingConfig _config;
        public OnboardingConfig Config => _config ?? (_config = LoadConfigFromJSON());

        #endregion

        #region Private

        private OnboardingConfig LoadConfigFromJSON()
        {
            var path = Path.Combine(CoreConstants.CONFIGS_FOLDER, OnboardingConstants.CONFIG_NAME);
            var json = Mvx.Resolve<ISettingsService>().ReadStringFromFile(path);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OnboardingConfig>(json);
        }

        #endregion
    }
}
