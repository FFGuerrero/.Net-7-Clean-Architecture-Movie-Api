using NUnit.Framework;

using static MovieApi.Application.IntegrationTests.Testing;

namespace MovieApi.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
