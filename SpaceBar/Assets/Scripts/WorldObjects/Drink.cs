using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour, ICarryable, IInteractible
{
    public string OrderId { get; set; }

    public void Interact()
    {
        
    }

    public void PickUp()
    {
        
    }

    public void Selecet()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Person"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
