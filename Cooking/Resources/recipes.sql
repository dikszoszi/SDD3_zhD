--DROP TABLE [Ingredients];
--DROP TABLE [Recipes];

CREATE TABLE [dbo].[Recipes] (
    [Id]         INT        NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [RecipeName] NVARCHAR (50) NOT NULL,
    [Price]         INT        NOT NULL,
    [IsFavourite]   BIT        NOT NULL,
);
GO

INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Carbonara', 1400, 0);
INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Bolognai', 900, 0);
INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Grízes tészta', 400, 1);
INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Lasagne', 1600, 1);
INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Paprikás krumpli', 700, 0);
INSERT INTO Recipes ([RecipeName], [Price], [IsFavourite]) VALUES ('Lecsó', 850, 0);
GO

CREATE TABLE [dbo].[Ingredients] (
    [Id]         INT        NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [IngredientName] NVARCHAR (50) NOT NULL,
    [Amount]  INT        NOT NULL,
    [RecipeId]   INT        NOT NULL,
    CONSTRAINT RECEPTEK_FOREIGN_KEY FOREIGN KEY (RecipeId) REFERENCES Recipes (Id)
);
GO

INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Spagetti tészta', 1, 1);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Tojás', 4, 1);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Só', 1, 1);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bors', 1, 1);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bacon', 5, 1);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Spagetti tészta', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Paradicsom szósz', 3, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Hagyma', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Darálthús', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Oregánó', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Só', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bors', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Olaj', 1, 2);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Lapos tészta', 2, 3);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Gríz', 2, 3);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Olaj', 2, 3);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Nagy lapos tészta', 2, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Paradicsom szósz', 3, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Hagyma', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Darálthús', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Oregánó', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Só', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bors', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Olaj', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Besamel', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Sajt', 1, 4);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Krumpli', 10, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Hagyma', 1, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Kolbász', 2, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Fűszer paprika', 1, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Só', 1, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bors', 1, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Majoranna', 1, 5);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Paprika', 6, 6);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Paradicsom', 4, 6);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Hagyma', 2, 6);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Só', 1, 6);
INSERT INTO [Ingredients] ([IngredientName], [Amount], [RecipeId]) VALUES ('Bors', 1, 6);
GO

