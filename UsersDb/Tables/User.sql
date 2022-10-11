CREATE TABLE [dbo].[User]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PR_dbo_User] PRIMARY KEY,
    [Email] NVARCHAR(128) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(128) NOT NULL,
    [FirstName] NVARCHAR(128) NOT NULL,
    [LastName] NVARCHAR(128) NOT NULL,
    [Status] BIT NOT NULL
);