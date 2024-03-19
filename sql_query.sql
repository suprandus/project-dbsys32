CREATE DATABASE dbsys32;

USE dbsys32;


-- tables
-- user_account table
CREATE TABLE user_account (
    [user_id] VARCHAR(5) PRIMARY KEY,
    role_id INT NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    [password] VARCHAR(256) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- user_category
CREATE TABLE user_category(
	role_id int PRIMARY KEY,
	[description] varchar(255),
);


-- services table 
CREATE TABLE services (
    service_id VARCHAR(10) PRIMARY KEY,
    service_name VARCHAR(255),
    price DECIMAL(10, 2)
);

-- services_transaction table
CREATE TABLE services_transaction (
	transaction_id INT PRIMARY KEY IDENTITY,
    service_id VARCHAR(10),
	username VARCHAR(50),
    [service_name] NVARCHAR(100),
    price DECIMAL(18, 2),
    date_added_at DATETIME DEFAULT CURRENT_TIME sSTAMP,
	CONSTRAINT FK_username FOREIGN KEY ([username]) REFERENCES user_account([username]),
	CONSTRAINT FK_service_id FOREIGN KEY (service_id) REFERENCES services(service_id)
);

