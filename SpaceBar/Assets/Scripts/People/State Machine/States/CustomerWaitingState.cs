using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingState : CustomerState
{
    public CustomerWaitingState(Customer customer, CustomerStateMachine stateMachine) : base(customer, stateMachine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Entered Waiting");

        base.EnterState();

        
    }


    public override void ExitState()
    {
        base.ExitState();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.N))
        {
            _customer.StateMachine.ChangeState(_customer.OrderingState);
        }
    }
}
