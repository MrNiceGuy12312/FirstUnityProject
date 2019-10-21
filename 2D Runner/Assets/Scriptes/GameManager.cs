using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    private float gameSpeed = 1.0f;
    public float GameSpeed { get { return gameSpeed; } }

    public float speedIncrease = 0.01f;

    private void Awake()
    {
        if(instance != null && instance!= this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        gameSpeed += speedIncrease * Time.deltaTime;
    }
}
