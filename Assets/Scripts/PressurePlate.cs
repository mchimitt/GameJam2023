using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
    public delegate void PlateTriggered();
    public event PlateTriggered OnPlateTriggered;
    public event PlateTriggered OnPlateExit;

    [SerializeField] RoomDoor myDoor;
    [SerializeField] List<PressurePlate> sisterPlates;
    [SerializeField] GameObject currentPlayer;
    //public static Action<bool> OnPress = delegate { };


    public bool triggered = false;

    private void Awake()
    {
        if (!myDoor)
        {
            Debug.LogError("No Door attached to " + this.name);
            //myDoor = GameObject.FindObjectOfType<RoomDoor>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NewPlayerMovement>() && !other.isTrigger)
        {
            currentPlayer = other.gameObject;

            OnPlateTriggered?.Invoke();
            //play pressure plate animation
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NewPlayerMovement>() && !other.isTrigger)
        {
            currentPlayer = null;

            OnPlateExit?.Invoke();
            //play pressure plate animation
        }
    }
}
