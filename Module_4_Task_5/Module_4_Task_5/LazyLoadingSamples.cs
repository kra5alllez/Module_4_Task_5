using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module_4_Task_5
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async Task TaskOne()
        {
            var data = await _context.Songs.
                Select(c => new { SongTitle = c.Title, Genre = c.Gener.Title, NameArtist = c.Artists
                .Select(e => e.Name)})
                .Where(g => g.NameArtist
                .First() != null && g.Genre != null)
                .ToListAsync();

            foreach (var song in data)
            {
                Console.WriteLine($"SongTitle: {song.SongTitle} . Genre :{song.Genre} . Artist: {string.Join(", ", song.NameArtist)}");
            }
        }

        public async Task TaskTwo()
        {
            var data = await _context.Songs.GroupBy(g => g.Gener.Title).
                Select(n => new { n.Key, Count = n.Count() }).ToListAsync();

            foreach (var dif in data)
            {
                Console.WriteLine($"Name Genre: {dif.Key} Count Songs : {dif.Count}");
            }
        }

        public async Task TaskThree()
        {
            var oldSongs = await _context.Songs
                .Where(s => s.ReleaseDate < s.Artists
                .Select(e=>e.DateOfBirth)
                .OrderByDescending(e=>e)
                .First()).ToListAsync();
            foreach (var dif in oldSongs)
            {
                Console.WriteLine($"Name Song: {dif.Title}");
            }
        }
    }
}
