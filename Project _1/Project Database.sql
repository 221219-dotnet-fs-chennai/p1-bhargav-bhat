-------------DATABASE NAME-----------------------------------------------------------------------------------
create DATABASE TrainerDatabaseProject;

-------------------------------------------TABLE CREATIONS-----------------------------------------------------------------

-----------------------------TRAINER TABLE--------------------------------------------------------------------------------
CREATE TABLE [Trainer] (
  [Trainer_ID] int IDENTITY(1,1) PRIMARY KEY,
  [firstName] varchar(30),
  [lastName] varchar(30),
  [Gender] varchar(9),
  [Email] varchar(30) Unique not null,
  [Password] varchar(25) not null,
  [Phone] bigint not null,
  [City] varchar(20),
  [State] varchar(25),
  [Country] varchar(25),
  [AboutMe] varchar(max)
);

-----------------------------SKILLS TABLE--------------------------------------------------------------------------------
CREATE TABLE [Skills] (
  [Trainer_ID] int,
  [Skills] varchar(30),
  FOREIGN KEY ([Trainer_ID]) REFERENCES [Trainer]([Trainer_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

-----------------------------EDUCATION DATA TABLE------------------------------------------------------------------------
CREATE TABLE [Educations] (
  [Trainer_ID] int,
  [College_University] varchar(50),
  [Degree] varchar(30),
  [StartDate] varchar(20),
  [EndDate] varchar(20),
  [Description] varchar(max),
  FOREIGN KEY ([Trainer_ID])  REFERENCES [Trainer]([Trainer_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

-----------------------------WORK EXPERIENCE DATA TABLE-------------------------------------------------------------------
CREATE TABLE [WorkExperience] (
  [Trainer_ID] int,
  [Company_Name] varchar(50),
  [Role] varchar(30),
  [StartDate] varchar(20),
  [EndDate] varchar(20),
  [Description] varchar(max),
  FOREIGN KEY ([Trainer_ID]) REFERENCES [Trainer]([Trainer_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

-----------------------------ADDITIONAL DETAILS DATA TABLE-------------------------------------------------------------------
CREATE TABLE [AdditionalDetails] (
  [Trainer_ID] int,
  [Title] varchar(50),
  [Achievements] varchar(max),
  [Publications] varchar(max),
  [Volunteering_Experiences] varchar(max),
  FOREIGN KEY ([Trainer_ID]) REFERENCES [Trainer]([Trainer_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

-------------------------------------------------------------------------------------------------------------------------------

------------------------------------------INSERTING DUMMY VALUES---------------------------------------------------------------

-----------------------Inserting Values for Trainer-----------------------------------------------------------------------------
insert into Trainer(firstName,lastName,Gender,Email,Password,Phone,City,State,Country,AboutMe) 
VALUES('Sri','Devi','Female','sridevi@gmail.com','Sai123@',9480314998,'Chennai','TamilNadu','India','singer');

-----------------------Inserting Values for Skills-----------------------------------------------------------------------------
insert into Skills(Trainer_ID,SkillName) VALUES
                                                (54,'SQL'),
                                                    (54,'C#');
                                                
-----------------------Inserting Values for Educations Data---------------------------------------------------------------------
insert into Educations(Trainer_ID,College_University,Degree,StartDate,EndDate,Description) 
VALUES(30,'VVIET Mysore','B.E','08/2018','08/2022','Secured 84%');

-----------------------Inserting Values for WorkExperirnce Data-----------------------------------------------------------------
insert into WorkExperience(Trainer_ID,Company_Name,Role,StartDate,EndDate,Description)
VALUES(52,'TCS','Associate','12/2022','03/2023','Completed 4 Projects');

-----------------------Inserting Values for Additional Details -----------------------------------------------------------------
insert into AdditionalDetails(Trainer_ID,Title,Achievements,Publications,Volunteering_Experiences)
VALUES(1,'Gold Medalist','Secured 3rd Rank in University exam','Published government approved project research','Volunteered in Make a Difference NGO');

---------------------------------------------------------------------------------------------------------------------------------

-----------------------------SELECT ALL--------------------------------------------------------------------------------------
select * from Trainer;
select * from Skills;
select * from Educations;
select * from WorkExperience;
select * from AdditionalDetails;
------------------------------------------------------------------------------------------------------------------------------
