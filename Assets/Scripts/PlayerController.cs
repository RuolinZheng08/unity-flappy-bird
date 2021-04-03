using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;
    public bool isGameOver;

    float yBoundary = 8;
    [SerializeField] float upForce;
    Rigidbody playerRb;
    AudioSource playerAudio;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
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
            playerAudio.PlayOneShot(explosionSound);
            isGameOver = true;
            Destroy(collision.gameObject);
            // stop bird flapping animation
            Animator anim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
            anim.enabled = false;

            gameManager.EndGame();
        };
    }
}
