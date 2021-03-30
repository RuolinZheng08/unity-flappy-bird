using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float yBoundary = 8;
    [SerializeField] float upForce;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // keep player from flying too high
        if (transform.position.y > yBoundary) {
            transform.position = new Vector3(transform.position.x, yBoundary, transform.position.z);
            // clear force
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Space)) {
            playerRb.AddForce(Vector3.up * upForce);
        }
    }
}
