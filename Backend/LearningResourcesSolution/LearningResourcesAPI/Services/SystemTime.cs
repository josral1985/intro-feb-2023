namespace LearningResourcesAPI.Services;

public class SystemTime : ISystemTime
{
    public DateTimeOffset GetCurrent() => DateTimeOffset.Now;
}

public interface ISystemTime //job description
{
    DateTimeOffset GetCurrent();
}

