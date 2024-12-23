namespace FirstClassFeatureFlags.UnitTests.FeatureFlags;

public abstract class FeatureFlag
{
    private readonly IFeatureFlagService _featureFlagService;
    private readonly string _key;

    private readonly bool? _isEnabled;
    private string? _customerRegion;

    // eager loaded constructor
    protected FeatureFlag(bool isEnabled)
    {
        _isEnabled = isEnabled;
    }
    
    // lazy loaded constructor
    protected FeatureFlag(IFeatureFlagService featureFlagService, string key)
    {
        _featureFlagService = featureFlagService;
        _key = key;
    }

    public FeatureFlag ForRegion(string customerRegion)
    {
        _customerRegion = customerRegion;
        return this;
    }
    
    public bool IsEnabled()
    {
        if (_isEnabled.HasValue)
        {
            return _isEnabled.Value;
        }

        return _featureFlagService.GetBoolean(_key, _customerRegion);
    }
}