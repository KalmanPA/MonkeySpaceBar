using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerState
{
    protected Customer _customer;
    protected CustomerStateMachine _stateMachine;

    public CustomerState(Customer customer, CustomerStateMachine stateMachine)
    {
        _customer = customer;
        _stateMachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Update() { }

    //public virtual void AnimationTriggerType() { }

}
