using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public InventaryManager inventaryManager;
    public static GameManager Instance { get; private set; }
    public InputActions inputAction;
    [HideInInspector]public StageManager stageManager;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        if (SystemInfo.deviceType == DeviceType.Handheld)
            Application.targetFrameRate = 30;
        else
            Application.targetFrameRate = 60;
    }
}
