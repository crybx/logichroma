-- Populate GameStatusTypes

MERGE INTO dbo.GameStatusTypes AS target
USING 
(
	VALUES ( N'Started' ), ( N'Completed' ), ( N'Aborted' )
) 
AS source (Name)
ON target.Name = source.Name
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Name)
	VALUES (source.name);