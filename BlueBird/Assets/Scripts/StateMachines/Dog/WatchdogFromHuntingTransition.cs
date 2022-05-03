using UnityEngine;

namespace StateMachine.Dog
{
    public class WatchdogFromHuntingTransition : Transition
    {
        [SerializeField] private DogHuntingZoneTrigger _huntTrigger;

        void Start()
        {
        }

        private void OnEnable()
        {
            _huntTrigger.BirdExitTrigger += SetNeedTransition;
        }

        private void OnDisable()
        {
            _huntTrigger.BirdExitTrigger -= SetNeedTransition;
        }

    }
}