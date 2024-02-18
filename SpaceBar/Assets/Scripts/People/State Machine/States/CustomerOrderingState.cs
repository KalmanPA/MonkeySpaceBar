using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderingState : CustomerState
{
    CustomerOrderGenerator _orderGenerator;

    //Customer _customer;

    int[] _orderNumbers = new int[4];
    public CustomerOrderingState(Customer customer, CustomerStateMachine stateMachine) : base(customer, stateMachine)
    {
        _orderGenerator = new CustomerOrderGenerator();

        //_customer = customer;
    }

    public override void EnterState()
    {
        base.EnterState();

        _orderNumbers = _orderGenerator.GenerateOrderNumbers();

        Debug.Log("Entered Ordering");

        Debug.Log($"Order: {_orderGenerator.CustomerOrderID}");

        _customer.CustomerOrderID = _orderGenerator.CustomerOrderID;
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
