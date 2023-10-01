using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitcher : MonoBehaviour
{
    int index = 0;
    [SerializeField] List<GameObject> fighters = new List<GameObject>();
    PlayerInputManager manager;
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = fighters[index];
        index++;
     
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        index++;
        if (index > 3)
            index = 0;
        manager.playerPrefab = fighters[index];
    }
}
