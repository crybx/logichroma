-- Populate CardValues
DECLARE @CardValuesTemp TABLE
(
	faceValue INT,
	countInDeck INT
)

INSERT INTO @CardValuesTemp (faceValue, countInDeck)
VALUES 
	(1, 3),
	(2, 2),
	(3, 2),
	(4, 2),
	(5, 1)

MERGE INTO CardValues AS target
USING 
(
	SELECT	faceValue, countInDeck
	FROM	@CardValuesTemp
) 
AS source
ON source.faceValue = target.FaceValue

WHEN NOT MATCHED BY TARGET THEN

	INSERT ( FaceValue, CountInDeck )
	VALUES ( source.faceValue, source.countInDeck );