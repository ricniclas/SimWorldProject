using UnityEngine;
[System.Serializable]
public class Costume
{
    public string name;
    public costumeType costumeType;
    public int price;
    public Sprite icon;
    public bool unlocked;
}

public enum costumeType
{
    WHITE,
    BLUE,
    GREEN,
    ORANGE,
    PURPLE,
    BLACK
}
