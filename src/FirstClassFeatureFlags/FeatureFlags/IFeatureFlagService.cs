namespace FirstClassFeatureFlags.UnitTests.FeatureFlags;

public interface IFeatureFlagService
{
    public bool GetBoolean(string key);
    public bool GetBoolean(string key, string? customerRegion);
}