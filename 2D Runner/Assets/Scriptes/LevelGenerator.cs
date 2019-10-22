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
        spawnPoint = new Vector3(30, 0, 0);
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
            validSegments.Add("TallSegment");
            validSegments.Add("T2S");
            offset = spawnPoint;
        }
        else
        {
            switch (lastBaseObject.tag)
            {
                case "SmallSegment":
                case "T2S":
                    validSegments.Add("SmallSegment");
                    validSegments.Add("S2T");
                    validSegments.Add("SmallPit");
                    break;
                case "TallSegment":
                case "S2T":
                    validSegments.Add("TallSegment");
                    validSegments.Add("T2S");
                    validSegments.Add("TallPit");
                    break;
				case "SmallPit":
					 validSegments.Add("SmallSegment");
				break;
				case "TallPit":
					 validSegments.Add("TallSegment");
				break;
            }
            offset += lastBaseObject.transform.position;
        }

        int randomIndex = Random.Range(0, validSegments.Count);

        foreach (GameObject go in basePrefabs)
        {
            if(go.tag == validSegments[randomIndex])
            {
                lastBaseObject = Instantiate(go, offset, go.transform.rotation);
                lastBaseObject.transform.parent = gameObject.transform;
                break;
            }
        }

    }
}
