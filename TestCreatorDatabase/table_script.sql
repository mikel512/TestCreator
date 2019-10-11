create table [dbo].[instructor]
(
	[instructorID] INT NOT NULL PRIMARY KEY IDENTITY(10000, 111),
	[fname] NVARCHAR(50) NOT NULL,
	[lname] NVARCHAR(50) NOT NULL,
)
create table [dbo].[class]
(
	[classID] INT NOT NULL PRIMARY KEY IDENTITY(1000, 101),
	[class_name] NVARCHAR(50) NOT NULL,
	[class_subject] NVARCHAR(50) NOT NULL
)
create table [dbo].[student]
(
	[studentID] INT NOT NULL PRIMARY KEY IDENTITY(20000, 11),
	[f_name] NVARCHAR(50) NOT NULL,
	[l_name] NVARCHAR(50) NOT NULL
)
create table [dbo].[test]
(
	[testID] INT NOT NULL PRIMARY KEY IDENTITY(100, 11),
	[test_title] NVARCHAR(100) NOT NULL,
	[num_questions] INT NOT NULL,
)
create table [dbo].[question]
(
	[questionID] INT NOT NULL PRIMARY KEY IDENTITY(10000, 5),
	[question_content] NVARCHAR(MAX) NOT NULL,
)
create table [dbo].[answer]
(
	[answerID] INT NOT NULL PRIMARY KEY IDENTITY(10000, 1),
	[answer_content] NVARCHAR(100) NOT NULL
)
create table [dbo].[test_score]
(
	[scoreID] INT NOT NULL PRIMARY KEY IDENTITY(100000, 111),
	[score_percentage] DECIMAL,
	[number_correct] INT
)
