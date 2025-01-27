INSERT INTO Departments([DepartmentName],[DepartmentNo])
VALUES ('Computer','1002')

INSERT INTO Departments([DepartmentName],[DepartmentNo])
VALUES ('Math','1003')

INSERT INTO [dbo].[Teachers]([FirstName],[LastName],[Birthday],[Phone],[HomePhone],[Email],[Username],[PassWord],[IsActive],[FK_DepartmentId],[Roles])
VALUES ('ADMIN','Administrator','1987-06-03','123456789','123456789','abc@yahoo.com','abc','1',1,1,1)

INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Teachers')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Students')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Subjects')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('SubjectClass')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Department')

INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('TestComposer')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Questions')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('AssignTest')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('CustomQuestion')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('MultiTest')

INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('StudentTestResults')

INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Profiles')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('UserPermistion')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('DataBackup')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('Themes')
INSERT INTO [dbo].[Operations]([OperationName]) VALUES ('EditSchoolInfo')

Declare @teacherId int
select   @teacherId  =TeacherId from Teachers where Username ='abc'

INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Teachers',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Students',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Subjects',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'SubjectClass',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Department',1)

INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'TestComposer',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Questions',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'AssignTest',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'CustomQuestion',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'MultiTest',1)

INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'StudentTestResults',1)

INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Profiles',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'UserPermistion',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'DataBackup',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'Themes',1)
INSERT INTO [dbo].[TeacherOperations]([TeacherId],[OperationName],[Enable])VALUES(@teacherId,'EditSchoolInfo',1)


