using UnityEngine;

namespace StateMachine.Boar
{
    public class SleepTransition : Transition
    {
        [SerializeField] private Boar _boar;

        private void Start()
        {
        }

        //INVOKE FROM "Eat" ANIMATION
        public void CheckHungry()
        {
            Debug.Log(2);

            if (_boar.HungryPoints <= 0)
                SetNeedTransition();
        }
    }
}