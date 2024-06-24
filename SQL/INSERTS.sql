--(1)--
INSERT INTO TypeSolution VALUES
('type1'),
('type2'),
('type3'),
('type4'),
('type5')

--(2)--
INSERT INTO Role VALUES
('Admin'),
('Non-Admin')


--(3)--
INSERT INTO Users VALUES
(1, 'Andrew', 'Alison', 'Artoweys', 'senior', 'log1', 'pass1'),
(2, 'Bill', 'Benedict', 'Bronson', 'junior', 'log2', 'pass2'),
(1, 'Claire', 'Chris', 'Cammello','senior', 'log3', 'pass3'),
(1, 'Derril', 'Dickson', 'D.', 'middle', 'log4', 'pass4'),
(2, 'Ethan', 'Elliwan','Eenters', 'junior', 'log5', 'pass5')

--(4)--
INSERT INTO Status VALUES
('status1'),
('status2'),
('status3'),
('status4'),
('status5')

--(5)--
INSERT INTO Material VALUES
('material1'),
('material2'),
('material3'),
('material4'),
('material5')

--(6)--
INSERT INTO BuildingType VALUES
('buildingtype1'),
('buildingtype2'),
('buildingtype3'),
('buildingtype4'),
('buildingtype5')

--(7)--
INSERT INTO Building VALUES
(1, 1, 11, 100.20, '11:11:111111:11', 'address1'),
(2, 2, 12, 200.30, '22:22:222222:22', 'address2'),
(3, 3, 13, 300.40, '33:33:333333:33', 'address3'),
(4, 4, 14, 400.50, '44:44:444444:44', 'address4'),
(5, 5, 15, 500.60, '55:55:555555:55', 'address5')


--(9)--
INSERT INTO Solution VALUES
(1, 'its solution1'),
(2, 'its solution2'),
(3, 'its solution3'),
(4, 'its solution4'),
(5, 'its solution5')

--(10)--
INSERT INTO Chief VALUES
(1),
(2),
(3),
(4),
(5)

--(11)--
INSERT INTO Tasks VALUES
(1, 1, 1, 1, '01.01.2001' , '01.01.2011', 'overhaul in hospital'),
(2, 2, 2, 2, '02.02.2002' , '02.02.2012', 'overhaul in school'),
(3, 3, 3, 3, '03.03.2003' , '03.03.2013', 'demolition of living house'),
(4, 4, 4, 4, '04.04.2004' , '04.04.2014', 'overhaul in college'),
(5, 5, 5, 5, '05.05.2005' , '05.05.2015', 'demolition in business center')
