-- Populate Cards
DECLARE @RolesTemp TABLE
(
	id NVARCHAR (128),
	name NVARCHAR (256)
)

INSERT INTO @RolesTemp (id, name)
VALUES 
	( N'canManageUsers', N'canManageUsers'),
	( N'canEditGameAssets', N'canEditGameAssets')

MERGE INTO AspNetRoles AS target
USING 
(
	SELECT	id, name
	FROM	@RolesTemp
) 
AS source
ON source.id = target.Id

WHEN NOT MATCHED BY TARGET THEN

	INSERT ( Id, Name )
	VALUES ( source.id, source.name );