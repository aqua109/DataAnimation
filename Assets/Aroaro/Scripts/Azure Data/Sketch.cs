using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using System.Collections;
using UnityEngine.Networking;
using TMPro;

public class Sketch : MonoBehaviour
{
    public GameObject myPrefab;
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

        foreach (DataItemProto dataItem in dataItems)
            {
            Debug.Log(dataItem.x);
            var newCube = (GameObject)Instantiate(myPrefab, new Vector3(dataItem.x / 10, dataItem.y / 10, dataItem.z / 10), Quaternion.identity);
            newCube.transform.Find("Canvas/company").GetComponentInChildren<TextMeshProUGUI>().SetText(dataItem.company);
        }
    }

}
