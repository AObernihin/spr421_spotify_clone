using spr421_spotify_clone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.DAL.Repositories.Track
{
    public class TrackRepository : GenericRepository<TrackEntity>, ITrackRepository
    {
        public TrackRepository(AppDbContext context) : base(context) {   }

        public IQueryable<TrackEntity> tracks => GetAll();
    }
}
