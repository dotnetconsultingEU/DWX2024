CREATE TABLE [dbo].[UserRoles] (
    [ObjectId]     INT IDENTITY (1, 1) NOT NULL,
    [UserObjectId] INT NOT NULL,
    [RoleObjectId] INT NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([ObjectId] ASC),
    CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleObjectId]) REFERENCES [dbo].[Roles] ([ObjectId]),
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserObjectId]) REFERENCES [dbo].[Users] ([ObjectId])
);


GO
ALTER TABLE [dbo].[UserRoles] NOCHECK CONSTRAINT [FK_UserRoles_Roles];


GO
ALTER TABLE [dbo].[UserRoles] NOCHECK CONSTRAINT [FK_UserRoles_Users];

