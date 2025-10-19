using spr421_spotify_clone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.DAL.Repositories.Track
{
    public interface ITrackRepository : IGenericRepository<TrackEntity>
    {
        IQueryable<TrackEntity> tracks { get; }
    }
}
