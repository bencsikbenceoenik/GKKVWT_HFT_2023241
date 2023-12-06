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
