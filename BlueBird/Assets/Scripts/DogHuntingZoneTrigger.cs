using System;
using System.Collections.Generic;
using UnityEngine;

public class DogHuntingZoneTrigger : MonoBehaviour
{
    public Action BirdEnteredToTheTrigger;
    public Action BirdExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            if(BirdEnteredToTheTrigger != null)
                BirdEnteredToTheTrigger();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            if (BirdExitTrigger != null)
                BirdExitTrigger();
    }
}
