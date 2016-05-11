using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ArabicSupport;
using SimpleJSON;

public class GetRequestC_Second1 : MonoBehaviour {
   

    [SerializeField]
    private bool RL;

    private string nickname;
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
    private Transform [] groups;
    [SerializeField]
    private Transform[] yous;
    public Transform text;
    // Use this for initialization
    void Start () {
        groupsData = new List<groupData>();
        StartCoroutine(GetData(Handler.get_chat_archive.ToString(), Debug.Log));
        StartCoroutine(GetData(Handler.have_hebrew.ToString(), setDetails));
        StartCoroutine(GetData(Handler.get_most_active_groups_and_user_groups.ToString(), Image6));
        StartCoroutine(GetData(Handler.get_chat_archive.ToString(), Archive));
    }

    // Update is called once per frame
    void Update () {
	
	}
    public class groupData
    {

        public List<string> names;
        public string name;

    }
    private List<groupData> groupsData;

    private void setDetails(string dataText)
    {
        var data = JSON.Parse(dataText);
        //nickname = ArabicFixer.Fix(data["user_whatsapp_name"].Value,false,false);
        nickname = "+972 54-698-5090";
        if (data["hebrew"].Value == "true")
        {
            RL = true;
        }
    }
    private void Image6(string dataText)
    {

        var data = JSON.Parse(dataText);
        int youIndex;
        for(int i = 0;i<data.Count;i++)
        {
            groupData g = groupsData.Find(x => x.name.Equals(data[i]["groupName"].Value));
            if(g == null)
            {
                g = new groupData();
                groupsData.Add(g);
                g.name = data[i]["groupName"].Value;
                g.names = new List<string>();
            }
            g.names.Add(data[i]["name"]);
        }
        for (int i = 0; i < groups.Length && i< groupsData.Count; i++)
        {
            groups[i].GetComponent<TextMesh>().text = ArabicFixer.Fix(groupsData[i].name,false, false);
            for(int j = 0;j<groups[i].childCount;j++)
            {
                //assign child values
                if(j < groupsData[i].names.Count)
                {
                    if (groupsData[i].names[j] != nickname)
                        groups[i].GetChild(j).GetComponent<TextMesh>().text = ArabicFixer.Fix(groupsData[i].names[j],false,false);
                    else
                    {
                        yous[i].GetComponent<TextMesh>().text = ArabicFixer.Fix(groupsData[i].names[j], false, false);
                        yous[i].GetComponent<AddYou>().position = j;
                        groupsData[i].names.Remove(nickname);
                        j--;
                    }

                }
                else
                {
                    Destroy(groups[i].GetChild(j).gameObject);
                }
            }

            //assign the you text value
        }
    }

    private void Archive(string dataText)
    {
        var data = JSON.Parse(dataText);
        List<Dictionary<string, string>> Messages = new List<Dictionary<string, string>>();
        for(int i =0;i<data.Count;i++)
        {
            string Name = ArabicFixer.Fix(data[i]["name"].Value,false, false);
            string Message = ArabicFixer.Fix(data[i]["text"].Value, false, false);
            if (Name == nickname)
            {
                Name = "Me";
            }
            Messages.Add(new Dictionary<string, string>()
            {
                {"Name",Name },
                {"Message",Message}
            });
            text.GetComponent<AlignText>().Messages = Messages;
            text.GetComponent<AlignText>().RL = RL;
        }
}
}
