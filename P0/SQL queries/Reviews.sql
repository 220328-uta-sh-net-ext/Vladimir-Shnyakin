CREATE TABLE [dbo].[Reviews] (
    [StarsTaste]     INT            NOT NULL,
    [StarsMood]      INT            NOT NULL,
    [StarsService]   INT            NOT NULL,
    [StarsPrice]     INT            NOT NULL,
    [Note]           NVARCHAR (140) NULL,
    [UserName]       NVARCHAR (50)  DEFAULT ('admin') NOT NULL,
    [RestaurantName] NVARCHAR (50)  DEFAULT ((1)) NOT NULL,
    CONSTRAINT [RV_Id] PRIMARY KEY CLUSTERED ([UserName] ASC, [RestaurantName] ASC),
    CONSTRAINT [FK_RR] FOREIGN KEY ([RestaurantName]) REFERENCES [dbo].[Restaurants] ([RestaurantName])
);