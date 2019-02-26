using System;

namespace CleanArchitectureTemplate.Application.Shared
{
    public interface IApplicationSettings
    {
        TimeSpan CacheDuration { get; }
    }
}
