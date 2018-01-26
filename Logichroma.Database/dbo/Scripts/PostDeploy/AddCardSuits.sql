-- Populate CardSuits
DECLARE @CardSuitsTemp TABLE
(
	name NVARCHAR(50),
	backgroundColor NVARCHAR(15),
	textColor NVARCHAR(15)
)

INSERT INTO @CardSuitsTemp (name, backgroundColor, textColor)
VALUES 
		( N'Red', N'#dc3545', N'#f1c7c7' ), 
		( N'Yellow', N'#ffc107', N'#565105' ), 
		( N'White', N'#fbf4f2', N'#231c1cc9' ), 
		( N'Blue', N'#007bff', N'white' ), 
		( N'Green', N'#28a745', N'#b4dcb8' )

MERGE INTO CardSuits AS target
USING 
(
	SELECT	name, backgroundColor, textColor
	FROM	@CardSuitsTemp
)
AS source
ON source.name = target.Name

WHEN NOT MATCHED BY TARGET THEN

	INSERT ( Name, BackgroundColor, TextColor )
	VALUES ( source.name, source.backgroundColor, source.textColor );