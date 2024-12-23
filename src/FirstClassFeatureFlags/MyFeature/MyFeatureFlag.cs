using FirstClassFeatureFlags.UnitTests.FeatureFlags;

namespace FirstClassFeatureFlags.Feature;

public class MyFeatureFlag: FeatureFlag
{
    public const string Key = "MyFeatureFlag.IsEnabled";

    // eager loaded constructor
    public MyFeatureFlag(bool isEnabled) : base(isEnabled)
    {
    }

    // lazy loaded constructor
    public MyFeatureFlag(IFeatureFlagService featureFlagService) : base(featureFlagService, Key)
    {
    }
}