namespace Dopusteam.Otus.Reflection.ConsoleApp.Examples;

public static class TaskExample
{
    public static bool HasDifference(int first, int second)
    {
        return first != second;
    }

    #region example 2

    public static bool HasDifference(Item first, Item second)
    {
        return first.Id != second.Id;
    }

    #endregion

    #region example 3

    public static bool HasDifference(OtherItem first, OtherItem second)
    {
        return first.Id != second.Id;
    }

    #endregion

    #region example 4

    public static bool HasDifference(object first, object second)
    {
        var type = first.GetType();
        var type2 = second.GetType();

        return true;
    }

    #endregion
}

#region Приватные сущности

public class Item
{
    public int Id { get; }

    public Item(int id)
    {
        Id = id;
    }
}

#region Вторая

public class OtherItem
{
    public int Id { get; }

    public OtherItem(int id)
    {
        Id = id;
    }
}

#endregion

#endregion