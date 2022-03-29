CREATE TABLE UserStory(
Id int identity(10,5) primary key Not null,
Title nvarchar(25) Not Null,
[Description] nvarchar(200) Not Null,
StoryPoints int Not Null,
BusinessValue int Not Null,
[State] int Not Null
)