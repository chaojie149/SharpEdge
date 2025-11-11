namespace Core.Service.Util;

public static class DateTimeUtil
{
    public const string DEFAULT_LONG_DATETIME_FORMAT = "yyyy-MM-dd HH:mm";
    public const string DEFAULT_SHORT_DATETIME_FORMAT = "yyyy-MM-dd";
    public const string DEFAULT_SALEDATE_FORMAT = "yyyyMMdd";

    /// <summary>
    /// Unix 基准时间（以系统本地时区为准）
    /// </summary>
    private static readonly DateTime LocalEpoch =
        TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            TimeZoneInfo.Local);

    /// <summary>
    /// 获取当前系统时间的时间戳（秒）
    /// </summary>
    public static long GetTimeStamp()
    {
        var now = DateTime.Now;
        var span = now - LocalEpoch;
        return (long)span.TotalSeconds;
    }

    /// <summary>
    /// 获取当前系统时间的时间戳（毫秒）
    /// </summary>
    public static long GetTimeStampMs()
    {
        var now = DateTime.Now;
        var span = now - LocalEpoch;
        return (long)span.TotalMilliseconds;
    }

    /// <summary>
    /// 根据时间戳获取系统本地时间
    /// </summary>
    public static DateTime GetDateTimeByTimeStamp(long timestamp)
    {
        return LocalEpoch.AddSeconds(timestamp);
    }

    /// <summary>
    /// 根据毫秒时间戳获取系统本地时间
    /// </summary>
    public static DateTime GetDateTimeByTimeStampMs(long timestampMs)
    {
        return LocalEpoch.AddMilliseconds(timestampMs);
    }
    
    #region UTC版本

    private static readonly DateTime UtcEpoch = 
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long GetUtcTimeStamp() =>
        (long)(DateTime.UtcNow - UtcEpoch).TotalSeconds;

    public static long GetUtcTimeStampMs() =>
        (long)(DateTime.UtcNow - UtcEpoch).TotalMilliseconds;

    public static DateTime GetUtcDateTimeByTimeStamp(long timestamp) =>
        UtcEpoch.AddSeconds(timestamp);

    public static DateTime GetUtcDateTimeByTimeStampMs(long timestampMs) =>
        UtcEpoch.AddMilliseconds(timestampMs);

    #endregion

}