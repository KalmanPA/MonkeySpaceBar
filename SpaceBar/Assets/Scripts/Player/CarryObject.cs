using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public static bool IsCarryingObject;

    GameObject _objectBeingCarried;

    [SerializeField] GameObject _aimObject;

    public LayerMask FloorLayer;

    Rigidbody _objectBeingCarriedRigidbody;

    
    void Update()
    {
        if (IsCarryingObject)
        {
            CarryPickedUpObject();

            MoveAimObject();
        }

        CheckForObjectsToInteractWith();

        if (Input.GetButtonDown("Fire1") && IsCarryingObject)
        {
            IsCarryingObject = false;
            _aimObject.SetActive(false);

            _objectBeingCarried.GetComponent<Rigidbody>().isKinematic = false;

            ThrowCarriedObject();
        }

       
    }

    private void MoveAimObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, FloorLayer))
        {
            _aimObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            //Debug.Log(_mousePosition.ToString());
        }
    }

    private void ThrowCarriedObject()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        // Instantiate the projectile at the player's position
        //GameObject projectile = Instantiate(_objectBeingCarried, pos, Quaternion.identity);

        // Get the mouse position in the world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPosition;

        // Raycast to find the point on the ground where the mouse is pointing
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
        }
        else
        {
            // Default to a point in front of the player if no ground hit is detected
            targetPosition = ray.GetPoint(10f);
        }

        // Calculate the direction from the player to the mouse position
        Vector3 launchDirection = (targetPosition - transform.position).normalized;

        float distance = Vector3.Distance(targetPosition, transform.position);

        float launchForce = distance * 1.7f;

        Rigidbody projectileRb = _objectBeingCarried.GetComponent<Rigidbody>();

        launchForce *= projectileRb.mass;

        // Apply force to the projectile in the calculated direction
        
        projectileRb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }

    private void CarryPickedUpObject()
    {
        _objectBeingCarried.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        _objectBeingCarried.transform.rotation = transform.rotation;

        _objectBeingCarried.transform.Rotate(new Vector3(-90, 0, 0));
    }

    private void CheckForObjectsToInteractWith()
    {
        Collider[] interactables = Physics.OverlapSphere(transform.position + transform.forward * 1.5f, 1.5f);

        foreach (Collider col in interactables)
        {
            if (col.TryGetComponent<IInteractible>(out IInteractible interactableObject))
            {
                interactableObject.Selecet();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactableObject.Interact();

                    if (IsCarryingObject) continue;

                    if (col.TryGetComponent<ICarryable>(out ICarryable carryableObject))
                    {
                        carryableObject.PickUp();

                        PickUpObject(col.gameObject);
                    }
                }
            }
        }
    }

    private void PickUpObject(GameObject gameObject)
    {
        _aimObject.SetActive(true);
        
        IsCarryingObject = true;


        _objectBeingCarried = gameObject;

        _objectBeingCarriedRigidbody = gameObject.GetComponent<Rigidbody>();

        _objectBeingCarried.GetComponent<Rigidbody>().isKinematic = true;

        //Vector3 startingPos = _objectBeingCarried.transform.position;

        //Vector3 endPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        //_objectBeingCarried.transform.position = Vector3.Lerp(startingPos, endPos, 5f);

        //CarryPickedUpObject();
    }
}
