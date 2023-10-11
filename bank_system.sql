CREATE TABLE bank_account (
    account_number SERIAL PRIMARY KEY,
    account_holder_name VARCHAR(255) NOT NULL,
    account_type VARCHAR(50) NOT NULL,
    balance DECIMAL(10, 2) DEFAULT 0.00,
    opened_date DATE NOT NULL,
    branch_location VARCHAR(255),
    is_active BOOLEAN DEFAULT true,
    UNIQUE (account_number)
);

CREATE TABLE transaction (
    transaction_id SERIAL PRIMARY KEY,
    account_number INT REFERENCES bank_account(account_number),
    transaction_date TIMESTAMP NOT NULL,
    transaction_type VARCHAR(50) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    balance_after DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (account_number) REFERENCES bank_account(account_number)
);
CREATE TABLE bank_cards (
    card_id SERIAL PRIMARY KEY,  -- Auto-incrementing unique identifier for the card
    card_number VARCHAR(16) NOT NULL, -- The 16-digit card number
    card_holder_name VARCHAR(100) NOT NULL, -- Name of the cardholder
    expiration_date DATE NOT NULL, -- The card's expiration date
    cvv_code VARCHAR(3) NOT NULL, -- Card's CVV code (security code)
    issuing_bank VARCHAR(100), -- The bank that issued the card
    account_holder_id INT NOT NULL, -- A reference to the account holder (User ID, for example)
    date_issued DATE, -- Date when the card was issued
    date_activated DATE, -- Date when the card was activated (optional)
    is_active BOOLEAN -- A flag to indicate if the card is currently active
);
