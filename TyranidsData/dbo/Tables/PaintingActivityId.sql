CREATE TABLE [dbo].[PaintingActivityId]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PaintId] INT NOT NULL, 
    [TechniqueId] INT NOT NULL, 
    [ModelSectionActivityId] INT NOT NULL

)
