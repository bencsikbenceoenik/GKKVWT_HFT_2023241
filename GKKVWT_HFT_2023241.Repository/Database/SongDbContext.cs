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
            //modelBuilder.Entity<Artist>();

            modelBuilder.Entity<Song>(song => song
            .HasOne(song => song.Artist)
            .WithMany(artist => artist.Songs)
            .HasForeignKey(song => song.ArtistId));

            modelBuilder.Entity<Song>(song => song
            .HasOne(song => song.Label)
            .WithMany(label => label.Songs)
            .HasForeignKey(song => song.LabelId));

            modelBuilder.Entity<Artist>().HasData(
            new Artist("1#BTS#1993-12-04#2013#Group#Male#South Korean#"),
            new Artist("2#BLACKPINK#1996-01-03#2016#Group#Female#South Korean#"),
            new Artist("3#EXO#1992-09-21#2012#Group#Male#South Korean#"),
            new Artist("4#TWICE#1999-02-01#2015#Group#Female#South Korean#"),
            new Artist("5#RED VELVET#1991-03-29#2014#Group#Female#South Korean#"),
            new Artist("6#ITZY#2000-08-20#2019#Group#Female#South Korean#"),
            new Artist("7#NCT 127#1995-07-01#2016#Group#Male#South Korean#"),
            new Artist("8#STRAY KIDS#2000-09-14#2018#Group#Male#South Korean#"),
            new Artist("9#EXID#1991-08-12#2012#Group#Female#South Korean#"),
            new Artist("10#MONSTA X#1993-01-26#2015#Group#Male#South Korean#"),
            new Artist("11#MAMAMOO#1991-06-19#2014#Group#Female#South Korean#"),
            new Artist("12#(G)I-DLE#1998-08-14#2018#Group#Female#South Korean#")
            //new Artist("13#ENHYPEN#2002-12-01#2020#Group#Male#South Korean#"),
            //new Artist("14#ATEEZ#1998-10-24#2018#Group#Male#South Korean#"),
            //new Artist("15#GFriend#1997-09-23#2015#Group#Female#South Korean#"),
            //new Artist("16#Tomorrow X Together#2001-12-05#2019#Group#Male#South Korean#"),
            //new Artist("17#IZ*ONE#1998-04-29#2018#Group#Female#South Korean#"),
            //new Artist("18#Super Junior#1983-11-06#2005#Group#Male#South Korean#"),
            //new Artist("19#Dreamcatcher#1997-05-09#2014#Group#Female#South Korean#"),
            //new Artist("20#CLC#1997-03-19#2015#Group#Female#South Korean#"),
            //new Artist("21#LOONA#1996-11-21#2016#Group#Female#South Korean#"),
            //new Artist("22#IVE#2001-06-27#2021#Group#Female#South Korean#"),
            //new Artist("23#PURPLE KISS#2001-12-09#2021#Group#Female#South Korean#"),
            //new Artist("24#TRI.BE#2005-01-07#2021#Group#Female#South Korean#"),
            //new Artist("25#STAYC#2002-01-08#2020#Group#Female#South Korean#"),
            //new Artist("26#IU#1993-05-16#2008#Solo#Female#South Korean#"),
            //new Artist("27#CHUNG HA#1996-02-09#2016#Solo#Female#South Korean#")
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
                new Song("18#No More Dream#Album#2013-06-12#223#Korean#1#2#"),
                new Song("19#Boombayah#Single#2016-08-08#240#Korean#2#1#"),
                new Song("20#Whistle#Single#2016-08-08#213#Korean#2#1#"),
                new Song("21#Playing With Fire#Single#2016-11-01#189#Korean#2#1#"),
                new Song("22#Stay#Single#2016-11-01#210#Korean#2#1#"),
                new Song("23#As If Its Your Last#Single#2017-06-22#213#Korean#2#1#"),
                new Song("24#Ddu-Du Ddu-Du#Single#2018-06-15#209#Korean#2#1#"),
                new Song("25#Forever Young#Single#2018-06-15#203#Korean#2#1#"),
                new Song("26#Kill This Love#EP#2019-04-05#190#Korean#2#1#"),
                new Song("27#Don't Know What To Do#EP#2019-04-05#196#Korean#2#1#"),
                new Song("28#How You Like That#Single#2020-06-26#193#Korean#2#1#"),
                new Song("29#Really#Single#2018-06-15#197#Korean#2#1#"),
                new Song("30#See U Later#EP#2018-06-15#198#Korean#2#1#"),
                new Song("31#Kiss And Make Up#Collaboration#2018-10-19#191#English#2#1#"),
                new Song("32#Kick It#EP#2020-04-04#209#Korean#2#1#"),
                new Song("33#Hope Not#EP#2019-04-05#187#Korean#2#1#"),
                new Song("34#Sour Candy#Collaboration#2020-05-28#159#English#2#1#"),
                new Song("35#Ice Cream#Single#2020-08-28#181#English#2#1#"),
                new Song("36#Pretty Savage#Album#2020-10-02#189#Korean#2#1#"),
                new Song("37#Bet You Wanna#Album#2020-10-02#180#English#2#1#"),
                new Song("38#Lovesick Girls#Album#2020-10-02#221#Korean#2#1#"),
                new Song("39#Crazy Over You#Album#2020-10-02#193#English#2#1#"),
                new Song("40#Love To Hate Me#Album#2020-10-02#191#English#2#1#"),
                new Song("41#You Never Know#Album#2020-10-02#208#Korean#2#1#"),
                new Song("42#Ready For Love#Single#2022-07-29#186#Korean#2#1#"),
                new Song("43#Pink Venom#Album#2022-08-19#193#Korean#2#1#"),
                new Song("44#Shut Down#Album#2022-09-16#180#Korean#2#1#"),
                new Song("45#Typa Girl#Album#2022-09-21#179#English#2#1#"),
                new Song("46#Yeah Yeah Yeah#Album#2022-09-21#179#Korean#2#1#"),
                new Song("47#Hard To Love#Album#2022-09-21#163#English#2#1#"),
                new Song("48#The Happiest Girl#Album#2022-09-21#223#English#2#1#"),
                new Song("49#Tally#Album#2022-09-21#185#English#2#1#"),
                new Song("50#The Girls#Single#2023-08-25#163#Korean#2#1#"),
                new Song("51#Growl#Single#2013-08-05#211#Korean#3#3#"),
                new Song("52#Call Me Baby#Single#2015-03-27#207#Korean#3#3#"),
                new Song("53#Love Shot#Single#2018-12-13#206#Korean#3#3#"),
                new Song("54#Ko Ko Bop#Single#2017-07-18#204#Korean#3#3#"),
                new Song("55#Tempo#Single#2018-11-02#220#Korean#3#3#"),
                new Song("56#Monster#Single#2016-06-09#204#Korean#3#3#"),
                new Song("57#Overdose#EP#2014-05-07#245#Korean#3#3#"),
                new Song("58#Lotto#Single#2016-08-18#204#Korean#3#3#"),
                new Song("59#Electric Kiss#Single#2018-01-31#203#Japanese#3#3#"),
                new Song("60#Obsession#Album#2019-11-27#207#Korean#3#3#"),
                new Song("61#The Eve#Album#2017-07-18#177#Korean#3#3#"),
                new Song("62#Miracles in December#EP#2013-12-09#248#Korean#3#3#"),
                new Song("63#For Life#Single#2016-12-19#245#Korean#3#3#"),
                new Song("64#Sing For You#Single#2015-12-10#229#Korean#3#3#"),
                new Song("65#Power#Single#2017-09-05#221#Korean#3#3#"),
                new Song("66#What is Love#Single#2016-01-30#240#Korean#3#3#"),
                new Song("67#TT#EP#2016-10-24#235#Korean#4#4#"),
                new Song("68#Cheer Up#EP#2016-04-25#204#Korean#4#4#"),
                new Song("69#Feel Special#EP#2019-09-23#196#Korean#4#4#"),
                new Song("70#Likey#EP#2017-10-30#209#Korean#4#4#"),
                new Song("71#What is Love?#EP#2018-04-09#207#Korean#4#4#"),
                new Song("72#Dance The Night Away#EP#2018-07-09#197#Korean#4#4#"),
                new Song("73#Fancy#EP#2019-04-22#201#Korean#4#4#"),
                new Song("74#More & More#EP#2020-06-01#204#Korean#4#4#"),
                new Song("75#I Can't Stop Me#EP#2020-10-26#205#Korean#4#4#"),
                new Song("76#Alcohol-Free#EP#2021-06-09#193#Korean#4#4#"),
                new Song("77#Red Flavor#EP#2017-07-09#207#Korean#5#3#"),
                new Song("78#Bad Boy#EP#2018-01-29#229#Korean#5#3#"),
                new Song("79#Psycho#EP#2019-12-23#186#Korean#5#3#"),
                new Song("80#Peek-A-Boo#EP#2017-11-17#205#Korean#5#3#"),
                new Song("81#Zimzalabim#EP#2019-06-19#197#Korean#5#3#"),
                new Song("82#Russian Roulette#EP#2016-09-07#189#Korean#5#3#"),
                new Song("83#Rookie#EP#2017-02-01#202#Korean#5#3#"),
                new Song("84#Power Up#EP#2018-08-06#193#Korean#5#3#"),
                new Song("85#Umpah Umpah#EP#2019-08-20#196#Korean#5#3#"),
                new Song("86#Queendom#EP#2021-08-16#197#Korean#5#3#"),
                new Song("87#DALLA DALLA#Single#2019-02-11#196#Korean#6#4#"),
                new Song("88#ICY#EP#2019-07-29#191#Korean#6#4#"),
                new Song("89#WANNABE#EP#2020-03-09#200#Korean#6#4#"),
                new Song("90#Not Shy#EP#2020-08-17#193#Korean#6#4#"),
                new Song("91#Mafia In The Morning#Single#2021-04-30#204#Korean#6#4#"),
                new Song("92#Cherry Bomb#EP#2017-06-14#204#Korean#7#3#"),
                new Song("93#Regular#EP#2018-10-12#207#Korean#7#3#"),
                new Song("94#Superhuman#EP#2019-05-24#214#Korean#7#3#"),
                new Song("95#Kick Back#EP#2021-03-10#203#Korean#7#3#"),
                new Song("96#Sticker#Album#2021-09-17#198#Korean#7#3#"),
                new Song("97#God's Menu#EP#2020-06-17#198#Korean#8#4#"),
                new Song("98#Back Door#EP#2020-09-14#212#Korean#8#4#"),
                new Song("99#Mirror#Album#2020-06-17#198#Korean#8#4#"),
                new Song("100#Thunderous#Album#2021-08-23#220#Korean#8#4#"),
                new Song("101#Maniac#Single#2021-06-26#196#Korean#8#4#"),
                new Song("102#Up & Down#Single#2014-08-27#197#Korean#9#5#"),
                new Song("103#Ah Yeah#EP#2015-04-13#200#Korean#9#5#"),
                new Song("104#DDD#EP#2017-11-07#203#Korean#9#5#"),
                new Song("105#L.I.E#EP#2016-06-01#205#Korean#9#5#"),
                new Song("106#Lady#Single#2018-04-02#199#Korean#9#5#"),
                new Song("107#Shoot Out#Album#2018-10-22#201#Korean#10#6#"),
                new Song("108#Alligator#EP#2019-02-18#190#Korean#10#6#"),
                new Song("109#Fantasia#Album#2020-05-26#198#Korean#10#6#"),
                new Song("110#Jealousy#Album#2018-03-26#217#Korean#10#6#"),
                new Song("111#GAMBLER#EP#2021-05-31#187#Korean#10#6#"),
                new Song("112#Mr. Ambiguous#Single#2014-06-19#222#Korean#11#7#"),
                new Song("113#Piano Man#Single#2014-11-21#223#Korean#11#7#"),
                new Song("114#You're the Best#EP#2016-02-26#208#Korean#11#7#"),
                new Song("115#Starry Night#EP#2018-03-07#220#Korean#11#7#"),
                new Song("116#HIP#EP#2019-11-14#207#Korean#11#7#"),
                new Song("117#Latata#EP#2018-05-02#204#Korean#12#8#"),
                new Song("118#Hann (Alone)#EP#2018-08-14#204#Korean#12#8#"),
                new Song("119#Senorita#EP#2019-02-26#183#Korean#12#8#"),
                new Song("120#Uh-Oh#EP#2019-06-26#193#Korean#12#8#"),
                new Song("121#Lion#Single#2019-11-04#191#Korean#12#8#")
                ) ;

            modelBuilder.Entity<Label>().HasData(
            new Label("1#YG ENTERTAINMENT#3.5 Billion#South Korea#1996-08-08#Yang Hyun-suk#"),
            new Label("2#BIG HIT ENTERTAINMENT#1 Billion#South Korea#2005-02-01#Bang Si-hyuk#"),
            new Label("3#SM ENTERTAINMENT#1.5 Billion#South Korea#1995-02-14#Lee Soo-man#"),
            new Label("4#JYP ENTERTAINMENT#2 Billion#South Korea#1997-01-16#Park Jin-young#"),
            new Label("5#BANANA CULTURE#500 Million#South Korea#2012-08-13#Shinsadong Tiger#"),
            new Label("6#STARSHIP ENTERTAINMENT#1 Billion#South Korea#2014-05-14#Kim Shi-dae#"),
            new Label("7#RAINBOW BRIDGE WORLD#200 Million#South Korea#2014-06-19#Kim Do-hoon#"),
            new Label("8#CUBE ENTERTAINMENT#120 Million#South Korea#2018-05-02#Hong Seung-sung#")
            //new Label("9#Belift Lab#150 Million#South Korea#2020-11-30#Bang Si-hyuk#"),
            //new Label("10#KQ Entertainment#50 Million#South Korea#2018-10-24#Kim Gyu-wook#"),
            //new Label("11#Source Music#20 Million#South Korea#2015-01-15#So Sung-jin#"),
            //new Label("12#Happy Face Entertainment#10 Million#South Korea#2014-09-18#Lee Jong-min#"),
            //new Label("13#Blockberry Creative#10 Million#South Korea#2016-10-02#Jang Won-young#"),
            //new Label("14#Swing Entertainment#50 Million#South Korea#2021-12-01#Kim Yong-bum#"),
            //new Label("15#Universal Music#75 Million#South Korea#2021-02-17#Shinsadong Tiger#"),
            //new Label("16#High Up Entertainment#15 Million#South Korea#2020-11-12#Black Eyed Pilseung#"),
            //new Label("17#EDAM Entertainment#120 Million#South Korea#2007-09-24#Lee Jong-hoon#"),
            //new Label("18#MNH Entertainment#12 Million#South Korea#2016-06-21#Kim Chungha#")
            );
        }
    }
}
