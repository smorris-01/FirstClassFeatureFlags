using FirstClassFeatureFlags.Feature;
using Shouldly;

namespace FirstClassFeatureFlags.UnitTests.GivenAnEagerLoadedFlag.WhenUsedInTests;

public class ThenTheFlag
{
    [Fact]
    public void CanBeManuallyInjectedForTesting()
    {
        var flag = new MyFeatureFlag(true);
        var service = new MyService(flag);

        service.MyFeatureFlag.IsEnabled().ShouldBeTrue();
    }
}