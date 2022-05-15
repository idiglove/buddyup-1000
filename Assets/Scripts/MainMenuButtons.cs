using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Roller Coaster").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Roller Coaster"));
        transform.Find("Shopping Game").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Shopping"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
