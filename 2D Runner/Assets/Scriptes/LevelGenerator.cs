﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float TUNNEL_WIDTH = 10.0f;

    public GameObject[] basePrefabs;

    private GameObject lastBaseObject;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(0, 0, 0);
        CreateNewSegment(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(lastBaseObject.transform.position.x - spawnPoint.x <= -TUNNEL_WIDTH)
        {
            CreateNewSegment();
        }
    }

    private void CreateNewSegment(bool firstSegment = false)
    {
        List<string> validSegments = new List<string>();
        Vector3 offset = new Vector3(TUNNEL_WIDTH, 0, 0);

        if (firstSegment)
        {
            validSegments.Add("FlatSegment");
            validSegments.Add("FlatSegmentOutdoor1");
            validSegments.Add("FlatToUndergroundSegment");
            validSegments.Add("FlatTowerSegment");
            validSegments.Add("UndergroundtoFlatSegement");
            validSegments.Add("RightUpvertical");
            validSegments.Add("UndergroundtoFlatSegement1");
            offset = spawnPoint;
        }
        else
        {
            switch (lastBaseObject.tag)
            {
                case "FlatSegment":
                    validSegments.Add("FlatSegmentOutdoor1");
                    break;
                case "FlatSegmentOutdoor1":
                    validSegments.Add("OutdoorObstacles");
                    validSegments.Add("FlatSegment");
                    break;
                case "OutdoorObstacles":
                    validSegments.Add("FlatToUndergroundSegment");
                    break;
                case "FlatToUndergroundSegment":
                    validSegments.Add("UndergroundtoFlatSegement");
                    break;
                case "UndergroundtoFlatSegement":
                    validSegments.Add("FlatSegmentOutdoor1");
                    break;

                   
            }
            offset += lastBaseObject.transform.position;

            int randomIndex = Random.Range(0, validSegments.Count);

            foreach (GameObject go in basePrefabs)
            {
                if (go.tag == validSegments[randomIndex])
                {
                    lastBaseObject = Instantiate(go, offset, go.transform.rotation);
                    lastBaseObject.transform.parent = gameObject.transform;
                    break;
                }
            }

        }        
    }
