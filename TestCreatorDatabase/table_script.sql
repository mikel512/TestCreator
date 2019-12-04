
create table [dbo].[student]
(
	[studentID]		INT NOT NULL PRIMARY KEY IDENTITY(20000, 11),
	[f_name]		NVARCHAR(50) NOT NULL,
	[l_name]		NVARCHAR(50) NOT NULL
)

create table [dbo].[instructor]
(
	[instructorID]	INT NOT NULL PRIMARY KEY IDENTITY(10000, 111),
	[fname]			NVARCHAR(50) NOT NULL,
	[lname]			NVARCHAR(50) NOT NULL,
)
create table [dbo].[class]
(
	[classID]		INT NOT NULL PRIMARY KEY IDENTITY(1000, 101),
	[class_name]	NVARCHAR(50) NOT NULL,
	[class_subject] NVARCHAR(50) NOT NULL,
	[instructorID]	INT NOT NULL,

	CONSTRAINT fk_instructor FOREIGN KEY (instructorID)
	REFERENCES [dbo].[instructor](instructorID)
)
create table [dbo].[student_class]
(
	[studentID]		INT NOT NULL,
	[classID]		INT NOT NULL,

	CONSTRAINT pk_student_class PRIMARY KEY (studentID, classID),
	CONSTRAINT fk_student FOREIGN KEY(studentID)
		REFERENCES [dbo].[student](studentID),
	CONSTRAINT fk_class FOREIGN KEY(classID)
		REFERENCES [dbo].[class](classID)
)
create table [dbo].[test]
(
	[testID]		INT NOT NULL PRIMARY KEY IDENTITY(100, 11),
	[test_title]	NVARCHAR(100) NOT NULL,
	[classID]		INT NOT NULL,

	CONSTRAINT fk_testClass FOREIGN KEY (classID)
	REFERENCES [dbo].[class](classID)
)
create table [dbo].[question]
(
	[questionID]		INT NOT NULL PRIMARY KEY IDENTITY(10000, 5),
	[question_content]	NVARCHAR(MAX) NOT NULL,
	[is_long_answer]	BIT NOT NULL,
	[testID]			INT NOT NULL,

	CONSTRAINT fk_testQuestion FOREIGN KEY(testID)
	REFERENCES [dbo].[test](testID)
)
create table [dbo].[answer]
(
	[answerID]			INT NOT NULL PRIMARY KEY IDENTITY(10000, 1),
	[is_long_answer]	BIT NOT NULL,
	[answer_content]	NVARCHAR(MAX),
	[questionID]		INT NOT NULL,

	CONSTRAINT fk_question FOREIGN KEY(questionID)
	REFERENCES [dbo].[question](questionID)
)
create table [dbo].[test_score_answer]
(
	[scoreID]		INT NOT NULL,
	[answerID]		INT NOT NULL,

	CONSTRAINT pk_score_answer PRIMARY KEY(scoreID, answerID),
	CONSTRAINT fk_score FOREIGN KEY(scoreID)
		REFERENCES [dbo].[test_score](scoreID),
	CONSTRAINT fk_score_answer FOREIGN KEY(answerID)
		REFERENCES [dbo].[answer](answerID)
)

create table [dbo].[test_score]
(
	[scoreID]			INT NOT NULL PRIMARY KEY IDENTITY(100000, 111),
	[score_percentage]	DECIMAL,
	[number_correct]	INT,
	[studentID]			INT NOT NULL,
	[testID]			INT NOT NULL,

	CONSTRAINT fk_sudent_tScore FOREIGN KEY(studentID)
	REFERENCES [dbo].[student](studentID),
	CONSTRAINT fk_test_tScore FOREIGN KEY(testID)
	REFERENCES [dbo].[test](testID)
)
