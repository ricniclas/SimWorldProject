using UnityEngine;
[System.Serializable]
public class Costume
{
    public string name;
    public CostumeType costumeType;
    public int price;
    public Sprite icon;
    public bool unlocked;
}

public enum CostumeType
{
    WHITE,
    BLUE,
    GREEN,
    ORANGE,
    PURPLE,
    BLACK
}
