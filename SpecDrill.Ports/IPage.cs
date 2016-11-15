using System;

namespace SpecDrill.SecondaryPorts.AutomationFramework
{
    public interface IPage : IElement, IDisposable
    {
        string Title { get; }
        bool IsLoaded { get; }
        void WaitForSilence();
        void RefreshPage();
    }
}
