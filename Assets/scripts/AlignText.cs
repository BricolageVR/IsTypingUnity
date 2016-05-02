using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class AlignText : MonoBehaviour {

    public static List<Dictionary<string, string>> Messages;
    public static bool RL; //Indicates the current language is Hebrew or Arabic
    
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

    private Vector3 heightOffsetVector;
    // Use this for initialization
    void Start () {
        heightOffsetVector = Vector3.down * heightOffset;
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
                obj = (Transform)Instantiate(otherMessage, leftPos, yourMessage.rotation);
            }
            leftPos += heightOffsetVector;
            rightPos += heightOffsetVector;
            TextMesh m = obj.GetComponent<TextMesh>();
            m.text = GetMessageContents(Messages[i]);
            if (RL)
            {
                m.alignment = TextAlignment.Right;
            }
            else
            {
                m.alignment = TextAlignment.Left;
            }
        }
    }

    public static bool isYou(string name)
    {
        throw new NotImplementedException();
    }
    public static string GetMessageName(Dictionary<string, string> mess)
    {
        throw new NotImplementedException();
    }
    public static string GetMessageContents(Dictionary<string, string> mess)
    {
        throw new NotImplementedException();
    }
    // Update is called once per frame
    void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(originRight, originRight + Vector3.down * 50);
        Gizmos.DrawLine(originLeft,  originLeft  +  Vector3.down * 50);
    }
}
