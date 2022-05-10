CREATE TABLE [dbo].[Users] (
    [UserName] NVARCHAR (50) DEFAULT ('admin') NOT NULL,
    [Password] NVARCHAR (50) DEFAULT ((123)) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserName] ASC)
);