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
        Mock<IRepository<Song>> mockMovieRepo;

        [SetUp]
        public void Init()
        {
            mockMovieRepo = new Mock<IRepository<Song>>();
            mockMovieRepo.Setup(m => m.ReadAll()).Returns(new List<Song>()
            {
                new Song("1#SongA#Type#2016-09-14#200#English#1#2#"),
                new Song("2#SongB#Type#2016-12-30#193#English#2#1#"),
                new Song("3#SongC#Type#2020-01-11#212#Korean#3#3#"),
                new Song("4#SongD#Type#2022-05-01#224#Korean#4#4#"),
            }.AsQueryable());
            logic = new SongLogic(mockMovieRepo.Object);
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
            mockMovieRepo.Verify(r => r.Create(song), Times.Never);
        }
    }
}
