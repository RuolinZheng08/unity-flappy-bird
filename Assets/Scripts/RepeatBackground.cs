using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatWidth;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}
