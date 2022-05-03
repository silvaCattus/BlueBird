namespace StateMachine.Dog
{
    public class WatchdogFromSleepingTransition : Transition
    {
        private void Start()
        {
        }

        private void OnEnable()
        {
            Invoke(nameof(SetNeedTransition), 8f);
        }
    }
}