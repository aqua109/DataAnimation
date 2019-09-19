using UnityEngine;
using Pathfinding.Serialization.JsonFx;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using System;

public class DisplayData : MonoBehaviour
{
    public GameObject data;
    string _WebsiteURL = "https://api.jsonbin.io/b/5d82f81e5449fa35eaa1bc07";


    void Start()
    {
        WWW myWww = new WWW(_WebsiteURL);
        while (myWww.isDone == false) ;
        string jsonResponse = myWww.text;

        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }
        DataPoint[] dataItems = JsonReader.Deserialize<DataPoint[]>(jsonResponse);
        for (int i = 0; i < 25; i++)
        {
            var newPoint = (GameObject)Instantiate(data, new Vector3(i, i, 0), Quaternion.identity);
            //newPoint.GetComponent<Renderer>().material.color = new Color(0, (float)((double)(i * 25.5) / 255), (float)((double)(i * 25.5) / 255), 1);
            Debug.Log(dataItems[i]);
            setText(newPoint, dataItems[i]);
        }
    }

    public void setText(GameObject newPoint, DataPoint dataItem)
    {
        newPoint.transform.Find("Data/Expanded/MiddleCanvas/Iteration").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.iteration);
        newPoint.transform.Find("Data/Expanded/LeftCanvas/StartDate").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.startDate);
        newPoint.transform.Find("Data/Expanded/LeftCanvas/EndDate").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.endDate);
        newPoint.transform.Find("Data/Expanded/RightCanvas/Budget").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.budget.ToString());
        newPoint.transform.Find("Data/Expanded/RightCanvas/Phase").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.phase.ToString());
    }

}
