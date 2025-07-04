namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        var age = today.Year - dob.Year;

        if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day))
        {
            age--;
        }

        return age;
    }
}