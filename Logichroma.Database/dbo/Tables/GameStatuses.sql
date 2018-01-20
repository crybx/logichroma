CREATE TABLE [dbo].[GameStatuses]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [Status] NVARCHAR(10) NOT NULL,
    [StatusChangeDateTime] DATETIME NOT NULL,
    [GameId] INT NOT NULL
	CONSTRAINT [FK_GameStatuses_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games]([Id]) 
)
