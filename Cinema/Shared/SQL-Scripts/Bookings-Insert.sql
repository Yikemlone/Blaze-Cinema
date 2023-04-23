USE CinemaDB;

INSERT INTO Bookings(Status) VALUES
('Pending'),
('Approved'),
('Approved');


--INSERT INTO Bookings(Status, CustomerID) VALUES
--('Pending', 1),
--('Approved', 1),
--('Approved', 2);


INSERT INTO TicketTypeBookings(BookingID, TicketTypeID) VALUES 
(1, 1),
(1, 1), 
(1, 2),
(1, 2), 
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 2),
(2, 1),
(2, 1),
(2, 1),
(3, 2),
(3, 2),
(3, 2),
(3, 2),
(3, 2),
(4, 2),
(4, 2),
(4, 2),
(4, 2),
(4, 2),
(4, 2),
(4, 2),
(5, 2),
(5, 2),
(5, 2),
(6, 2),
(6, 2),
(6, 2),
(6, 2),
(6, 2),
(5, 2),
(5, 1);