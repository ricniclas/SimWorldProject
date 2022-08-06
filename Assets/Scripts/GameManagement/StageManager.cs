using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject playableCharacterPrefab;
    private PlayableCharacter playableCharacter;

    private void Start()
    {
        playableCharacter = Instantiate(playableCharacterPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<PlayableCharacter>();

    }
}
