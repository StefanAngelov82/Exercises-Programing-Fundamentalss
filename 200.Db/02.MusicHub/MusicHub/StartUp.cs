namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Producers.First(p => p.Id == producerId)               
                .Albums.Select(a => new
                {
                    Produser = a.Producer!.Name,
                    AlbumName = a.Name,
                    RelaesDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name,

                    })
                        .OrderByDescending(s =>s.SongName)
                        .ThenBy(s => s.SongWriter),
                    TotalAlbumPrice = a.Price,
                })
                    .OrderByDescending(a => a.TotalAlbumPrice) 
                    .ToArray();

            StringBuilder sb = new();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.RelaesDate}");
                sb.AppendLine($"-ProducerName: {album.Produser}");
                sb.AppendLine("-Songs:");
               
                if (album.Songs.Any())
                {
                    int index = 1; 

                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{index++}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.SongPrice:F2}");
                        sb.AppendLine($"---Writer: {song.SongWriter}");
                    }
                }               

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().Trim();            
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.
                 AsEnumerable()
                 .Where(s => s.Duration.TotalSeconds > duration)
                 .Select(s => new
                 {
                     SongName = s.Name,
                     Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(n =>n).ToList(),

                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")             
                     
                 })
                 .OrderBy(s =>s.SongName)
                 .ThenBy(w => w.WriterName)
                 .ToList();


            StringBuilder sb = new();
             
            int index = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{index++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
