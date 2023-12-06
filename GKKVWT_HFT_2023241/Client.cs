using ConsoleTools;
using GKKVWT_HFT_2023241.Logic.Classes;
using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Database;
using GKKVWT_HFT_2023241.Repository.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace GKKVWT_HFT_2023241.Client
{
    public class Client
    {
        static SongLogic songLogic;
        static ArtistLogic artistLogic;
        static LabelLogic labelLogic;

        static void Create(string entity)
        {
            switch (entity)
            {
                case "Song":
                    Console.WriteLine("Enter Song Name: ");
                    string songName = Console.ReadLine();
                    songLogic.Create(new Song() { SongTitle = songName});
                    break;
                case "Artist":
                    Console.WriteLine("Enter Artist Name: ");
                    string artistName = Console.ReadLine();
                    artistLogic.Create(new Artist() { ArtistName = artistName });
                    break;
                case "Label":
                    Console.WriteLine("Enter Label Name: ");
                    string labelName = Console.ReadLine();
                    labelLogic.Create(new Label() { LabelName = labelName });
                    break;
            }
            Console.ReadLine();
        }

        static void List(string entity)
        {
            //if (entity == "Actor")
            //{
            //    List<Actor> actors = rest.Get<Actor>("actor");
            //    foreach (var item in actors)
            //    {
            //        Console.WriteLine(item.ActorId + ": " + item.ActorName);
            //    }
            //}


            switch (entity)
            {
                case "Song":
                    var songs = songLogic.ReadAll();
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in songs)
                    {
                        Console.WriteLine(item.SongId + "\t" + item.SongTitle);
                    }
                    break;
                case "Artist":
                    var artists = artistLogic.ReadAll();
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in artists)
                    {
                        Console.WriteLine(item.ArtistId + "\t" + item.ArtistName);
                    }
                    break;
                case "Label":
                    var labels = labelLogic.ReadAll();
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in labels)
                    {
                        Console.WriteLine(item.LabelId + "\t" + item.LabelName);
                    }
                    break;
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {

            //if (entity == "Actor")
            //{
            //    Console.Write("Enter Actor's id to update: ");
            //    int id = int.Parse(Console.ReadLine());
            //    Actor one = rest.Get<Actor>(id, "actor");
            //    Console.Write($"New name [old: {one.ActorName}]: ");
            //    string name = Console.ReadLine();
            //    one.ActorName = name;
            //    rest.Put(one, "actor");
            //}

            switch (entity)
            {
                case "Artist":
                    Console.Write("Enter Actor's id to update: ");
                    int artistId = int.Parse(Console.ReadLine());
                    Artist artistOne = artistLogic.Read(artistId);
                    Console.Write($"New name [old: {artistOne.ArtistName}]: ");
                    string artistName = Console.ReadLine();
                    artistOne.ArtistName = artistName;
                    artistLogic.Update(artistOne);
                    break;
                case "Song":
                    Console.Write("Enter Song's id to update: ");
                    int songId = int.Parse(Console.ReadLine());
                    Song songOne = songLogic.Read(songId);
                    Console.Write($"New name [old: {songOne.SongId}]: ");
                    string songName = Console.ReadLine();
                    songOne.SongTitle = songName;
                    songLogic.Update(songOne);
                    break;
                case "Label":
                    Console.Write("Enter Label's id to update: ");
                    int labelId = int.Parse(Console.ReadLine());
                    Label labelOne = labelLogic.Read(labelId);
                    Console.Write($"New name [old: {labelOne.LabelName}]: ");
                    string labelName = Console.ReadLine();
                    labelOne.LabelName = labelName;
                    labelLogic.Update(labelOne);
                    break;
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {

            //if (entity == "Actor")
            //{
            //    Console.Write("Enter Actor's id to delete: ");
            //    int id = int.Parse(Console.ReadLine());
            //    rest.Delete(id, "actor");
            //}

            switch (entity)
            {
                case "Artist":
                    Console.WriteLine("Enter Artist's id to delete: ");
                    int artistId = int.Parse(Console.ReadLine());
                    artistLogic.Delete(artistId);
                    break;
                case "Song":
                    Console.WriteLine("Enter Song's id to delete: ");
                    int songId = int.Parse(Console.ReadLine());
                    songLogic.Delete(songId);
                    break;
                case "Label":
                    Console.WriteLine("Enter Label's id to delete: ");
                    int labelId = int.Parse(Console.ReadLine());
                    labelLogic.Delete(labelId);
                    break;
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            var ctx = new SongDbContext();

            var songRepo = new SongRepository(ctx);
            var artistRepo = new ArtistRepository(ctx);
            var labelRepo = new LabelRepository(ctx);

            songLogic = new SongLogic(songRepo);
            artistLogic = new ArtistLogic(artistRepo);
            labelLogic = new LabelLogic(labelRepo);

            var songSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Exit", ConsoleMenu.Close);

            var artistSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("Exit", ConsoleMenu.Close);

            var labelSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Label"))
                .Add("Create", () => Create("Label"))
                .Add("Delete", () => Delete("Label"))
                .Add("Update", () => Update("Label"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Labels", () => labelSubMenu.Show())
                .Add("Songs", () => songSubMenu.Show())
                .Add("Artists", () => artistSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
