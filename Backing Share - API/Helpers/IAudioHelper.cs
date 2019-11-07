using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backing_Share___API.Helpers
{
    public interface IAudioHelper
    {
        Task CreateAsync(string location);
        Task GetAsync();
        Task DownloadFile(string filename, string location);
        Task<List<string>> GetAllAsync();
    }
}