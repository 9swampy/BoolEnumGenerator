namespace PrimS.BoolParameterGenerator;

public static class StringExtensions
{
  public static string TrimEnd(this string str, string suffix)
  {
    return str.EndsWith(suffix) ? str.Substring(0, str.Length - suffix.Length) : str;
  }
}
