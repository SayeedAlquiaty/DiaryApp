
CREATE VIEW [dbo].[classroomstudent_vw]
AS
SELECT 

CR.[classroom_id],CR.[classroom_grade], CR.[classroom_section], CRS.[classroomstudent_rollno],[student_firstname], ST.[student_surname]

FROM [dbo].[classroom_tb] CR
INNER JOIN [dbo].[classroomstudent_tb] CRS
ON CR.[classroom_id] = CRS.[classroom_id]
INNER JOIN [dbo].[student_tb] ST
ON CRS.[student_id] = ST.[student_id] 
;