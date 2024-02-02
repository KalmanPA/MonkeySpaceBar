using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float LaunchForce = 50f;

    void Update()
    {
        // Check for user input (e.g., pressing the left mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            // Instantiate the projectile at the player's position
            GameObject projectile = Instantiate(projectilePrefab, pos, Quaternion.identity);

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

            LaunchForce = distance * 1.35f;

            // Apply force to the projectile in the calculated direction
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(launchDirection * LaunchForce, ForceMode.Impulse);
        }
    }


}


