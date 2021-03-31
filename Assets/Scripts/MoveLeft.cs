using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    float leftBound = -55;
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isGameOver) {
            return;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background")) {
            Destroy(gameObject);
        }
    }
}
