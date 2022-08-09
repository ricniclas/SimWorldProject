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
    public CostumeType GetCurrentlyUsing()
    {
        return allItens.currentlyUsing;
    }

    public void SellItem(int index)
    {
        allItens.allItens.collectablesStored[index].amountStored--;
        allItens.money += allItens.allItens.collectablesStored[index].price;
        GameManager.Instance.stageManager.UpdateCollectables();
        GameManager.Instance.stageManager.UpdateMoney();
    }

    public void BuyCostume(int index)
    {
        allItens.allItens.costumesList[index].unlocked = true;
        allItens.money -= allItens.allItens.costumesList[index].price;
        GameManager.Instance.stageManager.UpdateCollectables();
        GameManager.Instance.stageManager.UpdateCostumes();
        GameManager.Instance.stageManager.UpdateMoney();
    }

    public void SetNewCostume(CostumeType costumeType)
    {
        allItens.currentlyUsing = costumeType;
        GameManager.Instance.stageManager.UpdateCostumes();
        GameManager.Instance.stageManager.SetNewCostume();
    }

    public int GetMoney()
    {
        return allItens.money;
    }
}
