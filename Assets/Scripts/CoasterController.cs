using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterController : MonoBehaviour
{
    // private List<string> tracks = new List<string>{"Track 1", "Track 2", "Track 3"};
    IDictionary<string, float> tracks = new Dictionary<string, float> {
        {"Track 1", 2.2f},
        {"Track 2", 0.03f},
        {"Track 3", -2.1f}
    };
    //track1 y = 2.2
    //track2 y = 0.03
    //track2 y = -2.1
    public GameObject selectedObject;
    string selectedTrack;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            // on mouse click, set the selected object and get offset
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject) {
                Debug.Log("targetObject: " + targetObject.name);
            }
            
            if (targetObject && tracks.Keys.Contains(targetObject.name))
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                selectedTrack = targetObject.name;
            }
        }
        if (selectedObject)
        {
            // set object's position based on mouse position
            // selectedObject.transform.position = mousePosition + offset;
            // selectedObject.transform.parent.position = mousePosition + offset;
            Vector3 coaster = GameObject.Find("Coaster").transform.position;
            GameObject.Find("Coaster").transform.position = new Vector3(coaster.x, tracks[selectedTrack]);
            
        }
    }
}
