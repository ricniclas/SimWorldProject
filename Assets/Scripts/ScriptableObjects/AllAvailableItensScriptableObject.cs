using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Itens List",menuName = "ScriptableObjects/Itens List", order = 1)]
public class AllAvailableItensScriptableObject : ScriptableObject
{
    public ItemsList allItens;
    public int money;
}
