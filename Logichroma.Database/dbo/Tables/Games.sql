CREATE TABLE [dbo].[Games]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL,
    [DifficultyLvl] INT NOT NULL,
	[CreateDateTime] DATETIME NOT NULL, 
    [NextCard] INT NOT NULL DEFAULT 0,
    [CurrentPlayerNumber] INT NOT NULL DEFAULT 0, 
    [HintTokens] INT NOT NULL DEFAULT 0, 
    [MisfireTokens] INT NOT NULL DEFAULT 0
)
