CREATE DATABASE ProjectManagement

USE ProjectManagement

CREATE TABLE Employee(
Id INT NOT NULL PRIMARY KEY,
Name VARCHAR(100),
Designation VARCHAR(100),
Gender VARCHAR(100),
Salary DECIMAL,
Project_Id INT,
CONSTRAINT FK_Id FOREIGN KEY (Project_Id) REFERENCES Project(Id)
)

CREATE TABLE Project(
Id INT NOT NULL PRIMARY KEY,
ProjectName VARCHAR (100),
Description VARCHAR(MAX),
StartDate DATE,
Status VARCHAR(100) CHECK (Status IN('Started','Dev','Built','Test','Deployed'))
)

CREATE TABLE Task(
Task_Id INT NOT NULL PRIMARY KEY,
TaskName VARCHAR(100),
Project_Id INT,
Employee_Id INT,
Status VARCHAR(100) CHECK (Status IN ('Assigned','Started','Completed')),
CONSTRAINT FK_ProId FOREIGN KEY (Project_Id) REFERENCES Project(Id),
CONSTRAINT FK_EmpId FOREIGN KEY (Employee_Id) REFERENCES Employee(Id)
)

SELECT * FROM Project

SELECT * FROM Employee

SELECT * FROM Task

INSERT INTO Project VALUES (1, 'Dines on Wheels', 'Food bus management system', '2025-04-01', 'Started');
INSERT INTO Project VALUES (2, 'Health NFC', 'NFC-based health record system', '2025-03-15', 'Dev');
INSERT INTO Project VALUES (3, 'Oil Spill Cleaner', 'IoT-based cleaning robot', '2025-02-10', 'Built');
INSERT INTO Project VALUES (4, 'E-Vehicle Charger', 'Smart EV charger system', '2025-01-20', 'Test');
INSERT INTO Project VALUES (5, 'Project Manager', 'Project management console app', '2025-04-10', 'Deployed');

INSERT INTO Employee VALUES (1, 'Saranya', 'Developer', 'Female', 100000, 1);
INSERT INTO Employee VALUES (2, 'Rahul', 'Tester', 'Male', 85000, 2);
INSERT INTO Employee VALUES (3, 'Divya', 'Designer', 'Female', 90000, 3);
INSERT INTO Employee VALUES (4, 'Vikram', 'Manager', 'Male', 120000, 4);
INSERT INTO Employee VALUES (5, 'Priya', 'Support', 'Female', 75000, 5);

INSERT INTO Task VALUES (101, 'UI Design', 1, 3, 'Assigned');
INSERT INTO Task VALUES (102, 'Backend API', 1, 1, 'Started');
INSERT INTO Task VALUES (103, 'NFC Scan', 2, 2, 'Completed');
INSERT INTO Task VALUES (104, 'Oil Detection', 3, 5, 'Started');
INSERT INTO Task VALUES (105, 'Deploy Build', 5, 4, 'Assigned');



