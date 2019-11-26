using Backing_Share___API.Models;
using Backing_Share___API.Models.Database;
using System.Linq;

namespace Backing_Share___API.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        public void StoreInDB(string location, string filename, int project, int userId)
        {
            using (BackingShareContext db = new BackingShareContext())
            {
                Audio dbAudio = new Audio()
                {
                    name = filename,
                    userId = userId
                };
                db.Audio.Add(dbAudio);
                db.SaveChanges();
                Audio audio = db.Audio.Where(r => r.name == filename).FirstOrDefault();

                ProjectsXAudios dbProjectsXAudios = new ProjectsXAudios()
                {
                    audioId = audio.Id,
                    projectId = project
                };
                db.ProjectsXAudios.Add(dbProjectsXAudios);
                db.SaveChanges();

            }
            
        }
    }
}
