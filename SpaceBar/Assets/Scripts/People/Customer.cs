using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Customer : MonoBehaviour, ICarryable, IInteractible
{
    //Person _person;

    //public event Action CharacterWasPickedUp;

    public string OrderID = null;

    public CustomerStateMachine StateMachine { get; set; }

    public CustomerWaitingState WaitingState { get; set; }

    public CustomerOrderingState OrderingState { get; set; }

    public CustomerDrinkingState DrinkingState { get; set; }

    public CustomerLeavingState LeavingingState { get; set; }

    public void Interact()
    {

    }

    public void Selecet()
    {

    }

    public void PickUp()
    {
        //CharacterWasPickedUp?.Invoke();
        if (StateMachine.CurrentCustomerState == WaitingState)
        {
            return;
        }

        if (StateMachine.CurrentCustomerState != LeavingingState && StateMachine.CurrentCustomerState != WaitingState)
        {
            StateMachine.ChangeState(WaitingState);
        }
    }

    public void SitDown()
    {
        if (StateMachine.CurrentCustomerState == LeavingingState)
        {
            return;
        }

        StateMachine.ChangeState(OrderingState);
    }

    public void SitUp()
    {
        if (StateMachine.CurrentCustomerState == LeavingingState)
        {
            return;
        }

        StateMachine.ChangeState(WaitingState);
    }

    private void Awake()
    {
        //Debug.Log("Faszom");

        //_person = GetComponent<Person>();
        //_person.CharacterWasPickedUp += Person_ObjectWasPickedUp;
        //_person.CharacterSatDown += Person_CharacterSatDown;
        //_person.CharacterStoodUp += Person_CharacterStoodUp;


        StateMachine = new CustomerStateMachine();

        WaitingState = new CustomerWaitingState(this, StateMachine);

        OrderingState = new CustomerOrderingState(this, StateMachine);

        DrinkingState = new CustomerDrinkingState(this, StateMachine);

        LeavingingState = new CustomerLeavingState(this, StateMachine);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Drink"))
        {
            Drink drinkScript = collision.gameObject.GetComponent<Drink>();

            if (drinkScript.OrderId == OrderID)
            {
                Destroy(collision.gameObject);

                StateMachine.ChangeState(DrinkingState);
            }
        }
    }
}
