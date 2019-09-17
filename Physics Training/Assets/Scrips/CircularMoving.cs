using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMoving : MonoBehaviour
{

    public Transform center;
    public float angle = 0;
    public Vector3 offset, distancia;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Finish").transform;
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = center.position - transform.position;
        playerRigidbody.AddForce(distancia);
        playerRigidbody.AddForce(new Vector3(-distancia.y, distancia.x, 0));
    }
}
