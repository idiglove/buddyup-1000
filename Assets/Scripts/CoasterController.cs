using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoasterController : MonoBehaviour
{
    IDictionary<string, float> tracks = new Dictionary<string, float> {
        {"Track 1", 2.26f},
        {"Track 2", -0.1f},
        {"Track 3", -2.45f}
    };

    public GameObject selectedObject;
    string selectedTrack;
    Vector3 offset;

    void Awake() {
        Time.timeScale = 0;
        AudioManager am = FindObjectOfType<AudioManager>();
        if (am && am.isPlaying("MainMenu")) {
            am.Stop("MainMenu");
        }
        if (am && !am.isPlaying("MiniGame1")) {
            am.Play("MiniGame1");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitUntilLevelFinished());
    }

    IEnumerator WaitUntilLevelFinished()
    {
        while (!RollerCoasterManager.levelFinished) {
            yield return new WaitForSeconds(1f);
            RollerCoasterManager.timeElapsed++;
        }
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

            if (targetObject && targetObject.name == "Tutorial") {
                GameObject.Find("Tutorial").SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (selectedObject)
        {
            // set object's position based on mouse position
            Vector3 coaster = GameObject.Find("Coaster").transform.position;
            GameObject.Find("Coaster").transform.position = new Vector3(coaster.x, tracks[selectedTrack]);
        }
    }
}
