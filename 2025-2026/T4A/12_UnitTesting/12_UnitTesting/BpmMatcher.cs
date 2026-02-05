using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_UnitTesting
{
    public class BpmMatcher
    {
        // Najde vinyly s podobným BPM (±tolerance)
        public List<Vinyl> FindMatchingVinyls(List<Vinyl> collection, int targetBpm, int tolerance)
        {
            return collection
                .Where(v => Math.Abs(v.Bpm - targetBpm) <= tolerance)
                .ToList();
        }

        // Kontrola, jestli je mix kompatibilní (max rozdíl 10 BPM mezi sousedy)
        public bool IsMixCompatible(List<Vinyl> playlist)
        {
            for (int i = 0; i < playlist.Count - 1; i++)
            {
                if (Math.Abs(playlist[i].Bpm - playlist[i + 1].Bpm) > 10)
                    return false;
            }
            return true;
        }
    }

    // TESTY:
    // - FindMatchingVinyls s prázdným seznamem
    // - FindMatchingVinyls s tolerance 0, 5, 10
    // - IsMixCompatible s kompatibilním playlistem
    // - IsMixCompatible s nekompatiblním playlistem
}
