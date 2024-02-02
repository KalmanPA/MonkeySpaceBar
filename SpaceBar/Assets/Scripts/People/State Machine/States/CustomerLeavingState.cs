using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeavingState : CustomerState
{
    public CustomerLeavingState(Customer customer, CustomerStateMachine stateMachine) : base(customer, stateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Entered Leaving");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        

        base.Update();
    }
}
