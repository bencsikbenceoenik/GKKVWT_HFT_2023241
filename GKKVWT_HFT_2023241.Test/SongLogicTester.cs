using GKKVWT_HFT_2023241.Logic.Classes;
using GKKVWT_HFT_2023241.Models;
using GKKVWT_HFT_2023241.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace GKKVWT_HFT_2023241.Test
{
    [TestFixture]
    public class SongLogicTester
    {
        SongLogic logic;
        Mock<IRepository<Song>> mockSongRepo;

        [SetUp]
        public void Init()
        {
            mockSongRepo = new Mock<IRepository<Song>>();
            mockSongRepo.Setup(m => m.ReadAll()).Returns(new List<Song>()
            {
                new Song("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Song("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Song("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Song("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable());
            logic = new SongLogic(mockSongRepo.Object);
        }

        [Test]
        public void GetSongsReleasedAfterYearByNationality_ShouldReturnFilteredSongs()
        {
            // Arrange
            var mockArtistRepository = new Mock<IRepository<Artist>>();
            var mockSongRepository = new Mock<IRepository<Song>>();

            var musicService = new SongLogic(mockSongRepository.Object, mockArtistRepository.Object);

            // Mock data
            var nationality = "TestNationality";
            var releaseYear = 2000;

            var artists = new List<Artist>
            {
                new Artist { ArtistId = 1, Nationality = nationality },
                new Artist { ArtistId = 2, Nationality = nationality },
                new Artist { ArtistId = 3, Nationality = "DifferentNationality" },
            };

            var songs = new List<Song>
            {
                new Song { SongId = 1, ArtistId = 1, ReleaseDate = new DateTime(2005, 1, 1) },
                new Song { SongId = 2, ArtistId = 2, ReleaseDate = new DateTime(2010, 1, 1) },
                new Song { SongId = 3, ArtistId = 3, ReleaseDate = new DateTime(2020, 1, 1) },
            };

            // Setup mock repositories
            mockArtistRepository.Setup(repo => repo.ReadAll()).Returns(artists.AsQueryable());
            mockSongRepository.Setup(repo => repo.ReadAll()).Returns(songs.AsQueryable());

            // Act
            var result = musicService.GetSongsReleasedAfterYearByNationality(releaseYear, nationality);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(song => song.ReleaseDate.Year > releaseYear && artists.Any(a => a.ArtistId == song.ArtistId && a.Nationality == nationality)));
        }

        [Test]
        public void GetSongsByLabelWithValueGreaterThan_ShouldReturnFilteredSongs()
        {
            // Arrange
            var mockLabelRepository = new Mock<IRepository<Label>>();
            var mockSongRepository = new Mock<IRepository<Song>>();

            var musicService = new SongLogic(mockSongRepository.Object, null, mockLabelRepository.Object);

            // Mock data
            var labelName = "TestLabel";
            var label = new Label { LabelId = 1, LabelName = labelName, LabelValue = 50.0 };

            var songs = new List<Song>
            {
                new Song { SongId = 1, LabelId = label.LabelId, SongTitle = "Song1" },
                new Song { SongId = 2, LabelId = label.LabelId, SongTitle = "Song2" },
                new Song { SongId = 3, LabelId = 2, SongTitle = "Song3" }, // Different label
            };

            // Setup mock repositories
            mockLabelRepository.Setup(repo => repo.ReadAll()).Returns(new List<Label> { label }.AsQueryable());
            mockSongRepository.Setup(repo => repo.ReadAll()).Returns(songs.AsQueryable());

            // Act
            var result = musicService.GetSongsByLabelWithValueGreaterThan(40.0, labelName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(song => song.LabelId == label.LabelId && label.LabelValue > 40.0));
        }

        [Test]
        public void GetSongsByArtistsDebutedAfterYear_ShouldReturnFilteredSongs()
        {
            // Arrange
            var mockArtistRepository = new Mock<IRepository<Artist>>();
            var mockSongRepository = new Mock<IRepository<Song>>();

            var musicService = new SongLogic(mockSongRepository.Object, mockArtistRepository.Object);

            // Mock data
            var artists = new List<Artist>
            {
                new Artist { ArtistId = 1, DebutYear = 2010 },
                new Artist { ArtistId = 2, DebutYear = 2005 },
                new Artist { ArtistId = 3, DebutYear = 2015 },
            };

            var songs = new List<Song>
            {
                new Song { ArtistId = 1, SongTitle = "Song1" },
                new Song { ArtistId = 2, SongTitle = "Song2" },
                new Song { ArtistId = 3, SongTitle = "Song3" },
            };

            // Setup mock repositories
            mockArtistRepository.Setup(repo => repo.ReadAll()).Returns(artists.AsQueryable());
            mockSongRepository.Setup(repo => repo.ReadAll()).Returns(songs.AsQueryable());

            // Act
            var result = musicService.GetSongsByArtistsDebutedAfterYear(2010);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(song => artists.Any(a => a.ArtistId == song.ArtistId && a.DebutYear > 2010)));
        }

        [Test]
        public void GetSongsByDurationAndArtistGender_ShouldReturnFilteredSongs()
        {
            // Arrange
            var mockArtistRepository = new Mock<IRepository<Artist>>();
            var mockSongRepository = new Mock<IRepository<Song>>();

            var service = new SongLogic(mockSongRepository.Object, mockArtistRepository.Object);

            // Mock data
            var artists = new List<Artist>
            {
                new Artist { ArtistId = 1, Gender = "Male" },
                new Artist { ArtistId = 2, Gender = "Female" },
                new Artist { ArtistId = 3, Gender = "Male" },
            };

            var songs = new List<Song>
            {
                new Song { ArtistId = 1, Duration = 120 },
                new Song { ArtistId = 2, Duration = 90 },
                new Song { ArtistId = 3, Duration = 150 },
            };

            // Setup mock repositories
            mockArtistRepository.Setup(repo => repo.ReadAll()).Returns(artists.AsQueryable());
            mockSongRepository.Setup(repo => repo.ReadAll()).Returns(songs.AsQueryable());

            // Act
            var result = service.GetSongsByDurationAndArtistGender(100, "Male");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(song => song.Duration > 100 && artists.Any(a => a.ArtistId == song.ArtistId && a.Gender == "Male")));
        }

        [Test]
        public void ReadAll_ShouldReturnAllItemsFromRepository()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Song>>();
            var service = new SongLogic(mockRepository.Object);
            var data = new List<Song>()
            {
                new Song("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Song("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Song("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Song("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable();
            mockRepository.Setup(repo => repo.ReadAll()).Returns(data);
            // Act
            var result = service.ReadAll();
            // Assert
            Assert.AreEqual(data, result);
        }

        [Test]
        public void UpdateSongWithCorrectInput()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Song>>();
            var logic = new SongLogic(mockRepository.Object);
            var song = new Song() { SongTitle = "TestSong" };

            // Act
            logic.Update(song);

            // Assert
            mockRepository.Verify(r => r.Update(song), Times.Once);
        }

        [Test]
        public void CreateSongTestWithCorrectTitle()
        {
            var song = new Song() { SongTitle = "Batter Up" };
            //ACT
            logic.Create(song);
            //ASSERT
            mockSongRepo.Verify(r => r.Create(song), Times.Once);
        }

        [Test]
        public void CreateSongTestWithNullTitle()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Song>>();
            var logic = new SongLogic(mockRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => logic.Create(null));
        }

        [Test]
        public void CreateSongTestWithInCorrectTitle()
        {
            var song = new Song() { SongTitle = "less" };
            try
            {
                //ACT
                logic.Create(song);
            }
            catch
            {

            }
            //ASSERT
            mockSongRepo.Verify(r => r.Create(song), Times.Never);
        }
    }
}
