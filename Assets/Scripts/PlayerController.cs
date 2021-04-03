using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGameOver; // read by all other scripts
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;

    float yBoundary = 8;
    float startForce = 5;
    [SerializeField] float upForce;
    Rigidbody playerRb;
    AudioSource playerAudio;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // a small bump at the start
        playerRb.AddForce(Vector3.up * startForce);
    }

    void Update()
    {
        if (isGameOver) {
            return;
        }
        // keep player from flying too high
        if (transform.position.y > yBoundary) {
            transform.position = new Vector3(transform.position.x, yBoundary, transform.position.z);
            // clear force
            playerRb.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Space)) {
            playerRb.AddForce(Vector3.up * upForce);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            explosionParticle.Play();
            isGameOver = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        };
    }
}
