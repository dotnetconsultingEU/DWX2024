CREATE TABLE [dbo].[Roles] (
    [ObjectId] INT           IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY NONCLUSTERED ([ObjectId] ASC)
);

