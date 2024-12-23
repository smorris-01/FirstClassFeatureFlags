using FirstClassFeatureFlags.Feature;
using FirstClassFeatureFlags.UnitTests.FeatureFlags;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace FirstClassFeatureFlags.UnitTests.GivenALazyLoadedFlag.WhenUsedInProductCode;

public class ThenTheFlag
{
    private readonly ServiceCollection _services;

    public ThenTheFlag()
    {
        _services = new ServiceCollection();

        _services.AddScoped<IFeatureFlagService, FeatureFlagService>();

        _services.AddScoped<MyFeatureFlag>(sp =>
        {
            var featureFlagService = sp.GetRequiredService<IFeatureFlagService>();
            var isEnabled = featureFlagService.GetBoolean(MyFeatureFlag.Key);

            return new MyFeatureFlag(isEnabled);
        });
    }

    private IServiceProvider BuildServiceProvider()
    {
        return _services.BuildServiceProvider();
    }

    [Fact]
    public void IsResolvable()
    {
        var flag = BuildServiceProvider().GetRequiredService<MyFeatureFlag>();
    }

    [Fact]
    public void IsAbleToAnswer()
    {
        var flag = BuildServiceProvider().GetRequiredService<MyFeatureFlag>();
        flag.ForRegion("AUS").IsEnabled().ShouldBe(true);
    }

    [Fact]
    public void IsInjectable()
    {
        _services.AddScoped<MyService>();

        var service = BuildServiceProvider().GetRequiredService<MyService>();
        service.MyFeatureFlag.ForRegion("AUS").IsEnabled().ShouldBeTrue();
    }

    [Fact]
    public void IsAbleToDeferTheDecisionToRuntime()
    {
        _services.AddScoped<MyService>();

        var service = BuildServiceProvider().GetRequiredService<MyService>();
        service.CanDoFoo("AUS").ShouldBeTrue();
    }
}