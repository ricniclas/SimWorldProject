using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{
    [SerializeField] private AllAvailableItensScriptableObject allItens;

    public void storeItem(Collectable collectable)
    {
        CollectableStored[] collectablesStored = allItens.allItens.collectablesStored;
        for (int i = 0; i < collectablesStored.Length; i++)
        {
            if(collectablesStored[i].collectable.collectableType == collectable.collectableType)
            {
                collectablesStored[i].amountStored++;
                Debug.Log("You have: " + collectablesStored[i].amountStored + " itens");
            }
        }
    }

    public bool sellItem(Collectable collectable)
    {
        CollectableStored[] collectablesStored = allItens.allItens.collectablesStored;
        for (int i = 0; i < collectablesStored.Length; i++)
        {
            if (collectablesStored[i].collectable.collectableType == collectable.collectableType)
            {
                if(collectablesStored[i].amountStored > 0)
                {
                    collectablesStored[i].amountStored--;
                    allItens.money += collectablesStored[i].price;
                    return true;
                }
                return false;
            }
        }
        return false;
    }
}
