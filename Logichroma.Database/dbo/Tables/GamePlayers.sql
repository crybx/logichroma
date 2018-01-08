CREATE TABLE [dbo].[GamePlayers]
(
	[GameId] INT NOT NULL,
	[PlayerId] NVARCHAR(128) NOT NULL,
	[PlayerNumber] INT NULL,
	[Nickname] NVARCHAR(50) NULL, 
    PRIMARY KEY ([GameId], [PlayerId]),
	CONSTRAINT [FK_GamePlayers_GameId] FOREIGN KEY (GameId) REFERENCES [Games]([Id]),
	CONSTRAINT [FK_GamePlayers_PlayerId] FOREIGN KEY (PlayerId) REFERENCES [AspNetUsers]([Id])
)
