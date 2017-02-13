-- Populate Cards
DECLARE @CardsTemp TABLE
(
	faceValue INT,
	countInDeck INT
)

INSERT INTO @CardsTemp (faceValue, countInDeck)
VALUES 
	(1, 5),
	(2, 5),
	(3, 2),
	(4, 2),
	(5, 1)

MERGE INTO Cards AS target
USING 
(
	SELECT	faceValue, countInDeck
	FROM	@CardsTemp
) 
AS source
ON source.faceValue = target.FaceValue

WHEN NOT MATCHED BY TARGET THEN

	INSERT ( FaceValue, CountInDeck )
	VALUES ( source.faceValue, source.countInDeck );