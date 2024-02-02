using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public bool IsOccupied;

    float _time = 0;
    float _delay = 0.5f;

    GameObject _seatedPerson;
    Customer _customerScript;

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsOccupied) return;

        if (!other.gameObject.CompareTag("Person")) return;

        if (_time <= _delay)
        {

            return;
        }

        if (other.gameObject.CompareTag("Person"))
        {
            IsOccupied = true;

            _time = 0;

            SeatCustomer(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!CarryObject.IsCarryingObject)
        {
            if (!IsOccupied) return;

            if (_time <= _delay)
            {
                return;
            }

            if (!other.gameObject.CompareTag("Person")) return;
        }

        

        IsOccupied = false;

        _time = 0;

        _customerScript.SitUp();

        _customerScript = null;
        _seatedPerson = null;

        Debug.Log("Stood up");
    }

    private void SeatCustomer(GameObject gameObject)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        _customerScript = gameObject.GetComponent<Customer>();
        rb.isKinematic = true;

        _seatedPerson = gameObject;

        gameObject.transform.rotation = transform.rotation;

        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        rb.isKinematic = false;

        Debug.Log("Seated");

        _customerScript.SitDown();
    }


}
