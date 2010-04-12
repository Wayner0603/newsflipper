 
/*-- =============================================
-- Author      : dbo
-- Create date : Mar 28 2010  6:07PM
-- Description : Insert Procedure for NEWS_SOURCES
-- Exec [dbo].[USP_NEWS_SOURCES_INSERT] [SRC_ID],[SRC_NAME],[SRC_URL],[SRC_RSS_URL],[SRC_ACTIVE]
-- ============================================= */
CREATE PROCEDURE [dbo].[USP_NEWS_SOURCES_INSERT]
     @SRC_ID  int
    ,@SRC_NAME  nvarchar(200)
    ,@SRC_URL  nvarchar(600)
    ,@SRC_RSS_URL  nvarchar(2000)
    ,@SRC_ACTIVE  bit
    
AS
BEGIN

    INSERT INTO [dbo].[NEWS_SOURCES]
    ( 
         [SRC_ID]
        ,[SRC_NAME]
        ,[SRC_URL]
        ,[SRC_RSS_URL]
        ,[SRC_ACTIVE]
        
    )
    VALUES
    (
         @SRC_ID
        ,@SRC_NAME
        ,@SRC_URL
        ,@SRC_RSS_URL
        ,@SRC_ACTIVE
        
    )
END



GO