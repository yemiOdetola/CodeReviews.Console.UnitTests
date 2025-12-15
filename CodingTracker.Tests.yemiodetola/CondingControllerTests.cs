using CodingTracker.yemiOdetola;
using Xunit;

namespace CodingTracker.Tests.yemiodetola;

public class CodingControllerTests
{
  [Fact]
  public void CalculateDuration_SameDayValidTimes_ReturnsCorrectDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 9, 0, 0);
    var endTime = new DateTime(2025, 12, 14, 17, 0, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.Equal(TimeSpan.FromHours(8), result);
  }


  [Fact]
  public void CalculateDuration_WithMinutes_ReturnsCorrectDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 10, 30, 0);
    var endTime = new DateTime(2025, 12, 14, 13, 45, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.Equal(new TimeSpan(3, 15, 0), result);
    Assert.Equal(195, result.TotalMinutes);
  }

  [Fact]
  public void CalculateDuration_EndTimeBeforeStartTime_ReturnsZero()
  {
    var startTime = new DateTime(2025, 12, 14, 12, 0, 0);
    var endTime = new DateTime(2025, 12, 14, 10, 0, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.Equal(TimeSpan.Zero, result);
  }


  [Fact]
  public void CalculateDuration_SameStartAndEndTime_ReturnsZero()
  {

    var starttime = new DateTime(2025, 12, 14, 15, 30, 0);
    var endtime = new DateTime(2025, 12, 14, 15, 30, 0);

    var result = CodingController.CalculateDuration(starttime, endtime);

    Assert.Equal(TimeSpan.Zero, result);
  }

  [Fact]
  public void CalculateDuration_CrossingMidnight_ReturnsCorrectDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 23, 0, 0);
    var endTime = new DateTime(2025, 12, 15, 2, 0, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.Equal(TimeSpan.FromHours(3), result);
  }

  [Fact]
  public void CalculateDuration_MultipleDay_ReturnsCorrectDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 9, 0, 0);
    var endTime = new DateTime(2025, 12, 16, 14, 0, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);
    Assert.Equal(TimeSpan.FromHours(53), result);

    Assert.Equal(2, result.Days);
    Assert.Equal(5, result.Hours);
  }

  [Fact]
  public void CalculateDuration_WithSeconds_ReturnsCorrectDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 14, 30, 45);
    var endTime = new DateTime(2025, 12, 14, 16, 45, 30);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.Equal(2, result.Hours);
    Assert.Equal(14, result.Minutes);
    Assert.Equal(45, result.Seconds);

    Assert.Equal(8085, result.TotalSeconds);
  }

  [Fact]
  public void CalculateDuration_ValidInput_DoesNotReturnNull()
  {
    var startTime = new DateTime(2025, 12, 14, 10, 0, 0);
    var endTime = new DateTime(2025, 12, 14, 12, 0, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.NotNull(result);
  }

  [Fact]
  public void CalculateDuration_ValidTimesForwardOrder_ReturnsPositiveDuration()
  {
    var startTime = new DateTime(2025, 12, 14, 8, 0, 0);
    var endTime = new DateTime(2025, 12, 14, 12, 30, 0);

    var result = CodingController.CalculateDuration(startTime, endTime);

    Assert.True(result > TimeSpan.Zero);

    Assert.Equal(TimeSpan.FromHours(4.5), result);
  }
}