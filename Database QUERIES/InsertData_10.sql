-- Insert data into Cities table
INSERT INTO Cities (CityName, CityImage)
VALUES 
('Timisoara', NULL),
('Arad', NULL),
('Bucharest', NULL),
('Cluj', NULL),
('Brasov', NULL),
('Deva', NULL),
('Hunedoara', NULL),
('Craiova', NULL),
('Pitesti', NULL),
('Piatra Neamt', NULL);

-- Insert data into PetShops table
INSERT INTO PetShops (CityID, PetShopName, PetShopImage)
VALUES 
(1, 'Pet Haven NY', NULL),
(2, 'LA Paws', NULL),
(3, 'Windy City Pets', NULL),
(4, 'Houston Critter Care', NULL),
(5, 'Phoenix Pet Shop', NULL),
(6, 'Philly Fur Babies', NULL),
(7, 'Alamo Animal Boutique', NULL),
(8, 'San Diego Pets', NULL),
(9, 'Dallas Pet Market', NULL),
(10, 'SJ Animal Kingdom', NULL);

-- Insert data into Animals table with detailed descriptions
INSERT INTO Animals (CityID, PetShopID, AnimalName, Type, Available, Price, ContactNumber, Description, Age, Breed, Gender, AnimalImage)
VALUES 
(1, 1, 'Buddy', 'Dog', 1, 500.00, '123-456-7890', 'Buddy is a friendly and energetic golden retriever who loves to play fetch and enjoys long walks in the park. He is well-trained, gets along with children, and is looking for a loving home where he can be part of a family.', 3, 'Golden Retriever', 'Male', NULL),
(2, 2, 'Whiskers', 'Cat', 1, 200.00, '234-567-8901', 'Whiskers is an adventurous and playful tabby cat with a charming personality. She enjoys climbing, chasing toys, and curling up in warm spots. She is affectionate and would be perfect for a household that can give her plenty of attention.', 2, 'Tabby', 'Female', NULL),
(3, 3, 'Chirpy', 'Bird', 1, 50.00, '345-678-9012', 'Chirpy is a cheerful and vibrant parakeet known for its beautiful singing. This bird loves interacting with people and has a lively spirit that will brighten up any room. Perfect for bird lovers looking for a feathered companion.', 1, 'Parakeet', 'Male', NULL),
(4, 4, 'Nibbles', 'Hamster', 1, 30.00, '456-789-0123', 'Nibbles is a small, adorable Syrian hamster who enjoys burrowing and exploring her habitat. She is easy to care for, making her a great pet for both children and adults. Nibbles is curious and loves to nibble on treats.', 1, 'Syrian', 'Female', NULL),
(5, 5, 'Spike', 'Dog', 0, 750.00, '567-890-1234', 'Spike is a high-energy Siberian Husky with stunning blue eyes and a playful demeanor. He loves running, playing in the snow, and being outdoors. Ideal for an active family or individual who can give him the exercise and attention he needs.', 2, 'Siberian Husky', 'Male', NULL),
(6, 6, 'Fluffy', 'Rabbit', 1, 100.00, '678-901-2345', 'Fluffy is a beautiful Angora rabbit with long, silky fur that requires regular grooming. She is gentle, loves to be petted, and enjoys hopping around and playing with toys. A perfect addition for anyone who loves small, soft pets.', 1, 'Angora', 'Female', NULL),
(7, 7, 'Shadow', 'Cat', 0, 300.00, '789-012-3456', 'Shadow is a sleek and mysterious Bombay cat with a calm demeanor. He is independent but enjoys cuddling when he feels comfortable. Shadow is perfect for a quieter household and gets along well with other pets.', 4, 'Bombay', 'Male', NULL),
(8, 8, 'Tweety', 'Bird', 0, 60.00, '890-123-4567', 'Tweety is a bright and cheerful canary known for her melodious singing and lively nature. She enjoys flying around her cage and loves a good perch. Tweety is a great pet for those who appreciate the soothing sound of birdsong.', 1, 'Canary', 'Female', NULL),
(9, 9, 'Rex', 'Dog', 1, 450.00, '901-234-5678', 'Rex is a loyal and protective German Shepherd who makes an excellent guard dog. He is intelligent, trainable, and fiercely devoted to his family. Rex enjoys playing games of fetch, running, and learning new commands.', 3, 'German Shepherd', 'Male', NULL),
(10, 10, 'Snowball', 'Cat', 1, 250.00, '012-345-6789', 'Snowball is a regal Persian cat with a luxurious white coat. She is calm, loves attention, and is perfect for someone looking for a low-maintenance companion. Snowball enjoys lounging and being pampered.', 2, 'Persian', 'Female', NULL);