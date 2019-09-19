using UnityEngine;
using Pathfinding.Serialization.JsonFx;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using System;

public class graph : MonoBehaviour
{
    public GameObject point;
    string _WebsiteURL = "https://api.jsonbin.io/b/5d7ef77a123f825262cb3f54";


    void Start()
    {
        WWW myWww = new WWW(_WebsiteURL);
        while (myWww.isDone == false) ;
        string jsonResponse = myWww.text;

        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }
        DataItemProto[] dataItems = JsonReader.Deserialize<DataItemProto[]>(jsonResponse);
        for (int i = 1; i < 10; i++)
        {
            var newPoint = (GameObject)Instantiate(point, new Vector3((float)i / 10, (float)i / 10), Quaternion.identity);
            newPoint.GetComponent<Renderer>().material.color = new Color(0, (float)((double)(i * 25.5) / 255), (float)((double)(i * 25.5) / 255), 1);
        }
    }

}
