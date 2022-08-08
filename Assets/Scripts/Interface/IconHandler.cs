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
        textAmount.SetText(costume.price.ToString());
        textAmount.enabled = isInShop;
        portrait.sprite = costume.icon;
        lockedIcon.enabled = !costume.unlocked;
        if (costume.costumeType == GameManager.Instance.inventaryManager.GetCurrentlyUsing())
            currentlyUsing.enabled = true;
        else
            currentlyUsing.enabled = false;
    }

    private void SetAllValuesCollectable()
    {
        textAmount.SetText(collectableStored.amountStored.ToString());
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
