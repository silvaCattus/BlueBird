using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Dog
{
    public class Dog : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private GameObject _dogParentObj;

        public List<AnimatorControllerParameter> BoolAnimParameters { get; private set; }
        public GameObject Target { get { return _target; } }
        public GameObject DogParentObj { get { return _dogParentObj; } }
        public CharacterController Controller { get; private set; }
        public Animator Animator { get; private set; }
        public int BoolAnimationNumber { get; private set; }
        public bool IsSleeping { get; private set; }


        private void Start()
        {
            BoolAnimParameters = new List<AnimatorControllerParameter>();
            Animator = GetComponent<Animator>();
            Controller = _dogParentObj.GetComponent<CharacterController>();

            var allAnimParameters = Animator.parameters;

            for (int i = 0; i < allAnimParameters.Length; i++)
            {
                if (allAnimParameters[i].type == AnimatorControllerParameterType.Bool)
                {
                    BoolAnimParameters.Add(allAnimParameters[i]);
                }
            }

            BoolAnimationNumber = BoolAnimParameters.Count;
        }

        public void SetIsSleeping()
        {
            IsSleeping = !IsSleeping;
        }
    }
}