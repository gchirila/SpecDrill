namespace SpecDrill.SecondaryPorts.AutomationFramework
{
    public interface IFrameElement<out T> : IElement
        where T: IPage
    {
        T SwitchTo();
    }
}