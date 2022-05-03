using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLilyController : MonoBehaviour
{
    private Animator _animator;
    private List<AnimatorControllerParameter> _triggerParams = new List<AnimatorControllerParameter>();
    private int _numberParams;

    void Start()
    {
        _animator = GetComponent<Animator>();

        var parameters = _animator.parameters;
        foreach (var param in parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
                _triggerParams.Add(param);
        }
        _numberParams = _triggerParams.Count;
        Invoke(nameof(StartAnimatoin), 3f);
    }

    private void StartAnimatoin()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("WaitingIdle", true);
    }

    public void PlayRandomAnimation()
    {
        int randNum = Random.Range(0, _numberParams-1);
        _animator.SetTrigger(_triggerParams[randNum].name);
        _animator.SetBool("WaitingIdle", false);
    }

    public void SetWaitingIdleAnim()
    {
        _animator.SetBool("WaitingIdle", true);
    }
}
