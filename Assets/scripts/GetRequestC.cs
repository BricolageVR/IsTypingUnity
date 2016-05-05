using UnityEngine;
using System.Collections;
using SimpleJSON;
using ArabicSupport;
using System;

public class CourotineWithData
{
    public Coroutine coroutine { get; private set; }
    public object result;
    private IEnumerator target;

    public CourotineWithData(MonoBehaviour owner,IEnumerator target)
    {
        this.target = target;
        this.coroutine = owner.StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while(target.MoveNext())
        {
            result = target.Current;
            yield return result;
        }
    }
}
public class GetRequestC : MonoBehaviour {
    public enum Handler { get_latest_chats, get_closest_persons_and_msgs, have_hebrew, get_good_night_messages, get_dreams_or_old_messages, get_most_active_groups_and_user_groups, get_chat_archive }
    [SerializeField]
    private Handler handler;

    [SerializeField]
    private bool RL;

    void Start()
    {
        Debug.Log("generating get request");
        GenerateRequest(Handler.get_latest_chats,Image1);
        //GenerateRequest(Handler.get_latest_chats, Image2);
    }

    private IEnumerator GetData(Handler op,Action<string> callback)
    {
        string url = "http://localHost:8888/" + handler.ToString();
        WWW www = new WWW(url);
        yield return www;
        // and check for errors
        if (String.IsNullOrEmpty(www.error))
        {
            string dataText = www.text;
            //var data = JSON.Parse(dataText);
            ////Debugging purposes

            //for (int i = 0; i < data.Count; i++)
            //{
            //    print("from: " + data[i]["name"].Value + "\ncontents: " + ArabicFixer.Fix(data[i]["text"].Value, false, false));
            //}

            yield return dataText;
            if(callback != null)
                callback(dataText);
        }
        else
        {
            // something wrong!
            Debug.LogError("WWW Error: " + www.error);
            yield return "ERROR";
        }
    }

   public string GenerateRequest(Handler op,Action<string> callback)
    {
        Debug.Log("generating get request");
        //CourotineWithData cd = new CourotineWithData(this, GetData(op));
        ////yield return cd.coroutine;
        //string data = ""+cd.result;
        var data = StartCoroutine(GetData(op,callback));
        print(data);
        return "";
    }
    [SerializeField]
    private Material androidMaterial;
    [SerializeField]
    private Material iphoneMaterial;
    [SerializeField]
    private Transform TagHeaderFirstScreen;
    [SerializeField]
    private Transform[] opScreenObj;
    [SerializeField]
    private Transform[] FriendsNames;
    [SerializeField]
    private Transform[] AllContacts;
    public void GetLanguageNPlatform(string dataText)
    {
        var data = JSON.Parse(dataText);
        if(data[0]["platform"].Value == "ios")
        {
            TagHeaderFirstScreen.GetComponent<Renderer>().material = iphoneMaterial;
        }
        else 
        {
            TagHeaderFirstScreen.GetComponent<Renderer>().material = androidMaterial;
        }
    }
    public void Image1(string dataText)
    {
        var data = JSON.Parse(dataText);
        for (int index = 0; index < opScreenObj.Length; index++)
        {//Set the opening screen objects texts
            if (RL)
            {
                opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index]["contactName"].Value, false, false); //2nd child is the contact name
                                                                                                                                         //opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index][""].Value); //3rd child is the contact  logo
                opScreenObj[index].GetChild(3).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index]["text"].Value, false, false); //4th child is the contact name
                opScreenObj[index].GetChild(4).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index]["time"].Value, false, false); //2nd child is the contact name

            }
            else
            {
                opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = data[index]["contactName"].Value; //2nd child is the contact name
                                                                                                          //opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = data[index][""].Value ;is the contact  logo
                opScreenObj[index].GetChild(3).GetComponent<TextMesh>().text = data[index]["text"].Value; //4th child is the contact name
                opScreenObj[index].GetChild(4).GetComponent<TextMesh>().text = data[index]["time"].Value; //2nd child is the contact name
            }
        }


    }

    //public void Image2()
    //{
    //    var data = JSON.Parse(GenerateRequest(Handler.get_closest_persons_and_msgs));
    //    for (int i = 0; i < FriendsNames.Length - 1; i++)
    //    {//Set the close & far friends 
    //        if (RL)
    //        {
    //            opScreenObj[i].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[i]["name"].Value, false, false); //2nd child is the contact name
    //        }
    //        else
    //        {
    //            opScreenObj[i].GetChild(1).GetComponent<TextMesh>().text = data[i]["name"].Value; //2nd child is the contact name
    //        }
    //    }
    //    //Set the last person to be the 'forgotten one'
    //    if (RL)
    //    {
    //        opScreenObj[FriendsNames.Length - 1].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[data.Count - 1]["name"].Value, false, false); //2nd child is the contact name
    //    }
    //    else
    //    {
    //        opScreenObj[FriendsNames.Length - 1].GetChild(1).GetComponent<TextMesh>().text = data[data.Count - 1]["name"].Value; //2nd child is the contact name
    //    }
    //}
}
