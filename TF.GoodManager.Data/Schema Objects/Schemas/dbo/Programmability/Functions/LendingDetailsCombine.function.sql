CREATE FUNCTION [dbo].[LendingDetailsCombine](@LendingGUID [varchar](50), @nCombineType [int])
RETURNS [varchar](200) WITH EXECUTE AS CALLER
AS 
BEGIN
DECLARE @values varchar(200)
    SET @values = ''

SELECT @values = 
	case @nCombineType
	when 0 then @values  + strAlias +  convert(varchar(20),strLendingExInfo) + space(2)

	else 
		case nReturnState 
		when 0 then
			 @values + strAlias + convert(varchar(20),strLendingExInfo) + space(2)
		else
			@values  + strAlias  + convert(varchar(20),strLendingExInfo ) + '√' + space(1)
		end
	
	end

 FROM View_LendingInfoDetail WHERE strLendingInfoGUID = @LendingGUID
RETURN @values
END


