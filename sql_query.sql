CREATE DATABASE dbsys32;

USE dbsys32;

-- tables
CREATE TABLE user_account (
    [user_id] VARCHAR(5) PRIMARY KEY,
	role_id int NOT NULL,
    username VARCHAR(50) NOT NULL,
    [password] VARCHAR(64) NOT NULL

);

CREATE TABLE user_category(
	role_id int PRIMARY KEY,
	[description] varchar(50),
);

select * from user_account
