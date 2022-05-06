using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;

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
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            // set object's position based on mouse position
            selectedObject.transform.position = mousePosition + offset;

            // while selecting object
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            // on release, unselect the object
            selectedObject = null;
        }
    }
}
