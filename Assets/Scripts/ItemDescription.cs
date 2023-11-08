public enum ItemType
{
    Weapon,
    Armor,
    Thingamajing
}

public struct ItemDescription
{
    public string Name;
    public ItemType Type;
    public int Amount;
}