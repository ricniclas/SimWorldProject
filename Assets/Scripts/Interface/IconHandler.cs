using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IconHandler : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text textAmount;
    [SerializeField] private Image portrait;
    [SerializeField] private Image lockedIcon;
    [SerializeField] private Image selectedIcon;
    [SerializeField] private Image currentlyUsing;
    public Costume costume;
    public CollectableStored collectableStored;

    private bool isInShop;
    private int index;

    private void SetAllValuesCostume()
    {
        portrait.sprite = costume.icon;
        if (isInShop)
        {
            textAmount.SetText(costume.price.ToString());
            textAmount.enabled = true;
            currentlyUsing.enabled = false;
            lockedIcon.enabled = costume.unlocked;
        }
        else
        {
            textAmount.enabled = false;
            if (costume.costumeType == GameManager.Instance.inventaryManager.GetCurrentlyUsing())
                currentlyUsing.enabled = true;
            else
                currentlyUsing.enabled = false;
            lockedIcon.enabled = !costume.unlocked;
        }
    }

    private void SetAllValuesCollectable()
    {
        int amount = collectableStored.amountStored;
        textAmount.SetText(amount.ToString());
        textAmount.enabled = true;
        portrait.sprite = collectableStored.icon;
        lockedIcon.enabled = false;
        currentlyUsing.enabled = false;
    }


    public void UpdateCostumeValues(int index, bool isInShop)
    {
        this.index = index;
        this.isInShop = isInShop;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(costumeOnClick);
        costume = GameManager.Instance.inventaryManager.GetCostume(this.index);
        SetAllValuesCostume();
    }

    public void UpdateCollectableValues(int index, bool isInShop)
    {
        this.index = index;
        this.isInShop = isInShop;
        collectableStored = GameManager.Instance.inventaryManager.GetCollectable(this.index);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(collectableOnClick);
        SetAllValuesCollectable();
    }

    private void collectableOnClick()
    {
        if (isInShop)
        {
            if (collectableStored.amountStored <= 0)
            {
                Debug.Log("No Item left");
            }
            else
            {
                GameManager.Instance.inventaryManager.SellItem(index);
            }
        }
    }

    private void costumeOnClick()
    {
        if (isInShop)
        {
            if (costume.price <= GameManager.Instance.inventaryManager.GetMoney() && !costume.unlocked)
            {
                GameManager.Instance.inventaryManager.BuyCostume(index);
            }
            else
            {
                Debug.Log("No enough cash");
            }
        }
        else
        {
            if (costume.unlocked)
            {
                GameManager.Instance.inventaryManager.SetNewCostume(costume.costumeType);
            }
            else
            {
                Debug.Log("Not unlocked");
            }
        }
    }
}
