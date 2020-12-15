CREATE TABLE "User"(
Id uniqueidentifier PRIMARY KEY,
Username varchar(250) NOT NULL,
Nickname varchar(250) NOT NULL,
"Password" varchar(250) NOT NULL,
Email varchar(250) NOT NULL,
Sex varchar(50),
Age smallint NOT NULL,
Avatar varbinary(max) NOT NULL,
About text
);

CREATE TABLE "Message"(
Id uniqueidentifier PRIMARY KEY,
"User_Id" uniqueidentifier REFERENCES "User"(Id) NOT NULL,
"Subject" text NOT NULL,
Content text NOT NULL,
DateSent datetime NOT NULL
);

CREATE TABLE peopleWork(
Id uniqueidentifier PRIMARY KEY,
"User_Id" uniqueidentifier REFERENCES "User"(Id) NOT NULL,
"Name" varchar(250) NOT NULL,
"Description" text NOT NULL,
DateSent datetime NOT NULL,
"Type" varchar(10) NOT NULL,
"Likes" int,
Image varbinary(max) NOT NULL,
);

CREATE TABLE "Like"(
Id uniqueidentifier PRIMARY KEY,
"User_Id" uniqueidentifier REFERENCES "User"(Id) NOT NULL,
"Work_Id" uniqueidentifier REFERENCES peopleWork(Id) ON DELETE CASCADE NOT NULL,
IsLiked  smallint NOT NULL,
DateSent datetime NOT NULL,
NumberOfChange int NOT NULL
);

CREATE TABLE Comment(
Id uniqueidentifier PRIMARY KEY,
"User_Id" uniqueidentifier REFERENCES "User"(Id) NOT NULL,
"Work_Id" uniqueidentifier REFERENCES peopleWork(Id) ON DELETE CASCADE NOT NULL,
Content text NOT NULL,
DateSent datetime NOT NULL,
ForUser varchar(250) NOT NULL
);
