CREATE TABLE [dbo].[GameCards]
(
	[GameId] INT NOT NULL,
    [Order] INT NOT NULL,
    [CardTypeId] INT NOT NULL,
    [CardStateId] INT NOT NULL,
    [ColorId] INT NOT NULL,
    PRIMARY KEY ([GameId], [Order]),
	CONSTRAINT [FK_GameCards_GameId] FOREIGN KEY (GameId) REFERENCES [Games]([Id]),
	CONSTRAINT [FK_GameCards_CardTypeId] FOREIGN KEY (CardTypeId) REFERENCES [CardTypes]([Id]),
	CONSTRAINT [FK_GameCards_CardStateId] FOREIGN KEY ([CardStateId]) REFERENCES [CardStates]([Id]),
	CONSTRAINT [FK_GameCards_ColorId] FOREIGN KEY (ColorId) REFERENCES [Colors]([Id])
)
