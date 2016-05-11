using UnityEngine;
using System.Collections;
using ArabicSupport;
public class DrawContacts : MonoBehaviour {

    [SerializeField]
    private int MAX_ROWS;

    [SerializeField]
    private float initRadius;
    [SerializeField]
    private float gizmoRadius;
    [SerializeField]
    private float heightOffset;

    [SerializeField]
    private float radiusOffset;

    [SerializeField]
    private Transform initialPos;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Transform TextObj;
    [SerializeField]
    private int degreesOffset;

    [SerializeField]
    private int degreesInitial = 1;

    [SerializeField]
    private int initialFriendsNumber = 5;
    // Use this for initialization
    void Start () {
        Vector3 pos = initialPos.position;
        float radius = initRadius;
        float height = initialPos.position.y;
        int degrees = degreesInitial;
        for (int i = 0,num = 4; i < MAX_ROWS; i++,num++)
        {

            if (degrees < 10)
            {
                degrees = 10;
            }
            for (int j = 280; j <= 440; j += degrees,num++)
            {
                Vector3 temPos = pos + new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad * j), 0, radius * Mathf.Cos(Mathf.Deg2Rad * j));
                Transform t = (Transform)Instantiate(TextObj, temPos, Quaternion.Euler(0,j,0));
                t.parent = parent;
                if(num < GetRequestC.all_contacts.Count)
                {
                    t.GetComponent<TextMesh>().text = ArabicFixer.Fix(GetRequestC.all_contacts[num]["contactName"].Value, false, false);
                    t.GetComponent<PopMessage>().text = ArabicFixer.Fix(GetRequestC.all_contacts[num]["text"].Value, false, false);
                }
                else
                {
                    t.GetComponent<TextMesh>().text = "";
                }
            }
            degrees -= degreesOffset;
            height += heightOffset;
            radius += radiusOffset;
            pos = new Vector3(initialPos.position.x, height, initialPos.position.z);
        }
    }

    // Update is called once per frame
    void Update () {
	    
	}

    void OnDrawGizmos()
    {
        Vector3 pos = initialPos.position;
        float radius = initRadius;
        float height = initialPos.position.y;
        Gizmos.color = Color.green;
        int degrees = degreesInitial;
        for (int i =0;i<MAX_ROWS;i++)
        {
            if (degrees < 10)
            {
                degrees = 10;
            }
            for (int j = 280; j <= 440; j+=degrees)
            {
                Vector3 temPos = pos + new Vector3(radius * Mathf.Sin(Mathf.Deg2Rad * j), 0, radius * Mathf.Cos(Mathf.Deg2Rad * j));
                Gizmos.DrawSphere(temPos, gizmoRadius);
            }
            degrees -= degreesOffset;
            height += heightOffset;
            radius += radiusOffset;
            pos = new Vector3(initialPos.position.x, height, initialPos.position.z);
        }
    }
}
