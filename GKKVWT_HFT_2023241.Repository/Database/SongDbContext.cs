using GKKVWT_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GKKVWT_HFT_2023241.Repository.Database
{
    public class SongDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Label> Labels { get; set; }

        public SongDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("musicdb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
            .HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Label)
                .WithMany(l => l.Songs)
                .HasForeignKey(s => s.LabelId);

            modelBuilder.Entity<Artist>().HasData(
            new Artist("1#BTS#1993-12-04#2013#Group#Male#South Korean#"),
            new Artist("2#BLACKPINK#1996-01-03#2016#Group#Female#South Korean#"),
            new Artist("3#EXO#1992-09-21#2012#Group#Male#South Korean#"),
            new Artist("4#TWICE#1999-02-01#2015#Group#Female#South Korean#"),
            new Artist("5#Red Velvet#1991-03-29#2014#Group#Female#South Korean#"),
            new Artist("6#ITZY#2000-08-20#2019#Group#Female#South Korean#"),
            new Artist("7#NCT 127#1995-07-01#2016#Group#Male#South Korean#"),
            new Artist("8#Stray Kids#2000-09-14#2018#Group#Male#South Korean#"),
            new Artist("9#EXID#1991-08-12#2012#Group#Female#South Korean#"),
            new Artist("10#Monsta X#1993-01-26#2015#Group#Male#South Korean#"),
            new Artist("11#Mamamoo#1991-06-19#2014#Group#Female#South Korean#"),
            new Artist("12#(G)I-DLE#1998-08-14#2018#Group#Female#South Korean#"),
            new Artist("13#ENHYPEN#2002-12-01#2020#Group#Male#South Korean#"),
            new Artist("14#ATEEZ#1998-10-24#2018#Group#Male#South Korean#"),
            new Artist("15#GFriend#1997-09-23#2015#Group#Female#South Korean#"),
            new Artist("16#Tomorrow X Together#2001-12-05#2019#Group#Male#South Korean#"),
            new Artist("17#Everglow#1999-03-18#2019#Group#Female#South Korean#"),
            new Artist("18#IZ*ONE#1998-04-29#2018#Group#Female#South Korean#"),
            new Artist("19#Super Junior#1983-11-06#2005#Group#Male#South Korean#"),
            new Artist("20#Dreamcatcher#1997-05-09#2014#Group#Female#South Korean#"),
            new Artist("21#CLC#1997-03-19#2015#Group#Female#South Korean#"),
            new Artist("22#LOONA#1996-11-21#2016#Group#Female#South Korean#"),
            new Artist("23#IVE#2001-06-27#2021#Group#Female#South Korean#"),
            new Artist("24#PURPLE KISS#2001-12-09#2021#Group#Female#South Korean#"),
            new Artist("25#TRI.BE#2005-01-07#2021#Group#Female#South Korean#"),
            new Artist("26#STAYC#2002-01-08#2020#Group#Female#South Korean#"),
            new Artist("27#Ed Sheeran#1991-02-17#2004#Solo#Male#British#"),
            new Artist("28#Ariana Grande#1993-06-26#2011#Solo#Female#American#"),
            new Artist("29#Justin Bieber#1994-03-01#2008#Solo#Male#Canadian#"),
            new Artist("30#Taylor Swift#1989-12-13#2006#Solo#Female#American#"),
            new Artist("31#Billie Eilish#2001-12-18#2015#Solo#Female#American#"),
            new Artist("32#Maroon 5#1994-03-27#1994#Group#Mixed#American#"),
            new Artist("33#Adele#1988-05-05#2006#Solo#Female#British#"),
            new Artist("34#Coldplay#1996-03-02#1996#Group#Mixed#British#"),
            new Artist("35#Shawn Mendes#1998-08-08#2013#Solo#Male#Canadian#"),
            new Artist("36#Selena Gomez#1992-07-22#2002#Solo#Female#American#"),
            new Artist("37#Demi Lovato#1992-08-20#2008#Solo#Female#American#"),
            new Artist("38#Dua Lipa#1995-08-22#2015#Solo#Female#British#"),
            new Artist("39#Bruno Mars#1985-10-08#2010#Solo#Male#American#"),
            new Artist("40#Ava Max#1993-02-16#2016#Solo#Female#American#"),
            new Artist("41#Lewis Capaldi#1996-10-07#2017#Solo#Male#British#"),
            new Artist("42#IU#1993-05-16#2008#Solo#Female#South Korean#"),
            new Artist("43#Sam Smith#1992-05-19#2012#Solo#Non-binary#British#"),
            new Artist("44#Khalid#1998-02-11#2016#Solo#Male#American#"),
            new Artist("45#ZAYN#1993-01-12#2010#Solo#Male#British#"),
            new Artist("46#Camila Cabello#1997-03-03#2012#Solo#Female#American#"),
            new Artist("47#Anne-Marie#1991-04-07#2013#Solo#Female#British#"),
            new Artist("48#Lauv#1994-08-08#2014#Solo#Male#American#"),
            new Artist("49#Katy Perry#1984-10-25#2001#Solo#Female#American#"),
            new Artist("50#CHUNG HA#1996-02-09#2016#Solo#Female#South Korean#"),
            new Artist("51#Halsey#1994-09-29#2012#Solo#Non-binary#American#"),
            new Artist("52#Day6#1999-09-06#2015#Group#Mixed#South Korean#"),
            new Artist("53#SEVENTEEN#1996-02-18#2015#Group#Male#South Korean#"),
            new Artist("54#The Weeknd#1990-02-16#2010#Solo#Male#Canadian#"),
            new Artist("55#Lizzo#1988-04-27#2011#Solo#Female#American#"),
            new Artist("56#Zara Larsson#1997-12-16#2012#Solo#Female#Swedish#")
            );

            modelBuilder.Entity<Song>().HasData(
                new Song("1#Dynamite#Single#2020-08-21#229#English#1#2#"),
                new Song("2#Butter#Single#2021-05-21#197#English#1#2#"),
                new Song("3#Permission to Dance#Single#2021-07-09#184#English#1#2#"),
                new Song("4#Life Goes On#Album#2020-11-20#225#Korean#1#2#"),
                new Song("5#Boy with Luv#Album#2019-04-12#229#Korean#1#2#"),
                new Song("6#ON#Album#2020-02-21#255#Korean#1#2#"),
                new Song("7#Idol#Album#2018-08-24#211#Korean#1#2#"),
                new Song("8#Fake Love#Album#2018-05-18#242#Korean#1#2#"),
                new Song("9#Blood Sweat & Tears#Album#2016-10-10#223#Korean#1#2#"),
                new Song("10#Spring Day#Album#2017-02-13#284#Korean#1#2#"),
                new Song("11#DNA#Album#2017-09-18#224#Korean#1#2#"),
                new Song("12#Mic Drop#Album#2017-09-18#234#Korean#1#2#"),
                new Song("13#Not Today#Album#2017-02-20#201#Korean#1#2#"),
                new Song("14#I Need U#Album#2015-04-29#229#Korean#1#2#"),
                new Song("15#War of Hormone#Album#2014-10-21#205#Korean#1#2#"),
                new Song("16#Danger#Album#2014-08-20#207#Korean#1#2#"),
                new Song("17#Boy in Luv#Album#2014-02-12#228#Korean#1#2#"),
                new Song("18#No More Dream#Album#2013-06-12#223#Korean#1#2#")
                );

            modelBuilder.Entity<Label>().HasData(
            new Label("1#YG Entertainment#3.5 Billion#South Korea#1996-08-08#Yang Hyun-suk#"),
            new Label("2#Big Hit Entertainment#1 Billion#South Korea#2005-02-01#Bang Si-hyuk#"),
            new Label("3#SM Entertainment#1.5 Billion#South Korea#1995-02-14#Lee Soo-man#"),
            new Label("4#JYP Entertainment#2 Billion#South Korea#1997-01-16#Park Jin-young#"),
            new Label("5#Banana Culture#500 Million#South Korea#2012-08-13#Shinsadong Tiger#"),
            new Label("6#Starship Entertainment#1 Billion#South Korea#2014-05-14#Kim Shi-dae#"),
            new Label("7#RBW#200 Million#South Korea#2014-06-19#Kim Do-hoon#"),
            new Label("8#Cube Entertainment#120 Million#South Korea#2018-05-02#Hong Seung-sung#"),
            new Label("9#Belift Lab#150 Million#South Korea#2020-11-30#Bang Si-hyuk#"),
            new Label("10#KQ Entertainment#50 Million#South Korea#2018-10-24#Kim Gyu-wook#"),
            new Label("11#Source Music#20 Million#South Korea#2015-01-15#So Sung-jin#"),
            new Label("12#Happy Face Entertainment#10 Million#South Korea#2014-09-18#Lee Jong-min#"),
            new Label("13#Cube Entertainment#120 Million#South Korea#2015-03-19#Hong Seung-sung#"),
            new Label("14#Blockberry Creative#10 Million#South Korea#2016-10-02#Jang Won-young#"),
            new Label("15#Swing Entertainment#50 Million#South Korea#2021-12-01#Kim Yong-bum#"),
            new Label("16#RBW#200 Million#South Korea#2021-03-15#Kim Do-hoon#"),
            new Label("17#Universal Music#75 Million#South Korea#2021-02-17#Shinsadong Tiger#"),
            new Label("18#High Up Entertainment#15 Million#South Korea#2020-11-12#Black Eyed Pilseung#"),
            new Label("19#Atlantic Records#500 Million#United Kingdom#2004-12-20#Ed Sheeran#"),
            new Label("20#Republic Records#150 Million#United States#2008-08-29#Ariana Grande#"),
            new Label("21#Def Jam Recordings#265 Million#Canada#2007-01-15#Scooter Braun#"),
            new Label("22#Republic Records#360 Million#United States#2004-10-24#Scott Borchetta#"),
            new Label("23#Darkroom/Interscope Records#53 Million#United States#2015-08-19#Finneas O'Connell#"),
            new Label("24#222 Records#120 Million#United States#1994-01-01#Adam Levine#"),
            new Label("25#XL Recordings#190 Million#United Kingdom#2006-01-10#Richard Russell#"),
            new Label("26#Parlophone Records#350 Million#United Kingdom#1996-07-15#Chris Martin#"),
            new Label("27#Island Records#60 Million#Canada#2013-06-26#Andrew Gertler#"),
            new Label("28#Interscope Records#75 Million#United States#2002-10-17#Selena Gomez#"),
            new Label("29#Island Records#33 Million#United States#2002-08-20#Simon Cowell#"),
            new Label("30#Warner Records#25 Million#United Kingdom#2015-08-22#Dua Lipa#"),
            new Label("31#Atlantic Records#175 Million#United States#2004-11-01#Bruno Mars#"),
            new Label("32#Atlantic Records#20 Million#United States#2016-04-01#Ava Max#"),
            new Label("33#Virgin EMI Records#12 Million#United Kingdom#2017-03-31#Ryan Walter#"),
            new Label("34#EDAM Entertainment#120 Million#South Korea#2007-09-24#Lee Jong-hoon#"),
            new Label("35#Capitol Records#45 Million#United Kingdom#2008-12-19#Sam Smith#"),
            new Label("36#Right Hand Music Group#50 Million#United States#2016-09-29#Khalid Robinson#"),
            new Label("37#RCA Records#85 Million#United Kingdom#2010-12-10#Simon Cowell#"),
            new Label("38#Epic Records#28 Million#United States#2012-12-18#Simon Cowell#"),
            new Label("39#Major Toms#10 Million#United Kingdom#2015-04-10#Rudimental#"),
            new Label("40#Lauv Music#15 Million#United States#2014-01-01#Ari Leff#"),
            new Label("41#Capitol Records#330 Million#United States#2001-02-08#Glenn Ballard#"),
            new Label("42#MNH Entertainment#12 Million#South Korea#2016-06-21#Kim Chungha#"),
            new Label("43#Capitol Records#100 Million#United States#2014-08-28#Halsey#"),
            new Label("44#Pledis Entertainment#50 Million#South Korea#2015-05-26#Han Sung-soo#"),
            new Label("45#Republic Records#90 Million#Canada#2010-03-21#The Weeknd#"),
            new Label("46#Atlantic Records#10 Million#United States#2013-10-01#Lizzo#"),
            new Label("47#Epic Records#10 Million#Sweden#2012-02-16#Zara Larsson#")
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
