CREATE TABLE [dbo].[GameStatuses]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [GameStatusTypeId] INT NOT NULL,
    [DateTime] DATETIME NOT NULL,
    [GameId] INT NOT NULL
	CONSTRAINT [FK_GameStatuses_GameStatusTypeId] FOREIGN KEY ([GameStatusTypeId]) REFERENCES [GameStatusTypes]([Id]),
	CONSTRAINT [FK_GameStatuses_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id]) 
)
