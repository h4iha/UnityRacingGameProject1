using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector]
    public int lap = 0;
    [HideInInspector]
    public int checkPoint = -1;
    int checkPoinCount;
    int nextCheckpoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();

    public Text lapText;
    [HideInInspector]
    public bool missed = false;
    public GameObject prevCheckpoint;

    public float timehit;



    void Start()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        checkPoinCount = checkpoints.Length;
        foreach (GameObject checkpoint in checkpoints)
        {
            if(checkpoint.name == "0")
            {
                prevCheckpoint = checkpoint;
                break;
            }

        }
        foreach (GameObject cp in checkpoints)
        {
            visited.Add(Int32.Parse(cp.name), false);

        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "checkpoint")
        {
            int checkpointCurrent = int.Parse(col.gameObject.name);

            if(checkpointCurrent == nextCheckpoint)
            {
                timehit = Time.time;
                prevCheckpoint = col.gameObject;
                visited[checkpointCurrent] = true;
                checkPoint = checkpointCurrent;
                if (checkPoint == 0)
                {
                    lap++;
                }
            }

            nextCheckpoint++;
            if(nextCheckpoint >= checkPoinCount)
            {
                var keys = new List<int>(visited.Keys);
                foreach(int key in keys){
                    visited[key] = false;

                }nextCheckpoint = 0;
            }
            else if(checkpointCurrent != nextCheckpoint && visited[checkpointCurrent] == false)
            {
                missed = true;
            }

        }
    }
}
