﻿ CREATE PROCEDURE [dbo].[USP_NEWSPAPER_IMAGES_RECORDEXISTS]
@NMG_IMAGENAME VARCHAR(100),
@NMG_DATE CHAR(8)
AS
SELECT NMG_ID FROM NEWSPAPER_IMAGES
WHERE NMG_IMAGENAME =@NMG_IMAGENAME
and NMG_DATE=@NMG_DATE

GO