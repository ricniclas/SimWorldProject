using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InventaryManager inventaryManager;
    public InputActions inputAction;
    public SoundManager soundManager;
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
