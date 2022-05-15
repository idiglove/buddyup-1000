using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoppingCart : MonoBehaviour
{
    public GameObject selectedObject;
    public static bool isScanned = false;
    Vector3 offset;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !isScanned)
        {
            // on mouse click, set the selected object and get offset
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.transform.parent.name == "Shopping Items")
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject && !isScanned)
        {
            // set object's position based on mouse position
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            // on release, unselect the object
            selectedObject = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.name == "Final Score")
            {
                Time.timeScale = 1;
                ShoppingItems.resetLevel();
                SceneManager.LoadScene("Shopping");
            }
        }
    }
}
