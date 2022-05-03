namespace StateMachine.Dog
{
    public class SleepingTransition : Transition
    {
        void Start()
        {
        }

        private void OnEnable()
        {
            Invoke(nameof(SetNeedTransition), 15f);
        }
    }
}