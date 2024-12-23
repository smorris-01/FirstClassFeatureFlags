namespace FirstClassFeatureFlags.UnitTests.FeatureFlags;

public class FeatureFlagService : IFeatureFlagService
{
    // inject LaunchDarkly, Split.IO, IFeatureManager, etc

    public bool GetBoolean(string key)
    {
        return true;
    }

    public bool GetBoolean(string key, string? customerRegion)
    {
        // defer to LaunchDarkly, Split.IO, IFeatureManager, etc
        return customerRegion switch
        {
            "AUS" => true,
            "CAN" => false,
            _ => false
        };
    }
}