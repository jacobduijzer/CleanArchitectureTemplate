using Ardalis.GuardClauses;
using System;

namespace CleanArchitectureTemplate.Application.Shared
{
    public class ApplicationSettings : IApplicationSettings
    {
        internal ApplicationSettings(TimeSpan cacheDuration)
        {
            CacheDuration = cacheDuration;
        }

        public static ApplicationSettingsBuilder Builder => new ApplicationSettingsBuilder();
        public TimeSpan CacheDuration { get; }
    }

    public class ApplicationSettingsBuilder
    {
        private TimeSpan cacheDuration;

        public ApplicationSettingsBuilder WithCacheDuration(TimeSpan cacheDuration)
        {
            Guard.Against.Null(cacheDuration, "CacheDuration");
            this.cacheDuration = cacheDuration;
            return this;
        }

        public ApplicationSettings Build() =>
            new ApplicationSettings(cacheDuration);
    }
}
