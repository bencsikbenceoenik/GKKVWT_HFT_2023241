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
        Mock<IRepository<Artist>> mockArtistRepo;
        Mock<IRepository<Label>> mockLabelRepo;

        [SetUp]
        public void Init()
        {
            mockSongRepo = new Mock<IRepository<Song>>();
            mockArtistRepo = new Mock<IRepository<Artist>>();
            mockLabelRepo = new Mock<IRepository<Label>>();
            mockSongRepo.Setup(m => m.ReadAll()).Returns(new List<Song>()
            {
                new Song("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Song("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Song("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Song("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable());
            mockArtistRepo.Setup(m => m.ReadAll()).Returns(new List<Artist>()
            {
                new Artist("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Artist("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Artist("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Artist("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable());
            mockLabelRepo.Setup(m => m.ReadAll()).Returns(new List<Label>()
            {
                new Label("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Label("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Label("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Label("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable());
            logic = new SongLogic(mockSongRepo.Object,mockArtistRepo.Object,mockLabelRepo.Object);
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
