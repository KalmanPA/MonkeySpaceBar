using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;

    //public float moveSpeed = 5f;

    //private Rigidbody rb;

    [SerializeField] float _speed = 6f;

    private Vector3 _mousePosition;

    //public int A;

    public LayerMask FloorLayer;

    private float _gravity = -9.81f;
    private float _gravityMultiplier = 3.0f;
    private float _velocity;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    void Update()
    {
        LocateMouse();
        RoateTowardsMouse();
        MovePlayer();

        //ApplyGravity();
    }

    private float ApplyGravity()
    {
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }

        return _velocity;
    }

    private void RoateTowardsMouse()
    {
        transform.LookAt(_mousePosition, Vector3.up);
    }

    private void MovePlayer()
    {


        //float xDirection = Input.GetAxis("Horizontal");
        //float yDirection = Input.GetAxis("Vertical");
        //Vector3 direction = xDirection * Camera.main.transform.right + yDirection * Camera.main.transform.forward;
        //direction.y = 0f;


        //MoveCharacter(direction);


        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        Vector3 direction = xDirection * Camera.main.transform.right + yDirection * Camera.main.transform.forward;
        //direction.y = 0f;

        

        direction.y = ApplyGravity();


        _characterController.Move(direction * _speed * Time.deltaTime);


    }

    //private void MoveCharacter(Vector3 moveDirection)
    //{
    //    Vector3 newPosition = transform.position + moveDirection * _speed * Time.deltaTime;

        
    //    rb.MovePosition(newPosition);
    //}

    private void LocateMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, FloorLayer))
        {
            _mousePosition = new Vector3(hit.point.x, 1, hit.point.z);

            //Debug.Log(_mousePosition.ToString());
        }
    }
}
