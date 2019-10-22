using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongX : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    // Update is called once per frame
	
	void Start()
	{
		moveSpeed -= GameManager.Instance.GameSpeed;
	}
	
	void Update()
    {
		moveSpeed -= 0.0001f;
		Vector3 position = transform.position;
		position.x += moveSpeed * Time.deltaTime;
        transform.position = position;
    }
}
