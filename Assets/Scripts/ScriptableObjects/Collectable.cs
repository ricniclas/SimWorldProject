using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Collectable
{
    public string collectableName;
    public CollectableType collectableType;
}

public enum CollectableType
{
    APPLE,
    GRAPE,
    MILK,
    MUSHROOM,
    LILY,
    FLOWER
}