CREATE TABLE [dbo].[GameCards]
(
	[GameId] INT NOT NULL,
    [Order] INT NOT NULL,
	[CardSuitId] INT NOT NULL,
    [CardValueId] INT NOT NULL,
    [CardState] NVARCHAR(10) NOT NULL,
    [GamePlayerId] INT NULL,
    PRIMARY KEY ([GameId], [Order]),
	CONSTRAINT [FK_GameCards_GameId] FOREIGN KEY (GameId) REFERENCES [Games]([Id]),
	CONSTRAINT [FK_GameCards_CardValueId] FOREIGN KEY (CardValueId) REFERENCES [CardValues]([Id]),
	CONSTRAINT [FK_GameCards_CardSuitId] FOREIGN KEY (CardSuitId) REFERENCES [CardSuits]([Id]),
	CONSTRAINT [FK_GameCards_GamePlayerId] FOREIGN KEY (GamePlayerId) REFERENCES [GamePlayers]([GamePlayerId])
)
