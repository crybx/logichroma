CREATE TABLE [dbo].[Decks]
(
	[GameId] INT NOT NULL,
    [Order] INT NOT NULL,
    [CardId] INT NOT NULL,
    [CardStateId] INT NOT NULL,
    [ColorId] INT NOT NULL,
    PRIMARY KEY ([GameId], [Order]),
	CONSTRAINT [FK_Decks_GameId] FOREIGN KEY (GameId) REFERENCES [Games]([Id]),
	CONSTRAINT [FK_Decks_CardId] FOREIGN KEY (CardId) REFERENCES [Cards]([Id]),
	CONSTRAINT [FK_Decks_CardStateId] FOREIGN KEY ([CardStateId]) REFERENCES [CardStates]([Id]),
	CONSTRAINT [FK_Decks_ColorId] FOREIGN KEY (ColorId) REFERENCES [Colors]([Id])
)
