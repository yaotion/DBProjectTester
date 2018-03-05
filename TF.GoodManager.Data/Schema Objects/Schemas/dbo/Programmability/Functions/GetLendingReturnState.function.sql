CREATE FUNCTION [dbo].[GetLendingReturnState](@LendingInfoGUID [varchar](50))
RETURNS [int] WITH EXECUTE AS CALLER
AS 
BEGIN 
declare @DetailCount int
declare @ReturnStateValue int
declare @ReturnValue int

select @DetailCount = count(*) from TAB_LendingDetail WHERE strLendingInfoGUID = @LendingInfoGUID
select @ReturnStateValue = sum(nReturnState) from TAB_LendingDetail WHERE strLendingInfoGUID = @LendingInfoGUID
if (@ReturnStateValue is null) or (@DetailCount = 0)
begin
	set @ReturnValue = 2
end
else
begin
	if @ReturnStateValue = 0 
	begin
		set @ReturnValue = 0
	end
	else
	begin
		if @DetailCount * 2 = @ReturnStateValue 
		begin
			set @ReturnValue = 2
		end	
		else
		begin
			set @ReturnValue= 1
		end
		
	end
end


return @ReturnValue
END


