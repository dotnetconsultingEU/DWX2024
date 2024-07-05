CREATE TABLE [dbo].[Users] (
    [ObjectId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [ResourceId] NVARCHAR (10)  NOT NULL,
    [FirstName]  NVARCHAR (200) NOT NULL,
    [LastName]   NVARCHAR (200) NOT NULL,
    [Email]      NVARCHAR (100) NULL,
    [Password]   NVARCHAR (40)  NULL,
    [salt]       VARCHAR (10)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED ([ObjectId] ASC),
    CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED ([Email] ASC)
);


GO

Create trigger [dbo].[Usersdelete] on [dbo].[Users] 
for delete 
as
/* Microsoft Visual Studio generated code. */
BEGIN
  declare
	@errorNumber int,
	@errorMsg varchar(255)

  /* Clause for ON DELETE to referenced table CASCADE */
  delete UserRoles
  from UserRoles, deleted
  where UserRoles.UserObjectId = deleted.ObjectId

  return
  errorHandler:
        raiserror (@errorNumber,-1, @errorMsg)
  rollback transaction
END
