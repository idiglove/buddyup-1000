using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingItem : MonoBehaviour
{
    TextMeshPro totalPrice;

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = transform.parent.Find("Total Price").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other) {
        string collider = other.collider.name;

        if (collider == "Cart Bottom") {
            totalPrice.text = "$300";
        }
    }
}
