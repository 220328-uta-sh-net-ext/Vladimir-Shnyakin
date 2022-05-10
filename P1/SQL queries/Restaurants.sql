CREATE TABLE [dbo].[Restaurants] (
    [RestaurantName] NVARCHAR (50) DEFAULT ('Unknown') NOT NULL,
    [Cuisine]        NVARCHAR (50) DEFAULT ('Unknown') NOT NULL,
    [OverallRating]  FLOAT (53)    DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED ([RestaurantName] ASC)
);