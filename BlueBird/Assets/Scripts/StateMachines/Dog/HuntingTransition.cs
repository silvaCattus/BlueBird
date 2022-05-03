using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Dog
{
    public class HuntingTransition : Transition
    {
        [SerializeField] private DogHuntingZoneTrigger _huntTrigger;

        private void Start()
        {
        }

        private void OnEnable()
        {
            _huntTrigger.BirdEnteredToTheTrigger += SetNeedTransition;
        }

        private void OnDisable()
        {
            _huntTrigger.BirdEnteredToTheTrigger -= SetNeedTransition;
        }
    }
}