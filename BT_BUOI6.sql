USE master
CREATE DATABASE BAITHUCHANH6
GO
USE BAITHUCHANH6
DROP DATABASE BAITHUCHANH6

CREATE TABLE Faculty (
    FacultyID INT PRIMARY KEY,
    FacultyName NVARCHAR(255)
);

CREATE TABLE Major (
    FacultyID INT,
    MajorID INT PRIMARY KEY,
    Major_name NVARCHAR(255),
);

CREATE TABLE Student (
    MSSV NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(255),
    AverageScore FLOAT,
    FacultyName NVARCHAR(255),
    Major_name NVARCHAR(255),
	Avatar NVARCHAR(255)
);
drop table Student



INSERT INTO Faculty (FacultyID, FacultyName)
VALUES (1, 'Cong nghe thong tin'), 
       (2, 'Kinh te'), 
       (3, 'Ky thuat dien tu');

-- Thêm dữ liệu vào bảng Major
INSERT INTO Major (MajorID, Major_name, FacultyID)
VALUES (1, 'Lap trinh', 1),
       (2, 'Quan tri kinh doanh', 2),
       (3, 'Dien tu vien thong', 3);

-- Thêm dữ liệu vào bảng Student
INSERT INTO Student (MSSV, FullName, AverageScore, FacultyName, Major_name)
VALUES ('SV001', 'Nguyen Van A', 8.5, 'Cong nghe thong tin', 'Lap trinh'),
       ('SV002', 'Tran Thi B', 7.8, 'Kinh te', 'Quan tri kinh doanh'),
       ('SV003', 'Le Van C', 9.0, 'Ky thuat dien tu', 'Dien tu vien thong');

	   delete from Student
