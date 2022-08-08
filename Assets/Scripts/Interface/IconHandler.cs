using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IconHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text textAmount;
    [SerializeField] private Image portrait;
    [SerializeField] private Image lockedIcon;
    [SerializeField] private Image selectedIcon;
    [SerializeField] private Image currentlyUsing;
    public Costume costume;
    public CollectableStored collectableStored;

    private void SetAllValuesCostume(bool isInShop)
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
        costume = GameManager.Instance.inventaryManager.GetCostume(index);
        SetAllValuesCostume(isInShop);
    }

    public void UpdateCollectableValues(int index)
    {
        collectableStored = GameManager.Instance.inventaryManager.GetCollectable(index);
        SetAllValuesCollectable();
    }
}
