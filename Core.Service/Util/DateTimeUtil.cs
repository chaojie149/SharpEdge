namespace Core.Service.Util;

public static class DateTimeUtil
{
    public const string DEFAULT_LONG_DATETIME_FORMAT = "yyyy-MM-dd HH:mm";
    public const string DEFAULT_SHORT_DATETIME_FORMAT = "yyyy-MM-dd";
    public const string DEFAULT_SALEDATE_FORMAT = "yyyyMMdd";

    private static readonly DateTime BASE_DATETIME = new(1970, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc);

    public static DateTime ConvertUTCDateTime(double utcDateTime)
    {
        return BASE_DATETIME.AddMilliseconds(utcDateTime);
    }


    public static long GetTimeStamp()
    {
        // 获取当前时间
        var currentTime = DateTime.UtcNow;

        // Unix时间戳起始时间
        var unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        // 计算当前时间与Unix起始时间的时间间隔
        var elapsedTime = currentTime - unixStartTime;

        // 将时间间隔的总秒数作为Unix时间戳
        var timestamp = (long)elapsedTime.TotalSeconds;
        return timestamp;
    }

    public static DateTime GetDateTimeByTimeStamp(long timestamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
    }
}