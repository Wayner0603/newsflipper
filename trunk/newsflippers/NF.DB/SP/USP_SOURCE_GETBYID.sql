 
create procedure [dbo].[USP_SOURCE_GETBYID]
@SRC_ID INT as
SELECT * FROM SOURCES WHERE NPR_ID=@SRC_ID

GO


