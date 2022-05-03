using UnityEngine;

namespace StateMachine.Boar
{
    public class RunTransition : Transition
    {
        [SerializeField] private Boar _boar;

        private void Start()
        {
        }

        //INVOKE FROM "Eat" ANIMATION
        public void CheckHungry()
        {
            Debug.Log(1);
            if (_boar.HungryPoints > 0)
                SetNeedTransition();
        }
    }
}
