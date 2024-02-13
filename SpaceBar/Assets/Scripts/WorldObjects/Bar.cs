using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bar : MonoBehaviour, IInteractible
{
    [SerializeField] GameObject _drinkPrefab;

    [SerializeField] Transform _drinkSpawnPoint;

    bool _isOrdering;

    List<int> _orderNumbers = new List<int>();
    public void Interact()
    {
        _isOrdering = true;
    }

    public void Selecet()
    {
        
    }

    private void Update()
    {
        if (_isOrdering)
        {
            CheckForOrderInput();

            if (_orderNumbers.Count == 4)
            {
                _isOrdering = false;
                GenerateDrink();
            }
        }
    }

    private void GenerateDrink()
    {
        GameObject drink = Instantiate(_drinkPrefab, _drinkSpawnPoint.position, _drinkPrefab.transform.rotation);

        drink.GetComponent<Drink>().OrderId = ConvertOrderToID();

        _orderNumbers.Clear();
    }

    private string ConvertOrderToID()
    {
        return string.Join("", _orderNumbers);
    }

    private void CheckForOrderInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _orderNumbers.Add(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _orderNumbers.Add(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _orderNumbers.Add(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _orderNumbers.Add(4);
        }


    }
}
