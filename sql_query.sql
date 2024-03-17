USE dbsys32;


-- tables
CREATE TABLE user_account (
    [user_id] VARCHAR(5) PRIMARY KEY,
    role_id INT NOT NULL,
    username VARCHAR(50) NOT NULL,
    [password] VARCHAR(256) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE user_category(
	role_id int PRIMARY KEY,
	[description] varchar(50),
);

select * from user_account

-- service table
CREATE TABLE services (
    service_id VARCHAR(10) PRIMARY KEY,
    service_name VARCHAR(255),
    price DECIMAL(10, 2)
);


