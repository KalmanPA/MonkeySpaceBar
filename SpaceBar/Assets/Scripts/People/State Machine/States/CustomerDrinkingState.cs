using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDrinkingState : CustomerState
{
    public CustomerDrinkingState(Customer customer, CustomerStateMachine stateMachine) : base(customer, stateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Entered Drinking");
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
