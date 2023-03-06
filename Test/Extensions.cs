namespace Test;

public static class Extensions
{

    public static string CapitalizeFirstLetter(string input)
    {
        string capitalized = input.Substring(0, 1).ToUpper() + input.Substring(1);
        return capitalized;
    }
}
