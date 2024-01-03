using ReserveTeste.Core.Services;

namespace Reserve.Core.Test
{
    public class UnitTest
    {
        [Fact(DisplayName = "Testing api")]
        public void CallApi()
        {
            var totalResult = 190;
            Assert.Equal(new ServiceCountry().CallApi().Result.Countries.Count, totalResult);
        }
    }
}