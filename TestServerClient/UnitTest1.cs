using Xunit;

public class ServerTests
{
    [Theory]
    [InlineData("2023-10-10 10:12:11", "равно!")] // Пример, когда четные и нечетные цифры равны
    [InlineData("2023-10-10 10:13:11", "нечет!")] // Пример, когда нечетных больше
    [InlineData("2023-10-10 10:10:12", "чет!")]  // Пример, когда четных больше

    public void TestGetMessageBasedOnDateTime(string dateTime, string expectedMessage)
    {
        string result = MessageGenerator.GetMessageBasedOnDateTime(dateTime);
        Assert.Equal(expectedMessage, result);
    }
}

public static class MessageGenerator
{
    public static string GetMessageBasedOnDateTime(string dateTime)
    {
        int evenCount = 0;
        int oddCount = 0;

        foreach (char digit in dateTime)
        {
            if (char.IsDigit(digit))
            {
                if (digit % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
        }

        if (evenCount > oddCount)
            return "чет!";
        else if (oddCount > evenCount)
            return "нечет!";
        else
            return "равно!";
    }
}