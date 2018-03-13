using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;
    private string notes;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.notes = notes;
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekDayComparison = weekDay.CompareTo(other.weekDay);
        if (weekDayComparison != 0) return weekDayComparison;
        return string.Compare(notes, other.notes, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.weekDay} - {this.notes}";
    }
}
