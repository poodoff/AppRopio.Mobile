using System;
using System.Collections.Generic;
using AppRopio.Base.Onboarding.Core.Enums;
namespace AppRopio.Base.Onboarding.Core.Models
{
    public class OnboardingConfig
    {
        /// <summary>
        /// Конфигурация страниц опбоардинга
        /// </summary>
        public List<OnboardingPage> OnboardingPages { get; set; }

        public string AfterFirstLaunchType { get; set; }
    }

    public class OnboardingPage
    {
        /// <summary>
        /// Название страницы онбоардинга
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Путь до иконки пункта меню (должен начинаться с "res:", если иконка локальная)
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Описание, отображаемое на странице
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип поведения страницы
        /// </summary>
        public OnboardingPageType Type { get; set; }
    }
}
