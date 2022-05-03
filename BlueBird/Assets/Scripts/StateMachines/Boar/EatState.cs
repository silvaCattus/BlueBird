using UnityEngine;

namespace StateMachine.Boar
{
    public class EatState : State
    {
        [SerializeField] private Boar _boar;
        private GameObject _apple;


        void Start()
        {
            GetComponent<Animator>().SetTrigger("Eat");
            _boar.ReduceHunger();
        }

        public void SetAndStopTarget(GameObject apple)
        {
            _apple = apple;
            if (_apple.TryGetComponent(out Rigidbody rb))
                rb.isKinematic = true;
        }

        //INVOKE FROM "Eat" ANIMATION
        public void DestroyApple()
        {
            Destroy(_apple);
        }
    }
}
