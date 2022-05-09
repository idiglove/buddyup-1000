using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LawnMower : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;
    Vector3 startPos;
    Vector3 startDrag;
    Vector3 endDrag;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.Find("Hook").position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            // on mouse click, set the selected object and get offset
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.name == "Square")
            {
                // Debug.Log("rope: " + targetObject.transform.parent.parent.localScale);
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                startDrag = mousePosition;
            }
        }
        if (selectedObject)
        {
            // set object's position based on mouse position
            // selectedObject.transform.position = mousePosition + offset;
            selectedObject.transform.parent.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            // on release, unselect the object
            selectedObject = null;
            transform.Find("Hook").position = startPos;
            endDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("startDrag: " + startDrag);
            Debug.Log("endDrag: " + endDrag);
            Debug.Log("magnitude: " + (endDrag - startDrag).magnitude);
            float magnitude = (endDrag - startDrag).magnitude;
            float random = Random.Range(10, 20);
            GameObject.Find("RPM").GetComponent<TextMeshPro>().text = (magnitude * random).ToString();
        }
    }

    // void FixedUpdate() {
    //     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // on mouse click, set the selected object and get offset
    //         Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
    //         if (targetObject && targetObject.name == "Square")
    //         {
                
    //             selectedObject = targetObject.transform.gameObject;
    //             Debug.Log("rope: " + selectedObject.transform.parent.right);
    //             offset = selectedObject.transform.position - mousePosition;
    //             // selectedObject.transform.parent.GetComponent<Rigidbody2D>().AddForce(selectedObject.transform.parent.up * 1000f, ForceMode2D.Impulse);
    //         }
    //     }
    //     if (selectedObject)
    //     {
    //         // set object's position based on mouse position
    //         // selectedObject.transform.position = mousePosition + offset;
            
            

    //         Vector3 forceGravity = new Vector3(1f, -1.5f, 0f);
    //         // selectedObject.transform.parent.position = (mousePosition + offset) + (forceGravity * Time.fixedDeltaTime);
    //         selectedObject.transform.parent.GetComponent<Rigidbody2D>().AddForce(transform.right * 100f);
    //     }
    //     if (Input.GetMouseButtonUp(0) && selectedObject)
    //     {
    //         // on release, unselect the object
    //         selectedObject = null;
    //     }
    // }
}
