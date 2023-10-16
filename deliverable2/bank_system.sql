INSERT INTO users (user_name, user_type, password, gender, id_number, birthday, phone_number)
VALUES
    ('John Doe', 'Customer', 'password123', 'Male', 123456789, '1990-05-15', '123-456-7890'),
    ('Jane Smith', 'Customer', 'securepass', 'Female', 987654321, '1985-02-20', '987-654-3210'),
    ('Alice Johnson', 'Customer', 'mysecret', 'Female', 567890123, '1992-03-10', '567-890-1234'),
    ('Bob Johnson', 'Customer', 'mypassword', 'Male', 321654987, '1995-04-05', '321-654-9870'),
    ('Eve Johnson', 'Admin', 'pass1234', 'Female', 135792468, '1988-06-12', '135-792-4680'),
    ('Charlie Brown', 'Customer', 'secret123', 'Male', 864209753, '1982-01-08', '864-209-7531'),
    ('David White', 'Admin', 'passpass', 'Male', 987654322, '1983-07-19', '987-654-3220'),
    ('Emma Black', 'Customer', 'mypin123', 'Female', 123450987, '1998-08-23', '123-450-9876'),
    ('Grace Miller', 'Customer', 'security', 'Female', 456789012, '1994-09-30', '456-789-0123'),
    ('Frank Taylor', 'Admin', 'testpass', 'Male', 111122223, '1991-10-14', '111-122-2233');
	
	
	
INSERT INTO bank_account (user_id, card_number, card_password, balance, isactive, opened_date)
VALUES
    (1, 123456, 'password123', 1000.00, true, '2023-01-15'),
    (2, 987654, 'securepass', 500.50, true, '2023-02-20'),
    (3, 567890, 'mysecret', 250.25, false, '2023-03-10'),
    (4, 321654, 'mypassword', 3000.75, true, '2023-04-05'),
    (5, 135792, 'pass1234', 800.20, true, '2023-05-12'),
    (6, 864209, 'secret123', 1234.56, false, '2023-06-08'),
    (7, 987654, 'passpass', 750.75, true, '2023-07-19'),
    (8, 123450, 'mypin123', 200.00, true, '2023-08-23'),
    (9, 456789, 'security', 900.30, false, '2023-09-30'),
    (10, 111122, 'testpass', 1500.00, true, '2023-10-14');


	

INSERT INTO log (log_type, user_id, user_name, operation_detail, operation_date, ip_address)
VALUES
    ('Login', 1, 'John Doe', 'User login', '2023-01-15', '192.168.1.1'),
    ('Logout', 2, 'Jane Smith', 'User logout', '2023-02-20', '192.168.1.2'),
    ('Transaction', 3, 'Alice Johnson', 'Money transfer', '2023-03-10', '192.168.1.3'),
    ('Login', 4, 'Bob Johnson', 'User login', '2023-04-05', '192.168.1.4'),
    ('Logout', 5, 'Eve Johnson', 'User logout', '2023-05-12', '192.168.1.5'),
    ('Transaction', 6, 'Charlie Brown', 'Money transfer', '2023-06-08', '192.168.1.6'),
    ('Login', 7, 'David White', 'User login', '2023-07-19', '192.168.1.7'),
    ('Logout', 8, 'Emma Black', 'User logout', '2023-08-23', '192.168.1.8'),
    ('Transaction', 9, 'Grace Miller', 'Money transfer', '2023-09-30', '192.168.1.9'),
    ('Login', 10, 'Frank Taylor', 'User login', '2023-10-14', '192.168.1.10');










   
