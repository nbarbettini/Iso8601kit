namespace Iso8601kit
{
    internal sealed partial class DurationVisitor
    {
        public static DurationVisitor Parse(string duration)
        {
            var visitor = new DurationVisitor(duration);
            visitor.Visit();

            return visitor;
        }

        public bool Valid => this.isValid;

        public double Weeks => this.weeks;

        public double Days => this.days;

        public double Hours => this.hours;

        public double Minutes => this.minutes;

        public double Seconds => this.seconds;
    }
}