using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class AlignText : MonoBehaviour {

    public  List<Dictionary<string, string>> Messages;
    public  bool RL; //Indicates the current language is Hebrew or Arabic
    
    [SerializeField]
    private int rowLength;
    [SerializeField]
    private Transform otherMessage;
    [SerializeField]
    private Transform yourMessage;
    [SerializeField]
    private float heightOffset;
    [SerializeField]
    private Vector3 originRight;
    [SerializeField]
    private Vector3 originLeft;
    [SerializeField]
    private float rowHeight;
    [SerializeField]
    private float rowHeightOffset;

    private Vector3 heightOffsetVector;
    // Use this for initialization
    void Start () {
        heightOffsetVector = Vector3.down * heightOffset;
        Messages = new List<Dictionary<string, string>>()
        {
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 2 Message This is a message 1" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","This is a message 3" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Me" },
                {"Message","this is a simple message" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            },
            new Dictionary<string, string>()
            {
                {"Name","Other" },
                {"Message","This is a message 4" }
            }

        };
        GenerateMessagesFlow();
    }

    public void GenerateMessagesFlow()
    {
        Vector3 rightPos = originRight;
        Vector3 leftPos = originLeft;
        for(int i = 0;i<Messages.Count;i++)
        {
            Transform obj;
            if (isYou(GetMessageName(Messages[i])))
            {
                obj = (Transform)Instantiate(yourMessage, rightPos, yourMessage.rotation);
            }
            else
            {
                obj = (Transform)Instantiate(otherMessage, leftPos, otherMessage.rotation);
            }
            
            TextMesh m = obj.GetChild(0).GetComponent<TextMesh>();
            int rowsNum;
            m.text = alignMessage(GetMessageContents(Messages[i]),out rowsNum);
            obj.GetChild(1).localScale = new Vector3(1.75f,1, (rowsNum * rowHeight));
            obj.GetChild(1).position += Vector3.down * (rowsNum-1) * rowHeight* 10 * 0.5f;
            heightOffsetVector = Vector3.down * (rowsNum * 10 * rowHeight * 1f + rowHeightOffset);
            leftPos += heightOffsetVector;
            rightPos += heightOffsetVector;
            obj.parent = transform;
            if (RL)
            {
                m.alignment = TextAlignment.Right;
                m.anchor = TextAnchor.UpperRight;
                Vector3 textPos = obj.GetChild(0).localPosition;
                obj.GetChild(0).localPosition += Vector3.left * 16.5f;
            }
            else
            {
                m.alignment = TextAlignment.Left;
            }
        }
    }

    public bool isYou(string name)
    {
        if (name == "Me")
            return true;
        return false;
    }
    public  string GetMessageName(Dictionary<string, string> mess)
    {
        return mess["Name"];
    }
    public static string GetMessageContents(Dictionary<string, string> mess)
    {
        return mess["Message"];
    }

    public string alignMessage(string text,out int rowsNum)
    {
        string output = "";
        int i = 0;
        rowsNum = 0;
        while(i<text.Length)
        {
            string line = text.Substring(i, text.LastIndexOf(" ",Mathf.Min(i + rowLength,text.Length-1)) - i );
            if (line == "")
                break;
            output += line + "\n";
            i += line.Length;
            rowsNum++;
        }
        return output;
    }
    // Update is called once per frame
    void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(originRight, originRight + Vector3.down * 50);
        Gizmos.DrawLine(originLeft,  originLeft  +  Vector3.down * 50);
    }
}
