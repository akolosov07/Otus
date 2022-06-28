namespace Dopusteam.Otus.Reflection.Comparer;

public static class ObjectsComparer
{
    public static string GetDifference(object first, object second)
    {
        return GetDifferenceInternal(first, second);
    }

    private static string GetDifferenceInternal(object first, object second)
    {
        // todo check todo
        var differences = new List<string>();

        var properties = first.GetType().GetProperties();

        foreach (var property in properties.Where(property => property.PropertyType == typeof(string)))
        {
            var firstValue = property.GetValue(first) as string;
            var secondValue = property.GetValue(second) as string;

            if (firstValue != secondValue)
            {
                differences.Add($"{property.Name}: {firstValue} -> {secondValue}");
            }
        }

        return string.Join(Environment.NewLine, differences);
    }
}