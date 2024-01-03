using ReserveTeste.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTeste.Core.Services
{
    public interface IServiceCountry
    {
        public Task<Root> CallApi();
        public Task<IEnumerable<CountryResponse>> GetCountryResponse();
    }
}
