USE [University]

INSERT INTO Courses (discipline)
VALUES ('math'), ('gegraphy'), ('economics'), ('programming')

INSERT INTO Students (name, user_email)
VALUES ('Stephen', 'stephen@mail.com'), ('Anton', 'anton@mail.com'), ('Oleksii', 'oleksii@mail.com')

INSERT INTO Enrollments (course_id, student_id, type)
SELECT C.course_id, S.student_id, 'partial' FROM 
	(SELECT student_id FROM Students WHERE name = 'Stephen') S
		CROSS JOIN
	(SELECT course_id FROM Courses WHERE discipline IN ('math', 'geography', 'economics')) C

INSERT INTO Enrollments (course_id, student_id, type)
SELECT C.course_id, S.student_id, 'full' FROM 
	(SELECT student_id FROM Students WHERE name = 'Anton') S
		CROSS JOIN
	(SELECT course_id FROM Courses WHERE discipline IN ('math', 'programming', 'economics')) C


INSERT INTO Enrollments (course_id, student_id, type)
SELECT C.course_id, S.student_id, 'full' FROM 
	(SELECT student_id FROM Students WHERE name = 'Oleksii') S
		CROSS JOIN
	(SELECT course_id FROM Courses WHERE discipline IN ('math', 'programming')) C