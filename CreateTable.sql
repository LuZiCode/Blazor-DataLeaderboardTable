USE Leaderboard

CREATE TABLE [dbo].[Leaderboard]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Playername] VARCHAR(255) UNIQUE NOT NULL,
	[Highscore] DECIMAL(10,2) NOT NULL
)

INSERT INTO [Leaderboard] VALUES ('EpicGamer123', '293123')

INSERT INTO [Leaderboard] VALUES ('LucasGaming', '9232312')

INSERT INTO [Leaderboard] VALUES ('Ziegler', '99999999')

INSERT INTO [Leaderboard] VALUES ('UzzyGamez', '1')

INSERT INTO [Leaderboard] VALUES ('DannyBoi', '1023241')


