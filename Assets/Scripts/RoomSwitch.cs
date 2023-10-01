using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    [SerializeField] GameObject virtualCam;
    [SerializeField] List<GameObject> players;
    public bool hideFourthWall = false;
    public GameObject fourthWall;
    public int numPlayersNeeded = 4;

    private void Awake()
    {
        virtualCam = GameObject.Find("Virtual Camera");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NewPlayerMovement>() && !other.isTrigger)
        {
            players.Add(other.gameObject);

            if (players.Count >= numPlayersNeeded) //TODO change to 4
            {
                Cinemachine.CinemachineConfiner confiner = virtualCam.GetComponent<Cinemachine.CinemachineConfiner>();
                confiner.m_BoundingVolume = this.GetComponent<Collider>();

                if (hideFourthWall && fourthWall)
                    fourthWall.SetActive(false);

                players.Clear();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerAttributes>() && !other.isTrigger)
        {
            if (players.Count > 0)
                players.Remove(other.gameObject);
        }
    }
}
