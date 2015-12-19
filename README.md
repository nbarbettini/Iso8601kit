# SimpleDuration
Easily convert to and from ISO 8601 duration strings from .NET

## Rationale

If you need to convert to or from an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations) string (e.g., `"P3DT4H"`) in .NET, your choices are limited:

* Use [`XmlConvert.ToTimeSpan()` and `XmlConvert.ToString()`](http://stackoverflow.com/questions/12466188/how-do-i-convert-an-iso8601-timespan-to-a-c-sharp-timespan)
* Use a full date-handling library like [NodaTime](http://nodatime.org/1.3.x/userguide/serialization.html)

If you deal with a lot of dates and timezones, the latter is a great solution. If, however, you simply need to convert the odd ISO 8601 duration into a `TimeSpan` (or vice versa), this tiny library makes it dead simple without requiring any external dependencies.

## Limitations

This library cannot support the year (Y) and month (M) designators. Correctly counting years and months requires knowledge of the local calendar and timezone, to overcome edge cases like leap years and Daylight Savings changes. This is possible in NodaTime, but for the sake of simplicity, it is omitted here.

:bulb: Use this library if you have small durations of weeks or less, or don't mind representing years as `P52W`.

## Usage

To convert a `TimeSpan` to ISO 8601 duration format:
```csharp
var oneHour = TimeSpan.FromHours(1);
var result = Iso8601Duration.Format(oneHour); // PT1H
```

To parse an ISO 8601 duration string to a `TimeSpan`:
```csharp
var oneDayFiveMinutes = "P1DT5M";
var result = Iso8601Duration.Parse(oneDayFiveMinutes); // TimeSpan.Days == 1 && TimeSpan.Minutes == 5
```
