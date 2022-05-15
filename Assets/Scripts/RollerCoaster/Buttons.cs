using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
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
            
            if (targetObject && targetObject.name == "Back")
            {
                SceneManager.LoadScene("MainMenu");
            }

            if (targetObject && (targetObject.name == "You Lose" || targetObject.name == "You Win"))
            {
                Time.timeScale = 1;
                RollerCoasterManager.reset();
                SceneManager.LoadScene("Roller Coaster");
            }
        }
    }

    // private IEnumerator Reload()
    // {
    //     yield return new WaitForSeconds(3);
    //     SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    //     Resources.UnloadUnusedAssets();
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
}
