﻿ 
CREATE PROCEDURE [dbo].[USP_NEWSPAPER_IMAGES_CREATE]
@NMG_NPR_ID int,
@NMG_SEC_ID int,
@NMG_ADDEDDATE datetime,
@NMG_DATE char(8),
@NMG_URL nvarchar(255),
@NMG_IMAGENAME varchar(100),
@NMG_TITLE nvarchar(1000)
AS
INSERT INTO [NEWSPAPER_IMAGES]
([NMG_NPR_ID]
,[NMG_SEC_ID]
,[NMG_ADDEDDATE]
,[NMG_DATE]
,[NMG_URL],
[NMG_IMAGENAME], NMG_TITLE)
VALUES
(
@NMG_NPR_ID,
@NMG_SEC_ID,
@NMG_ADDEDDATE,
@NMG_DATE,
@NMG_URL,

@NMG_IMAGENAME,@NMG_TITLE
)

GO

