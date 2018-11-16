using System;
namespace AppRopio.Base.Onboarding.Core.Enums
{
    public enum OnboardingPageType
    {
        /// <summary>
        /// Статичная информация
        /// </summary>
        Info = 0,

        /// <summary>
        /// Запрос разрешения на отправку пушей
        /// </summary>
        Push = 1,

        /// <summary>
        /// Запрос разрешения на мониторинг геопозиции
        /// </summary>
        Location = 2
    }
}
