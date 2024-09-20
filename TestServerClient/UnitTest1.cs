using Xunit;

public class ServerTests
{
    [Theory]
    [InlineData("2023-10-10 10:12:11", "�����!")] // ������, ����� ������ � �������� ����� �����
    [InlineData("2023-10-10 10:13:11", "�����!")] // ������, ����� �������� ������
    [InlineData("2023-10-10 10:10:12", "���!")]  // ������, ����� ������ ������

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
            return "���!";
        else if (oddCount > evenCount)
            return "�����!";
        else
            return "�����!";
    }
}