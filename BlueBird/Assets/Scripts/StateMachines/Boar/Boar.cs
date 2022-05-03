using BlueBird.Inputs;
using UnityEngine;
using UnityEngine.AI;

namespace StateMachine.Boar
{
    public class Boar : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _hungryBar;

        public NavMeshAgent Agent { get; private set; }
        public GameObject Player { get { return _player; } }
        public GameObject Target { get; private set; }
        public Animator Animator { get; private set; }
        public int HungryPoints { get; private set; }
        private PointsBar _hungryIndicator;

        void Start()
        {
            HungryPoints = 15;
            _hungryIndicator = _hungryBar.GetComponent<PointsBar>();
            Animator = GetComponent<Animator>();
            Agent = GetComponent<NavMeshAgent>();
            Player.GetComponent<PlayerMovement>().AppleIsThrown += SetTarget;
            SetPlayerIsTarget();
        }

        public void SetTarget(GameObject target)
        {
            Target = target;
        }

        //INVOKE FROM "Eat" ANIMATION
        public void ReduceHunger()
        {
            Debug.Log("Boar ate the apple");
            HungryPoints--;
            _hungryIndicator.MoveBarCursor();
        }

        //INVOKE FROM "Eat" ANIMATION
        public void SetPlayerIsTarget()
        {
            SetTarget(Player);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce((collision.transform.position - transform.position).normalized * 400f, ForceMode.Impulse);
            }
        }

        private void OnDisable()
        {
            if (Player != null)
                Player.GetComponent<PlayerMovement>().AppleIsThrown -= SetTarget;
        }
    }
}
