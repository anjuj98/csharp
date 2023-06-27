

CREATE PROCEDURE SPI_studentDetails(@studentName varchar(50),@course varchar(50),@department varchar(50))
AS
BEGIN
 INSERT INTO tbl_studentDetails(studentName,course,department) VALUES (@studentName,@course,@department);
END




CREATE PROCEDURE SPS_getStudentDetails(@studentID int)
AS
BEGIN
  SELECT   studentID,studentName,course,department FROM tbl_studentDetails
  WHERE studentID = @studentID;
END


EXEC SPS_getStudentDetails '3';



CREATE PROCEDURE SPU_studentDetails(@studentID int,@studentName varchar(50),@course varchar(50),@department varchar(50))
AS
BEGIN
 UPDATE  tbl_studentDetails SET studentName = @studentName ,   course = @course , department = @department
 WHERE studentID = @studentID;
END


ALTER PROCEDURE SPD_studentDetails(@studentID int,@outputMessage varchar(50) OUTPUT)
AS
BEGIN

declare @rowcount int = 0
  BEGIN TRY

     SET @rowcount = (select count(1) from tbl_studentDetails WHERE studentID = @studentID) 

	 if(@rowcount > 0)
	 BEGIN
        BEGIN TRAN
		    DELETE FROM tbl_studentDetails
            WHERE studentID = @studentID

			SET @outputMessage = 'Student details deleted Successfully..!'

		COMMIT TRAN
	END
	ELSE
	  BEGIN

	    SET @outputMessage = 'Student details not available with ID..!' + CONVERT(varchar , @studentID)

	  END
  END TRY

BEGIN CATCH
      ROLLBACK TRAN
      SET    @outputMessage = ERROR_MESSAGE()
END CATCH
END

