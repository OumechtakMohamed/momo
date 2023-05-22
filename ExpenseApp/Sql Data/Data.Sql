-- Vérifier si les utilisateurs existent avant l'insertion
IF NOT EXISTS (SELECT 1 FROM Users WHERE FirstName = 'Anthony' AND LastName = 'Stark')
BEGIN
    INSERT INTO Users (FirstName, LastName, Currency)
    VALUES ('Anthony', 'Stark', 'Dollar américain');
END

IF NOT EXISTS (SELECT 1 FROM Users WHERE FirstName = 'Natasha' AND LastName = 'Romanova')
BEGIN
    INSERT INTO Users (FirstName, LastName, Currency)
    VALUES ('Natasha', 'Romanova', 'Rouble russe');
END




-- Insertion des dépenses
INSERT INTO Expenses (UserId, ExpenseDate, Nature, Amount, Currency, Comment)
VALUES 
    ((SELECT UserId FROM Users WHERE FirstName = 'Anthony' AND LastName = 'Stark'), '2023-05-20', 0, 50.00, 'Dollar américain', 'Déjeuner'),
    ((SELECT UserId FROM Users WHERE FirstName = 'Natasha' AND LastName = 'Romanova'), '2023-05-21', 1, 100.00, 'Rouble russe', 'Hôtel'),
    ((SELECT UserId FROM Users WHERE FirstName = 'Anthony' AND LastName = 'Stark'), '2023-05-22', 2, 20.00, 'Dollar américain', 'Achat en ligne');
