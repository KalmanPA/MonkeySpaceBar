using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Person : MonoBehaviour, ICarryable, IInteractible
{
    //public bool IsBeingCarried { get; set; } = false;

    public event Action CharacterWasPickedUp;
    public event Action CharacterSatDown;
    public event Action CharacterStoodUp;

    public void Interact()
    {
        
    }

    public void Selecet()
    {
        
    }

    public void PickUp()
    {
        //if (IsBeingCarried)
        //{
        //    IsBeingCarried = false;
        //}
        //else
        //{
        //    IsBeingCarried = true;
        //}

        CharacterWasPickedUp?.Invoke();

        //transform.Rotate(new Vector3(-90, 0, 0));

        //RotateWhenPickedUp();
    }

    public void SitDown()
    {
        CharacterSatDown?.Invoke();
    }

    public void SitUp()
    {
        CharacterStoodUp?.Invoke();
    }

    
}
