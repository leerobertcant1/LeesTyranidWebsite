CREATE TABLE [dbo].[ModelSectionActivity]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateAdded] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ModelId] INT NOT NULL, 
    [PaintingActivityId] INT NOT NULL, 
    [ToolId] INT NOT NULL

)
