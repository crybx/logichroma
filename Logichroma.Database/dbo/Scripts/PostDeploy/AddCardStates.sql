-- Populate CardStates
MERGE INTO CardStates AS target
USING
(
	VALUES ('Deck'), ('Hand'), ('Played'), ('Discarded'), ('Misfired')
)
AS source (Name)
ON target.Name = source.Name
WHEN NOT MATCHED THEN
	INSERT (NAME)
	VALUES (source.Name);