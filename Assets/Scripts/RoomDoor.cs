using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    
    [SerializeField] List<PressurePlate> daughterPlates;
    [SerializeField] Animator myAnimator;
    private int lockCount;
    private void OnEnable()
    {
        if (daughterPlates.Count == 0)
        {
            Debug.LogError("No plates attached to " + name);
            return;
        }

        foreach (PressurePlate pressurePlate in daughterPlates)
        {
            pressurePlate.OnPlateTriggered += PlateTriggerLogic;
            pressurePlate.OnPlateExit += PlateExitLogic;
        }
        lockCount = daughterPlates.Count;

    }

    private void PlateTriggerLogic()
    {
        //light up one of the lights on the door or cause some sort of feedback

        //unlock one of the 'locks'
        lockCount -= 1;

        //open door if all 'locks' open
        if (lockCount <= 0)
        {
            if (myAnimator)
                myAnimator.SetBool("Open", true);
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false; //failsafe in case animation fails or is not set
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
                

            //auditory and visual feedback
        }


    }

    private void PlateExitLogic()
    {
        //unlight up one of the lights on the door or cause some sort of feedback

        //lock one of the 'locks'
        lockCount += 1;

        //close door if not all 'locks' open
        if (lockCount > 0)
        {
            if (myAnimator)
                myAnimator.SetBool("Open", false);
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true; //failsafe in case animation fails or is not set
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
                
            //auditory and visual feedback
        }
    }

    private void OnDisable()
    {
        foreach (PressurePlate pressurePlate in daughterPlates)
        {
            pressurePlate.OnPlateTriggered -= PlateTriggerLogic;
            pressurePlate.OnPlateExit -= PlateExitLogic;
        }
    }
}
