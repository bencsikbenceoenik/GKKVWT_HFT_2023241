using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GKKVWT_HFT_2023241.Client
{
    public class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SongDbContext ctx = new SongDbContext();
            ctx.Artists.Select(t => t.ArtistName).ToList().ForEach(t => Console.WriteLine(t));
            Console.WriteLine(ctx.Songs.First().Artist.ArtistName);
            Console.WriteLine(ctx.Songs.First().Label.LabelName);
            Console.WriteLine(ctx.Labels.Skip(1).First().LabelName);
            Console.WriteLine(ctx.Labels.Skip(1).First().Songs.Count);
            Console.WriteLine(ctx.Artists.First().Songs.Count);
            //Console.WriteLine("Using GIT!!!");
        }
    }
}
