using ConsoleTools;
using GKKVWT_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace GKKVWT_HFT_2023241.Client
{
    public class Client
    {
        static RestService rest;

        static void Create(string entity)
        {
            switch (entity)
            {
                case "Song":
                    Console.WriteLine("Enter Song Name: ");
                    string songName = Console.ReadLine();
                    rest.Post(new Song() { SongTitle = songName }, "song");
                    break;
                case "Artist":
                    Console.WriteLine("Enter Artist Name: ");
                    string artistName = Console.ReadLine();
                    rest.Post(new Artist() { ArtistName = artistName }, "artist");
                    break;
                case "Label":
                    Console.WriteLine("Enter Label Name: ");
                    string labelName = Console.ReadLine();
                    rest.Post(new Label() { LabelName = labelName }, "label");
                    break;
            }
            Console.ReadLine();
        }

        static void List(string entity)
        {
            switch (entity)
            {
                case "Song":
                    var songs = rest.Get<Song>("song");
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in songs)
                    {
                        Console.WriteLine(item.SongId + "\t" + item.SongTitle);
                    }
                    break;
                case "Artist":
                    var artists = rest.Get<Artist>("artist");
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in artists)
                    {
                        Console.WriteLine(item.ArtistId + "\t" + item.ArtistName);
                    }
                    break;
                case "Label":
                    var labels = rest.Get<Label>("label");
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
            switch (entity)
            {
                case "Artist":
                    Console.Write("Enter Actor's id to update: ");
                    int artistId = int.Parse(Console.ReadLine());
                    Artist artistOne = rest.Get<Artist>(artistId, "artist");
                    Console.Write($"New name [old: {artistOne.ArtistName}]: ");
                    string artistName = Console.ReadLine();
                    artistOne.ArtistName = artistName;
                    rest.Put(artistOne, "artist");
                    break;
                case "Song":
                    Console.Write("Enter Song's id to update: ");
                    int songId = int.Parse(Console.ReadLine());
                    Song songOne = rest.Get<Song>(songId, "song");
                    Console.Write($"New name [old: {songOne.SongId}]: ");
                    string songName = Console.ReadLine();
                    songOne.SongTitle = songName;
                    rest.Put(songOne, "song");
                    break;
                case "Label":
                    Console.Write("Enter Label's id to update: ");
                    int labelId = int.Parse(Console.ReadLine());
                    Label labelOne = rest.Get<Label>(labelId, "label");
                    Console.Write($"New name [old: {labelOne.LabelName}]: ");
                    string labelName = Console.ReadLine();
                    labelOne.LabelName = labelName;
                    rest.Put(labelOne, "label");
                    break;
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            switch (entity)
            {
                case "Artist":
                    Console.WriteLine("Enter Artist's id to delete: ");
                    int artistId = int.Parse(Console.ReadLine());
                    rest.Delete(artistId, "artist");
                    break;
                case "Song":
                    Console.WriteLine("Enter Song's id to delete: ");
                    int songId = int.Parse(Console.ReadLine());
                    rest.Delete(songId, "song");
                    break;
                case "Label":
                    Console.WriteLine("Enter Label's id to delete: ");
                    int labelId = int.Parse(Console.ReadLine());
                    rest.Delete(labelId, "label");
                    break;
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:40338/", "song");

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
