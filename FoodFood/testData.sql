DELETE
FROM Favorite;
DELETE
FROM MealOrder;
DELETE
FROM Payment;
DELETE
FROM Rating;
DELETE
FROM RestaurantRatings;
DELETE
FROM "Order";
DELETE
FROM Personalia;
DELETE
FROM Meal;
DELETE
FROM Restaurants;
DELETE
FROM "User";

DBCC CHECKIDENT ('Meal', RESEED, 0);
DBCC CHECKIDENT ('Restaurants', RESEED, 0);
DBCC CHECKIDENT ('User', RESEED, 0);
DBCC CHECKIDENT ('Order', RESEED, 0);
DBCC CHECKIDENT ('MealOrder', RESEED, 0);
DBCC CHECKIDENT ('Personalia', RESEED, 0);
DBCC CHECKIDENT ('Payment', RESEED, 0);
DBCC CHECKIDENT ('Rating', RESEED, 0);
DBCC CHECKIDENT ('RestaurantRatings', RESEED, 0);
DBCC CHECKIDENT ('Favorite', RESEED, 0);

INSERT INTO Restaurants (Name, Address, Category, Description, OpeningTime, ClosingTime, IsOpen, Image)
VALUES ('The Spicy Spoon', '123 Flavor Street, Tasty Town', 'Mexican', 'A vibrant spot for spicy Mexican dishes.',
        '10:00', '22:00', 1, 'https://www.lowcarb-nocarb.com/wp-content/uploads/2023/08/Taco-Seasoning-MSN.jpg'),
       ('Ocean Bites', '456 Sea Avenue, Fish City', 'Seafood', 'Fresh seafood served with a view.', '11:00', '23:00', 1,
        'https://www.mashed.com/img/gallery/national-seafood-chains-ranked-worst-to-best/l-intro-1610394684.jpg'),
       ('Burger Blitz', '789 Fast Lane, Burger Borough', 'Fast Food', 'Home of the juiciest burgers in town.', '09:00',
        '21:00', 1,
        'https://www.mrporter.com/cms/ycm/resource/blob/479990/c758e5463fcae5eaa16c00421f10d5ec/5617c0bf-1567-4fd0-bd40-8623a96d413b-data.jpg'),
       ('Pasta Paradise', '321 Noodle Road, Pasta Place', 'Italian', 'Authentic Italian pasta dishes.', '12:00',
        '00:00', 1,
        'https://www.mashed.com/img/gallery/italian-chain-restaurants-ranked-from-worst-to-best/l-intro-1618597744.jpg'),
       ('Sushi Symphony', '654 Rice Way, Sushi City', 'Japanese', 'Experience the harmony of flavors in our sushi.',
        '13:00', '01:00', 1,
        'https://images.lifestyleasia.com/wp-content/uploads/sites/6/2022/12/26162113/jakub-dziubak-unsplash-sushi-hi-resized-1600x900.jpeg');

-- Meals for 'The Spicy Spoon' (Mexican)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Taco Fiesta', 'A trio of flavorful tacos with our secret sauce.', 'Mexican',
        'https://www.mashed.com/img/gallery/the-cheesy-taco-bell-item-that-just-made-a-comeback/l-intro-1661786474.jpg',
        9.99, 1, 1,
        'Gluten'),
       ('Chicken Enchiladas', 'Cheesy chicken enchiladas with a spicy red sauce.', 'Mexican',
        'https://cdn.cleaneatingmag.com/wp-content/uploads/2019/10/chicken-enchiladas-with-salsa-verde_88-web-2.jpg?crop=16:9&width=1600',
        11.99, 1, 1,
        'Dairy, Gluten'),
       ('Chiles Rellenos', 'Poblano peppers stuffed with cheese and fried.', 'Mexican',
        'https://static01.nyt.com/images/2021/03/25/magazine/25mag-eat/25mag-eat-videoSixteenByNineJumbo1600.jpg',
        10.99, 1, 1,
        'Dairy'),
       ('Carnitas Tacos', 'Slow-cooked pork tacos with cilantro and onions.', 'Mexican',
        'https://img.texasmonthly.com/2021/10/Houston-Diegos-Famous-Carnitas-tacos-feat.jpg?auto=compress&crop=faces&fit=crop&fm=jpg&h=900&ixlib=php-3.3.1&q=45&w=1600',
        12.99, 1, 1,
        'Gluten'),
       ('Churros', 'Sweet fried dough coated in sugar and cinnamon.', 'Mexican',
        'https://images.getrecipekit.com/20220715113121-churros-200011.jpg?aspect_ratio=16:9&quality=90', 5.99, 1, 1,
        'Gluten, Dairy');

-- Meals for 'Ocean Bites' (Seafood)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Seafood Platter', 'A selection of the freshest seafood, grilled to perfection.', 'Seafood',
        'https://theneffkitchen.com.au/wp-content/uploads/2016/12/NEFF-Seafood-platter-featured.jpg',
        19.99, 1, 2, 'Shellfish'),
       ('Grilled Salmon', 'Fresh salmon fillet grilled with lemon and herbs.', 'Seafood',
        'https://images.ctfassets.net/lufu0clouua1/2wdIKZworSyEa44qE6uyC2/ff77e85a114bfc7b09bd2a1e83bf3237/herbed-cedar-grilled-salmon.jpg',
        17.99, 1, 2,
        'Fish'),
       ('Shrimp Scampi', 'Shrimp sautéed in garlic butter and white wine.', 'Seafood',
        'https://www.mashed.com/img/gallery/this-aldi-5-ingredient-shrimp-scampi-is-out-of-this-world/l-intro-1613503513.jpg',
        15.99, 1, 2,
        'Shellfish'),
       ('Fish and Chips', 'Beer-battered cod served with crispy fries.', 'Seafood',
        'https://mshanken.imgix.net/wso/bolt/2020-12/perfectmatch1_121520_1600.jpg', 13.99, 1, 2,
        'Fish, Gluten'),
       ('Lobster Bisque', 'Creamy soup made with fresh lobster meat.', 'Seafood',
        'https://images.getrecipekit.com/v1612454455_Lobster-Bisque-IMAGE-1jpg_wqiyak.jpg?aspect_ratio=16:9&quality=90&',
        9.99, 1, 2,
        'Shellfish, Dairy');

-- Meals for 'Burger Blitz' (Fast Food)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Classic Cheeseburger', 'Juicy beef patty with melted cheese.', 'Fast Food',
        'https://media.cnn.com/api/v1/images/stellar/prod/220428140436-04-classic-american-hamburgers.jpg?c=original',
        8.99, 1, 3,
        'Gluten, Dairy'),
       ('Chicken Nuggets', 'Crispy fried chicken nuggets.', 'Fast Food',
        'https://images.getrecipekit.com/20211001145142-c049a9c5-4172-4111-bdb6-667408a76be1.jpeg?aspect_ratio=16:9&quality=90&',
        5.99, 1, 3, 'Gluten'),
       ('Veggie Burger', 'A delicious and healthy alternative to our classic burger.', 'Fast Food',
        'https://simmerandsauce.com/wp-content/uploads/2017/05/2F92EE3E-1DC8-436C-84F9-044D5DC8F958_1_201_a-1600x900.jpeg',
        7.99,
        1, 3, 'Gluten'),
       ('Fish and Chips', 'Crispy battered fish served with golden fries.', 'Fast Food',
        'https://mshanken.imgix.net/wso/bolt/2020-12/perfectmatch1_121520_1600.jpg', 9.99, 1, 3,
        'Fish, Gluten'),
       ('BBQ Bacon Burger', 'Our classic burger topped with crispy bacon and BBQ sauce.', 'Fast Food',
        'https://www.mashed.com/img/gallery/chilis-is-bringing-4-new-burgers-to-its-big-mouth-menu/l-intro-1635537831.jpg',
        10.99, 1, 3, 'Gluten, Dairy');


-- Meals for 'Pasta Paradise' (Italian)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Spaghetti Carbonara', 'Classic Italian pasta with pancetta and egg.', 'Italian',
        'https://www.tastingtable.com/img/gallery/simple-spaghetti-carbonara-recipe/l-intro-1670253292.jpg', 12.99, 1,
        4,
        'Gluten, Dairy'),
       ('Lasagna', 'Layered pasta with beef, tomato sauce, and cheese.', 'Italian',
        'https://static01.nyt.com/images/2023/08/31/multimedia/RS-Lasagna-hkjl-copy/RS-Lasagna-hkjl-videoSixteenByNineJumbo1600.jpg',
        14.99, 1, 4,
        'Gluten, Dairy'),
       ('Penne Arrabbiata', 'Penne pasta in a spicy tomato sauce.', 'Italian',
        'https://food-images.files.bbci.co.uk/food/recipes/chicken_arrabiata_88408_16x9.jpg', 11.99, 1, 4, 'Gluten'),
       ('Fettuccine Alfredo', 'Creamy pasta with parmesan and butter.', 'Italian',
        'https://images.getrecipekit.com/20220225134835-recipes-2x1_lobster-fettuccini.jpeg?aspect_ratio=16:9&quality=90&',
        13.99, 1, 4,
        'Gluten, Dairy'),
       ('Tiramisu', 'Classic Italian dessert with coffee and mascarpone.', 'Italian',
        'https://onlineculinaryschool.net/wp-content/uploads/2018/10/online_culinary_school_classic_tiramisu-1.jpg',
        6.99, 1, 4,
        'Gluten, Dairy');

-- Meals for 'Sushi Symphony' (Japanese)
INSERT INTO Meal (Name, Description, Category, MealImage, Price, IsActive, RestaurantId, Allergens)
VALUES ('Sushi Platter', 'An assortment of fresh sushi.', 'Japanese',
        'https://www.rollsushi.no/wp-content/uploads/2023/12/8A.jpg', 18.99, 1, 5, 'Fish'),
       ('Tempura Shrimp', 'Crispy fried shrimp with a side of soy dipping sauce.', 'Japanese',
        'https://www.tastingtable.com/img/gallery/the-simple-way-to-straighten-shrimp-when-making-tempura/l-intro-1675459180.jpg',
        12.99, 1,
        5, 'Shellfish, Gluten'),
       ('Chicken Teriyaki', 'Grilled chicken glazed with teriyaki sauce.', 'Japanese',
        'https://www.mashed.com/img/gallery/classic-teriyaki-chicken-recipe/l-intro-1651603430.jpg', 14.99, 1, 5,
        'Gluten'),
       ('Miso Soup', 'Traditional Japanese soup with tofu and seaweed.', 'Japanese',
        'https://images.getrecipekit.com/20221103192444-dsc05705resizeslow_.jpg?aspect_ratio=16:9&quality=90&', 5.99, 1,
        5, 'Soy'),
       ('Green Tea Ice Cream', 'Refreshing green tea flavored ice cream.', 'Japanese',
        'https://wowitsveggie.com/wp-content/uploads/2020/11/vegan-matcha-ice-cream-close-dark-1600x900.jpg', 4.99, 1,
        5,
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