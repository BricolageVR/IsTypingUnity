//using UnityEngine;
//using System.Collections;
//using SimpleJSON;
//using ArabicSupport;
//using System;

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

    public CourotineWithData(MonoBehaviour owner, IEnumerator target)
    {
        this.target = target;
        this.coroutine = owner.StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (target.MoveNext())
        {
            result = target.Current;
            yield return result;
        }
    }
}
public enum Handler { get_latest_chats, get_closest_persons_and_msgs, have_hebrew, get_good_night_messages, get_dreams_or_old_messages, get_most_active_groups_and_user_groups, get_chat_archive }


public class GetRequestC : MonoBehaviour
{
    [SerializeField]
    private Handler handler;

    [SerializeField]
    private bool RL;

    void Start()
    {
        Debug.Log("generating get request");
        GenerateRequest(handler, Debug.Log);
        GenerateRequest(handler, printData);
        GenerateRequest(Handler.get_latest_chats, Image1);
        GenerateRequest(Handler.get_closest_persons_and_msgs, Image2_3);
        GenerateRequest(Handler.get_good_night_messages, Image4);
    }

    private IEnumerator GetData(Handler op, Action<string> callback)
    {
        string url = "http://192.168.173.1:8888/" + op.ToString();
        //string url = "http://localhost:8888/" + op.ToString();
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

    public void GenerateRequest(Handler op, Action<string> callback)
    {
        Debug.Log("generating get request");
        StartCoroutine(GetData(op, callback));
    }
    public IEnumerator setProfilePic(string url,Transform sphere)
    {
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = sphere.GetComponent<Renderer>();
        Texture2D text = new Texture2D(www.texture.width, www.texture.height,TextureFormat.DXT1,true); //TextureFormat must be DXT
        www.LoadImageIntoTexture(text);
        debugText.GetComponent<TextMesh>().text += "size: "+www.bytesDownloaded + "\n";
        renderer.material.mainTexture = text;
       // renderer.material.mainTexture = www.texture;
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
    private Transform[] goodNightContacts;

    [SerializeField]
    private Transform debugText;


    public static JSONNode all_contacts;

    public void GetLanguageNPlatform(string dataText)
    {
        var data = JSON.Parse(dataText);
        if (data[0]["platform"].Value == "ios")
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
        //Debug.Log(dataText);
        var data = JSON.Parse(dataText);
        for (int index = 0; index < opScreenObj.Length; index++)
        {//Set the opening screen objects texts
         StartCoroutine(setProfilePic("http://192.168.173.1:8888/static/tempAvatars/contact_avatar" + index + ".jpg", opScreenObj[index].GetChild(5)));
         //StartCoroutine(setProfilePic("http://locahost:8888/static/tempAvatars/contact_avatar" + index + ".jpg", opScreenObj[index].GetChild(5)));

            if (RL)
            {
                string input = data[index]["contactName"].Value;
                if (input.Length > 20)
                {
                    input = input.Substring(0, 17) + "...";
                }
                opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(input, false, false); //2nd child is the contact name
                input = data[index]["text"].Value;
                if (input.Length > 30)
                {
                    input = input.Substring(0, 27) + "...";
                }                                                                                                                  //opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index][""].Value); //3rd child is the contact  logo
                opScreenObj[index].GetChild(3).GetComponent<TextMesh>().text = ArabicFixer.Fix(input, false, false); //4th child is the contact name
                opScreenObj[index].GetChild(4).GetComponent<TextMesh>().text = ArabicFixer.Fix(data[index]["time"].Value, false, false); //2nd child is the contact name

            }
            else
            {
                string input = data[index]["contactName"].Value;
                if (input.Length > 20)
                {
                    input = input.Substring(0, 17) + "...";
                }
                opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = input; //2nd child is the contact name
                input = data[index]["text"].Value;
                if (input.Length > 30)
                {
                    input = input.Substring(0, 27) + "...";
                }                                                                                     //opScreenObj[index].GetChild(1).GetComponent<TextMesh>().text = data[index][""].Value ;is the contact  logo
                opScreenObj[index].GetChild(3).GetComponent<TextMesh>().text = input; //4th child is the contact name
                opScreenObj[index].GetChild(4).GetComponent<TextMesh>().text = (data[index]["time"].Value); //2nd child is the contact name
            }
        }
    }
    
    public void Image2_3(string dataText)
    {
        all_contacts = JSON.Parse(dataText);
        for (int i = 0; i < FriendsNames.Length - 1; i++)
        {//Set the close & far friends 
            if (RL)
            {
                FriendsNames[i].GetComponent<TextMesh>().text = ArabicFixer.Fix(all_contacts[i]["contactName"].Value, false, false); //2nd child is the contact name
            }
            else
            {
                FriendsNames[i].GetComponent<TextMesh>().text = all_contacts[i]["contactName"].Value; //2nd child is the contact name
            }
        }
        //Set the last person to be the 'forgotten one'
        if (RL)
        {
            FriendsNames[FriendsNames.Length - 1].GetComponent<TextMesh>().text = ArabicFixer.Fix(all_contacts[all_contacts.Count - 1]["contactName"].Value, false, false); //2nd child is the contact name
        }
        else
        {
            FriendsNames[FriendsNames.Length - 1].GetComponent<TextMesh>().text = all_contacts[all_contacts.Count - 1]["contactN"].Value; //2nd child is the contact name
        }
    }

    public void Image4(string dataText)
    {
        var data = JSON.Parse(dataText);
        for(int i = 0;i<goodNightContacts.Length;i++)
        {
            if (RL)
            {
                goodNightContacts[i].GetComponent<TextMesh>().text = ArabicFixer.Fix(data[i]["contactName"].Value + "\n" + data[i]["text"].Value, false, false); //2nd child is the contact name
            }
            else
            {
                goodNightContacts[i].GetComponent<TextMesh>().text = data[i]["contactName"].Value + "\n" + data[i]["text"].Value; //2nd child is the contact name
            }
        }
    }

    public void printData(string dataText)
    {
        var data = JSON.Parse(dataText);
        for(int i =0;i<data.Count;i++)
        {
            Debug.Log("name: " + data[i]["contactName"].Value + "text: " + data[i]["text"].Value);
        }
    }
}

