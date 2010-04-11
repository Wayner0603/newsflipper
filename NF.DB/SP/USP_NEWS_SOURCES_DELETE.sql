 /*-- =============================================
-- Author      : dbo
-- Create date : Mar 28 2010  6:07PM
-- Description : Delete Procedure for NEWS_SOURCES
-- Exec [dbo].[USP_NEWS_SOURCES_DELETE] @SRC_ID  int
    
-- ============================================= */
CREATE PROCEDURE [dbo].[USP_NEWS_SOURCES_DELETE]
     @SRC_ID  int
    
AS
BEGIN

    DELETE FROM [dbo].[NEWS_SOURCES]
    WHERE [SRC_ID] = @SRC_ID

END


GO