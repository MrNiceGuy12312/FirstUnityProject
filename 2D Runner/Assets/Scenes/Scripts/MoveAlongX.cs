using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongX : MonoBehaviour
{

    public float moveSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += moveSpeed * Time.deltaTime;
        transform.position = position;
    }
}
