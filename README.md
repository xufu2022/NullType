ALTER PROC [dbo].[GetReportList]
    @pageIndex INT = 1,
    @pageSize INT = 4,
    @freqType INT = 0,
    @spName NVARCHAR(100) = '',
    @sortCol INT = 1,
    @sortDir NVARCHAR(100) = 'asc',
    @TotalCount INT OUTPUT
AS
BEGIN
    DECLARE @Now DATETIME = GETUTCDATE();
    IF (@pageIndex <= 0)
        SET @pageIndex = 1;

    IF (@pageSize <= 0)
        SET @pageSize = 2147483647;

    DECLARE @SkipRows INT = (@pageIndex - 1) * @pageSize;

    SELECT @TotalCount = COUNT(*)
    FROM ReportDailyEmail
    LEFT JOIN (
        SELECT MAX(Id) AS MonitorId, ReportDailyEmailId
        FROM ReportDailyMonitor
        GROUP BY ReportDailyEmailId
    ) MonitorData ON ReportDailyEmail.Id = MonitorData.ReportDailyEmailId
    LEFT JOIN ReportDailyMonitor ON MonitorData.MonitorId = ReportDailyMonitor.Id
    WHERE (@spName = '' OR (@spName <> '' AND ReportDailyEmail.StoredProcedureName LIKE '%' + @spName + '%'))
    AND (@freqType = 0 OR ReportDailyEmail.FreqType = @freqType);

   
    SELECT 
        ReportDailyEmail.Id, 
        ReportDailyEmail.StoredProcedureName,
        ReportDailyEmail.Enabled,
        ReportDailyMonitor.Status,
        ReportDailyEmail.FreqType, 
        ReportDailyEmail.LastProcessedDateTime, 
        ReportDailyEmail.FreqSubdayType, 
        ReportDailyEmail.FreqSubdayInterval, 
        ReportNextRun.NextRunTime AS NextRunDateTime,
        FreqInterval,
        ActiveStartTime,
        ActiveEndTime,
        ActiveStartDate,
        ActiveEndDate
    FROM ReportDailyEmail
    LEFT JOIN (
        SELECT MAX(Id) AS MonitorId, ReportDailyEmailId
        FROM ReportDailyMonitor
        GROUP BY ReportDailyEmailId
    ) MonitorData ON ReportDailyEmail.Id = MonitorData.ReportDailyEmailId
    LEFT JOIN ReportDailyMonitor ON MonitorData.MonitorId = ReportDailyMonitor.Id
    LEFT JOIN ReportNextRun ON ReportNextRun.Id = ReportDailyEmail.Id
    WHERE (@spName = '' OR (@spName <> '' AND ReportDailyEmail.StoredProcedureName LIKE '%' + @spName + '%'))
    AND (@freqType = 0 OR ReportDailyEmail.FreqType = @freqType)
    ORDER BY
        CASE WHEN @sortDir = 'asc' AND @sortCol = 0 THEN ReportDailyEmail.Id END ASC,
        CASE WHEN @sortDir = 'asc' AND @sortCol = 1 THEN StoredProcedureName END ASC,
        CASE WHEN @sortDir = 'asc' AND @sortCol = 2 THEN Status END ASC,
        CASE WHEN @sortDir = 'asc' AND @sortCol = 3 THEN LastProcessedDateTime END ASC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 0 THEN ReportDailyEmail.Id END DESC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 1 THEN StoredProcedureName END DESC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 2 THEN Status END DESC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 3 THEN LastProcessedDateTime END DESC,
        CASE WHEN @sortDir = 'asc' AND @sortCol = 4 THEN Enabled END ASC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 4 THEN Enabled END DESC,
        CASE WHEN @sortDir = 'asc' AND @sortCol = 5 THEN NextRunTime END ASC,
        CASE WHEN @sortDir = 'desc' AND @sortCol = 5 THEN NextRunTime END DESC
    OFFSET @SkipRows ROWS 
    FETCH NEXT @PageSize ROWS ONLY;
END
