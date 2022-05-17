using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CalculatePositions : MonoBehaviour
{
    struct Playerpositions
    {
        public int position;
        public float time;

        public Playerpositions(int p, float t)
        {
            position = p;
            time = t;
        }
    }

    Checkpoints checkpoints;
    static Dictionary<string, Playerpositions> positions = new Dictionary<string, Playerpositions>();

    GameObject player;
    string name;
    
    void Start()
    {
        player = gameObject;
        name = player.name;
        if (positions.ContainsKey(name) == (false)){
            positions.Add(name, new Playerpositions(0, 0));
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoints == null)
            checkpoints = GetComponent<Checkpoints>();
        SetPostions(name, checkpoints.lap, checkpoints.checkPoint, checkpoints.timehit);

        if(name == "BMW")
        {
            string position = GetPositions(name);
            Debug.Log(position);
        }
        if (name == "HatchBack")
        {
            string position = GetPositions(name);
            Debug.Log(position);
        }
        if (name == "Porche")
        {
            string position = GetPositions(name);
            Debug.Log(position);
        }
        if (name == "Sedan")
        {
            string position = GetPositions(name);
            Debug.Log(position);
        }



    }

    public static void SetPostions(string name, int lap, int checkpoint, float time)
    {
        int position = lap + checkpoint;
        positions[name] = new Playerpositions(position, time);
    }

    public static string GetPositions(string name)
    {
        int index = 0;
        foreach(KeyValuePair<string, Playerpositions> pos in positions.OrderByDescending(key => key.Value.position).ThenBy(key=>key.Value.time))
        {
            index++;
            if(pos.Key == name)
            {
                switch (index)
                {
                    case 1: return "1st";
                    case 2: return "2nd";
                    case 3: return "3rd";
                    case 4: return "4th";
                    //case 5: return "5th";
                    //case 6: return "6th";
                    //case 7: return "7th";
                    //case 8: return "8th";
                }
            }
        }
        return "Unknown";
    }

    internal static string SetPostions(string name)
    {
        throw new NotImplementedException();
    }
}
