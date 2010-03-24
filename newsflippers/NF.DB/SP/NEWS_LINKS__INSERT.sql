 CREATE PROCEDURE NEWSL_LINKS__INSERT
(
		@NEWS_SOURCE int,
          @NEWS_TITLE nvarchar(max),
          @NEWS_DESC nvarchar(max),
          @NEWS_LINK nvarchar(1000),
          @NEWS_AUTHOR nvarchar(255),
          @NEWS_CATEGORY nvarchar(255),
          @NEWS_PUBDATE datetime,
          @NEWS_EXTRACT_DATE smalldatetime,
          @NEWS_DATEREF varchar(10),
          @NEWS_IMAGE_NAME varchar(200),
          @NEWS_IMAGE_GENERATED bit
)
AS
INSERT INTO [NEWS_LINKS]
           ([NEWS_SOURCE]
           ,[NEWS_TITLE]
           ,[NEWS_DESC]
           ,[NEWS_LINK]
           ,[NEWS_AUTHOR]
           ,[NEWS_CATEGORY]
           ,[NEWS_PUBDATE]
           ,[NEWS_EXTRACT_DATE]
           ,[NEWS_DATEREF]
           ,[NEWS_IMAGE_NAME]
           ,[NEWS_IMAGE_GENERATED])
     VALUES
           (
			@NEWS_SOURCE ,
          @NEWS_TITLE ,
          @NEWS_DESC,
          @NEWS_LINK ,
          @NEWS_AUTHOR ,
          @NEWS_CATEGORY ,
          @NEWS_PUBDATE ,
          @NEWS_EXTRACT_DATE ,
          @NEWS_DATEREF ,
          @NEWS_IMAGE_NAME ,
          @NEWS_IMAGE_GENERATED 
           )
GO


