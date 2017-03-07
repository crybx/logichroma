-- Populate Cards
DECLARE @CardTypesTemp TABLE
(
	faceValue INT,
	countInDeck INT
)

INSERT INTO @CardTypesTemp (faceValue, countInDeck)
VALUES 
	(1, 5),
	(2, 5),
	(3, 2),
	(4, 2),
	(5, 1)

MERGE INTO CardTypes AS target
USING 
(
	SELECT	faceValue, countInDeck
	FROM	@CardTypesTemp
) 
AS source
ON source.faceValue = target.FaceValue

WHEN NOT MATCHED BY TARGET THEN

	INSERT ( FaceValue, CountInDeck )
	VALUES ( source.faceValue, source.countInDeck );