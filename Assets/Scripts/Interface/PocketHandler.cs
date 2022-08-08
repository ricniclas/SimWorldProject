using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PocketHandler : MonoBehaviour
{
    [SerializeField] private GameObject costumePrefab;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private GameObject costumesParent;
    [SerializeField] private GameObject collectableParent;
    private IconHandler[] costumeIconHandlers;
    private IconHandler[] collectableIconHandlers;


    private void Start()
    {
        costumeIconHandlers = new IconHandler[GameManager.Instance.inventaryManager.GetCostumes().Length];
        collectableIconHandlers = new IconHandler[GameManager.Instance.inventaryManager.GetCollectables().Length];
        InstantiateCostumes();
        InstantiateCollectables();
    }

    public void InstantiateCostumes()
    {
        foreach (Transform child in costumesParent.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < costumeIconHandlers.Length; i++)
        {
            IconHandler iconHandler = Instantiate(costumePrefab, costumesParent.transform).GetComponent<IconHandler>();
            iconHandler.UpdateCostumeValues(i,false);
            costumeIconHandlers[i] = iconHandler;
        }
    }

    public void InstantiateCollectables()
    {
        foreach (Transform child in collectableParent.transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < collectableIconHandlers.Length; i++)
        {
            IconHandler iconHandler = Instantiate(collectablePrefab, collectableParent.transform).GetComponent<IconHandler>();
            iconHandler.UpdateCollectableValues(i);
            collectableIconHandlers[i] = iconHandler;
        }

    }

    public void UpdateCostumes()
    {
        for (int i = 0; i < costumeIconHandlers.Length; i++)
        {
            costumeIconHandlers[i].UpdateCostumeValues(i,false);
        }
    }
}
