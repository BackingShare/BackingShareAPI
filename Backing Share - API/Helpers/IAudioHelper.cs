using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Backing_Share___API.Helpers
{
    public interface IAudioHelper
    {
        Task CreateAsync(IConfiguration configuration);
        Task GetAsync();
    }
}