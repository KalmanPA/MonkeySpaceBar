using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateMachine
{
    public CustomerState CurrentCustomerState { get; set; }

    public void Initialize(CustomerState startingState)
    {
        CurrentCustomerState = startingState;
        CurrentCustomerState.EnterState();
    }

    public void ChangeState(CustomerState nextState)
    {
        CurrentCustomerState.ExitState();
        CurrentCustomerState = nextState;
        CurrentCustomerState.EnterState();
    }
}
