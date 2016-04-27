using UnityEngine;
using System.Collections;

public class Image2Controller : MonoBehaviour {

    [System.Serializable]
    public struct action
    {
        public Transform obj;
        public float delay;
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("Scene 2 started");
        for (int i = 0; i < actions.Length; i++)
        {
            StartCoroutine(startAction(actions[i]));
        }
    }
    public action[] actions;
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator startAction(action act)
    {
        yield return new WaitForSeconds(act.delay);
        act.obj.GetComponent<IEnable>().Enable(null);
    }
}
