namespace FirstClassFeatureFlags.Feature;

public class MyService
{
    // NOTE: public for POC only; this would normally be private arg.
    public readonly MyFeatureFlag MyFeatureFlag;

    public MyService(MyFeatureFlag myFeatureFlag)
    {
        MyFeatureFlag = myFeatureFlag;
    }

    public bool CanDoFoo(string customerRegion)
    {
        if (MyFeatureFlag.ForRegion(customerRegion).IsEnabled())
        {
            return true;
        }
        
        return false;
    }
}