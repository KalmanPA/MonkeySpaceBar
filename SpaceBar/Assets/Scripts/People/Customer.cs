using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Customer : MonoBehaviour
{
    Person _person;

    public CustomerStateMachine StateMachine { get; set; }

    public CustomerWaitingState WaitingState { get; set; }

    public CustomerOrderingState OrderingState { get; set; }

    public CustomerDrinkingState DrinkingState { get; set; }

    public CustomerLeavingState LeavingingState { get; set; }

    private void Awake()
    {
        //Debug.Log("Faszom");

        _person = GetComponent<Person>();
        _person.CharacterWasPickedUp += Person_ObjectWasPickedUp;
        _person.CharacterSatDown += Person_CharacterSatDown;
        _person.CharacterStoodUp += Person_CharacterStoodUp;


        StateMachine = new CustomerStateMachine();

        WaitingState = new CustomerWaitingState(this, StateMachine);

        OrderingState = new CustomerOrderingState(this, StateMachine);

        DrinkingState = new CustomerDrinkingState(this, StateMachine);

        LeavingingState = new CustomerLeavingState(this, StateMachine);
    }

    private void Person_CharacterStoodUp()
    {
        if (StateMachine.CurrentCustomerState == LeavingingState)
        {
            return;
        }

        StateMachine.ChangeState(WaitingState);
    }

    private void Person_CharacterSatDown()
    {
        if (StateMachine.CurrentCustomerState == LeavingingState)
        {
            return;
        }

        StateMachine.ChangeState(OrderingState);
    }

    private void Person_ObjectWasPickedUp()
    {
        if (StateMachine.CurrentCustomerState != LeavingingState && StateMachine.CurrentCustomerState != WaitingState)
        {
            StateMachine.ChangeState(WaitingState);
        }
    }

    private void Start()
    {
        StateMachine.Initialize(WaitingState);

        //Debug.Log("eeee");
    }

    private void Update()
    {
        StateMachine.CurrentCustomerState.Update();
    }
}
