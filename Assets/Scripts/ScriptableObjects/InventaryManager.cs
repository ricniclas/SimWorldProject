using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{
    [SerializeField] private AllAvailableItensScriptableObject allItens;

    public void StoreItem(Collectable collectable)
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

    public bool SellItem(Collectable collectable)
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

    public Costume[] GetCostumes()
    {
        return allItens.allItens.costumesList;
    }

    public Costume GetCostume(int index)
    {
        return allItens.allItens.costumesList[index];
    }

    public CollectableStored[] GetCollectables()
    {
        return allItens.allItens.collectablesStored;
    }

    public CollectableStored GetCollectable(int index)
    {
        return allItens.allItens.collectablesStored[index];
    }
    public costumeType GetCurrentlyUsing()
    {
        return allItens.currentlyUsing;
    }
}
