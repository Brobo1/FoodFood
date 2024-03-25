INSERT INTO Restaurants (Name, Address, Category, Description, OpeningTime, ClosingTime, IsOpen, Image)
VALUES ('The Spicy Spoon', '123 Flavor Street, Tasty Town', 'Mexican', 'A vibrant spot for spicy Mexican dishes.',
        '10:00', '22:00', 1, 'Image1'),
       ('Ocean Bites', '456 Sea Avenue, Fish City', 'Seafood', 'Fresh seafood served with a view.', '11:00', '23:00', 1,
        'Image2'),
       ('Burger Blitz', '789 Fast Lane, Burger Borough', 'Fast Food', 'Home of the juiciest burgers in town.', '09:00',
        '21:00', 1, 'Image3'),
       ('Pasta Paradise', '321 Noodle Road, Pasta Place', 'Italian', 'Authentic Italian pasta dishes.', '12:00',
        '00:00', 1, 'Image4'),
       ('Sushi Symphony', '654 Rice Way, Sushi City', 'Japanese', 'Experience the harmony of flavors in our sushi.',
        '13:00', '01:00', 1, 'Image5');

-- Meals for 'The Spicy Spoon' (Mexican)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Taco Fiesta', 'A trio of flavorful tacos with our secret sauce.', 'Mexican', 'MealImage1', 9.99, 1, 1,
        'Gluten'),
       ('Chicken Enchiladas', 'Cheesy chicken enchiladas with a spicy red sauce.', 'Mexican', 'MealImage2', 11.99, 1, 1,
        'Dairy, Gluten'),
       ('Chiles Rellenos', 'Poblano peppers stuffed with cheese and fried.', 'Mexican', 'MealImage3', 10.99, 1, 1,
        'Dairy'),
       ('Carnitas Tacos', 'Slow-cooked pork tacos with cilantro and onions.', 'Mexican', 'MealImage4', 12.99, 1, 1,
        'Gluten'),
       ('Churros', 'Sweet fried dough coated in sugar and cinnamon.', 'Mexican', 'MealImage5', 5.99, 1, 1,
        'Gluten, Dairy');

-- Meals for 'Ocean Bites' (Seafood)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Seafood Platter', 'A selection of the freshest seafood, grilled to perfection.', 'Seafood', 'MealImage6',
        19.99, 1, 2, 'Shellfish'),
       ('Grilled Salmon', 'Fresh salmon fillet grilled with lemon and herbs.', 'Seafood', 'MealImage7', 17.99, 1, 2,
        'Fish'),
       ('Shrimp Scampi', 'Shrimp sautéed in garlic butter and white wine.', 'Seafood', 'MealImage8', 15.99, 1, 2,
        'Shellfish'),
       ('Fish and Chips', 'Beer-battered cod served with crispy fries.', 'Seafood', 'MealImage9', 13.99, 1, 2,
        'Fish, Gluten'),
       ('Lobster Bisque', 'Creamy soup made with fresh lobster meat.', 'Seafood', 'MealImage10', 9.99, 1, 2,
        'Shellfish, Dairy');

-- Meals for 'Burger Blitz' (Fast Food)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Classic Cheeseburger', 'Juicy beef patty with melted cheese.', 'Fast Food', 'MealImage11', 8.99, 1, 3,
        'Gluten, Dairy'),
       ('Chicken Nuggets', 'Crispy fried chicken nuggets.', 'Fast Food', 'MealImage12', 5.99, 1, 3, 'Gluten'),
       ('Veggie Burger', 'A delicious and healthy alternative to our classic burger.', 'Fast Food', 'MealImage13', 7.99,
        1, 3, 'Gluten'),
       ('Fish and Chips', 'Crispy battered fish served with golden fries.', 'Fast Food', 'MealImage14', 9.99, 1, 3,
        'Fish, Gluten'),
       ('BBQ Bacon Burger', 'Our classic burger topped with crispy bacon and BBQ sauce.', 'Fast Food', 'MealImage15',
        10.99, 1, 3, 'Gluten, Dairy');


-- Meals for 'Pasta Paradise' (Italian)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Spaghetti Carbonara', 'Classic Italian pasta with pancetta and egg.', 'Italian', 'MealImage16', 12.99, 1, 4,
        'Gluten, Dairy'),
       ('Lasagna', 'Layered pasta with beef, tomato sauce, and cheese.', 'Italian', 'MealImage17', 14.99, 1, 4,
        'Gluten, Dairy'),
       ('Penne Arrabbiata', 'Penne pasta in a spicy tomato sauce.', 'Italian', 'MealImage18', 11.99, 1, 4, 'Gluten'),
       ('Fettuccine Alfredo', 'Creamy pasta with parmesan and butter.', 'Italian', 'MealImage19', 13.99, 1, 4,
        'Gluten, Dairy'),
       ('Tiramisu', 'Classic Italian dessert with coffee and mascarpone.', 'Italian', 'MealImage20', 6.99, 1, 4,
        'Gluten, Dairy');

-- Meals for 'Sushi Symphony' (Japanese)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Sushi Platter', 'An assortment of fresh sushi.', 'Japanese', 'MealImage21', 18.99, 1, 5, 'Fish'),
       ('Tempura Shrimp', 'Crispy fried shrimp with a side of soy dipping sauce.', 'Japanese', 'MealImage22', 12.99, 1,
        5, 'Shellfish, Gluten'),
       ('Chicken Teriyaki', 'Grilled chicken glazed with teriyaki sauce.', 'Japanese', 'MealImage23', 14.99, 1, 5,
        'Gluten'),
       ('Miso Soup', 'Traditional Japanese soup with tofu and seaweed.', 'Japanese', 'MealImage24', 5.99, 1, 5, 'Soy'),
       ('Green Tea Ice Cream', 'Refreshing green tea flavored ice cream.', 'Japanese', 'MealImage25', 4.99, 1, 5,
        'Dairy');

INSERT INTO "User" (UserName, Password, Salt)
VALUES ('JohnDoe', 'JDPassword123', 'Salt1'),
       ('JaneSmith', 'JSPassword456', 'Salt2'),
       ('AliceJohnson', 'AJPassword789', 'Salt3'),
       ('BobBrown', 'BBPassword321', 'Salt4'),
       ('CharlieGreen', 'CGPassword654', 'Salt5');

INSERT INTO "Order" (OrderDate, IsDelivered, TotalPrice, UserId)
VALUES ('2022-01-01', 1, 35.98, 1),
       ('2022-01-02', 0, 24.99, 2),
       ('2022-01-03', 1, 19.98, 3),
       ('2022-01-04', 0, 12.99, 4),
       ('2022-01-05', 1, 6.99, 5);

INSERT INTO MealOrder (MealId, OrderId, Quantity)
VALUES (1, 1, 2),
       (2, 2, 3),
       (3, 3, 1),
       (4, 4, 2),
       (5, 5, 1);

INSERT INTO Personalia (FirstName, LastName, Birthday, Address, UserId)
VALUES ('John', 'Doe', '1980-01-01', '123 Main Street, Anytown', 1),
       ('Jane', 'Smith', '1985-02-02', '456 Oak Avenue, Sometown', 2),
       ('Alice', 'Johnson', '1990-03-03', '789 Pine Road, Everytown', 3),
       ('Bob', 'Brown', '1995-04-04', '321 Elm Boulevard, Thistown', 4),
       ('Charlie', 'Green', '2000-05-05', '654 Cedar Lane, Thatown', 5);

INSERT INTO Payment (Type, CardNumber, ExpirationDate, CardHolderName, PersonaliaId)
VALUES ('Visa', '4111111111111111', '2025-01-01', 'John Doe', 1),
       ('MasterCard', '5555555555554444', '2026-02-02', 'Jane Smith', 2),
       ('American Express', '378282246310005', '2027-03-03', 'Alice Johnson', 3),
       ('Discover', '6011111111111117', '2028-04-04', 'Bob Brown', 4),
       ('Diners Club', '30569309025904', '2029-05-05', 'Charlie Green', 5);

INSERT INTO Rating (Review, UserId, Stars)
VALUES ('Great food and service!', 1, 5),
       ('Good, but could be better.', 2, 4),
       ('Average experience.', 3, 3),
       ('Not my cup of tea.', 4, 2),
       ('I would not recommend.', 5, 1);

INSERT INTO RestaurantRatings (RestaurantId, RatingId)
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (4, 4),
       (5, 5);

INSERT INTO Favorite (ResturantId, UserId, IsFavorite, RestaurantRatingId, RestaurantId)
VALUES (1, 1, 1, 1, 1),
       (2, 2, 0, 2, 2),
       (3, 3, 1, 3, 3),
       (4, 4, 0, 4, 4),
       (5, 5, 1, 5, 5);