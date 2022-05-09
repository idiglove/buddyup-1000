using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{ 
    // public Vector3 gameObjectSreenPoint;
    // public Vector3 mousePreviousLocation;
    // public Vector3 mouseCurLocation;
    public Rigidbody2D rb;
    // bool isMoving = false;

    private void Start() {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        // rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(Vector3.up * 1000f, ForceMode2D.Impulse);
        // StartCoroutine(MoveObjectOverTime(transform.parent, new Vector3(2f,2f), 10f ));
        
    }

}
