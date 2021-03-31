using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    private float leftBound = -55;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background")) {
            Destroy(gameObject);
        }
    }
}
