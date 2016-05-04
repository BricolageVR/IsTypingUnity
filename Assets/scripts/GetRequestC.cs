using UnityEngine;
using System.Collections;
using SimpleJSON;
using ArabicSupport;

public class GetRequestC : MonoBehaviour {
    public enum Handler { get_latest_chats, get_closest_persons_and_msgs, have_hebrew, get_good_night_messages, get_dreams_or_old_messages, get_most_active_groups_and_user_groups, get_chat_archive }
    [SerializeField]
    private Handler handler;

    private string url;
    private WWW www;

    void Start()
    {
        Debug.Log("generating get request");
        url = "http://localHost:8888/" + handler.ToString();
        StartCoroutine(generateRquest());
    }
    IEnumerator generateRquest()
    {
        www = new WWW(url);
        yield return www;
        // and check for errors
        if (www.error == null)
        {
            // request completed!
        }
        else
        {
            // something wrong!
            Debug.Log("WWW Error: " + www.error);
        }

        string dataText = www.text;
        var data = JSON.Parse(dataText);
        for(int i =0;i<data.Count;i++)
        {
            print("from: " + data[i]["name"].Value +"\ncontents: " + ArabicFixer.Fix(data[i]["text"].Value,false,false) );
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
