CREATE TABLE [dbo].[UserPlantCodes] (
    [ObjectId]     INT           IDENTITY (1, 1) NOT NULL,
    [UserObjectId] INT           NOT NULL,
    [PlantCode]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserPlantCodes] PRIMARY KEY CLUSTERED ([ObjectId] ASC),
    CONSTRAINT [FK_UserPlantCodes_Users] FOREIGN KEY ([UserObjectId]) REFERENCES [dbo].[Users] ([ObjectId]) ON DELETE CASCADE
);

