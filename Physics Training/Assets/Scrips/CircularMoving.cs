using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMoving : MonoBehaviour
{

    //Public variables
    public float speed = 10, initialDistance = 0;
    public bool moving = false;
    public Vector3 distance, perpendicularDistance, normalizedDistance;
    //Private Variables
    Transform center;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Center").transform;
        playerRigidbody = GetComponent<Rigidbody>();
        distance = center.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moving = !moving;
            initialDistance = distance.magnitude;
        }
        if(moving)
        {
            //We desactivate the gravity so it doesn't affect the movement
            playerRigidbody.useGravity = false;

            //Refresh the distance vector every second to get the proper normalized vector(normalizedDistance) below
            distance = center.position - transform.position;
            normalizedDistance = distance.normalized;

            //We get the perpendicular vector to normalizedDistance, this vector will be in every frame tangent to the circumference that the object
            //attached to this script will travel
            perpendicularDistance = new Vector3(-normalizedDistance.y, normalizedDistance.x, 0);

            //We modify the velocity component of our object matching it with the tangent vector, and multiplied by the distance to make the
            //circumference radio equal to the initial distance they were before starting the movement
            playerRigidbody.velocity = perpendicularDistance * initialDistance;
        }
    }
}
