using FirstClassFeatureFlags.Feature;
using Shouldly;

namespace FirstClassFeatureFlags.UnitTests.GivenALazyLoadedFlag.WhenUsedInTests;

public class ThenTheFlag
{
    [Fact]
    public void CanBeManuallyInjectedForTestingLikeAnEagerLoadedFlag()
    {
        var flag = new MyFeatureFlag(true);

        var service = new MyService(flag);
        service.MyFeatureFlag.IsEnabled().ShouldBeTrue();
    }
}