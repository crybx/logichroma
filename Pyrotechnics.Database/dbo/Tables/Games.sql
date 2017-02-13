CREATE TABLE [dbo].[Games]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(200) NOT NULL,
    [DifficultyLvl] INT NOT NULL,
    [NextCard] INT NULL,
    [StartDateTime] DATETIME NOT NULL
)
