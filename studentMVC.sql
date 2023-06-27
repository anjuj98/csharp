
CREATE PROCEDURE SPS_studentDetails
AS
BEGIN
 SELECT studentID,studentName,course,department FROM tbl_studentDetails WITH(nolock)

END

EXEC SPS_studentDetails