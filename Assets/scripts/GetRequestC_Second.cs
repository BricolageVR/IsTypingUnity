using UnityEngine;
using System.Collections;
using System;
using ArabicSupport;
using SimpleJSON;

public class GetRequestC_Second : MonoBehaviour {
   

    [SerializeField]
    private bool RL;
    private IEnumerator GetData(string op, Action<string> callback)
    {
        //string url = "http://localhost:8888/" + op;
        string url = "http://192.168.173.1:8888/" + op.ToString();

        WWW www = new WWW(url);
        yield return www;
        // and check for errors
        if (String.IsNullOrEmpty(www.error))
        {
            string dataText = www.text;
            yield return dataText;
            if (callback != null)
                callback(dataText);
        }
        else
        {
            // something wrong!
            Debug.LogError("WWW Error: " + www.error);
            yield return "ERROR";
        }
    }
    [SerializeField]
    private Transform dreamMessagesParent;
  

    // Use this for initialization
    void Start () {
        StartCoroutine(GetData(Handler.get_dreams_or_old_messages.ToString(), Image5));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Image5(string dataText)
    {
        //assign data to the mesages
        var data = JSON.Parse(dataText);
		Debug.Log ("data" + data);
        for (int i = 0; i < dreamMessagesParent.childCount; i++)
        {
            if(i < data.Count)
            {
                if (RL)
                {
                    dreamMessagesParent.GetChild(i).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[i]["contactName"].Value + "\n" + data[i]["text"].Value, false, false); 
                }
                else
                {
                    dreamMessagesParent.GetChild(i).GetComponent<TextMesh>().text = data[i]["contactName"].Value + "\n" + data[i]["text"].Value;
                }
            }
            else
            {
                dreamMessagesParent.GetChild(i).GetComponent<TextMesh>().text =""; 

            }
        }
    }

    //private void Image6(string dataText)
    //{
    //    var data = JSON.Parse(dataText);
    //    for(int i =0;i<groups.Length;i++)
    //    {
    //        //assign the name of the specific group

    //        //assign the you text value

    //        //assign the contacts and set to disabled 
    //        //for(...)

    //        //take care of positioning ans scales

    //    }
    //}
}
