-- Populate Colors
MERGE INTO Colors AS target
USING
(
	VALUES ( N'Red' ), ( N'Yellow' ), ( N'White' ), ( N'Blue' ), ( N'Green' )
)
AS source (Name)
ON target.Name = source.Name
WHEN NOT MATCHED THEN
	INSERT (NAME)
	VALUES (source.Name);