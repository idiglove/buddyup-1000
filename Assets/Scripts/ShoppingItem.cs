using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingItem : MonoBehaviour
{
    TextMeshPro totalPrice;
    [SerializeField] private float movementSpeed = 20f;
    bool isMoving = false;
    static int price = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = transform.parent.parent.Find("Total Price").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Scanner Collider") {
            ShoppingCart.isScanned = true;
            price += int.Parse(transform.name);
            Transform bagPos = transform.parent.parent.Find("Shopping Bag");
            StartCoroutine(MoveObjectOverTime(transform, bagPos.position, movementSpeed));
        }
    }

    IEnumerator MoveObjectOverTime(Transform moveMe, Vector3 target, float speed) {
        if (isMoving) yield break;
        isMoving = true;
        ShoppingCart.isScanned = false;
        Debug.Log($"Starting to move {moveMe.name} from {moveMe.transform.position} to {target}.");
        while (moveMe.transform.position != target) {
            Vector3 currentPosition = moveMe.transform.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, target, speed * Time.deltaTime);
            moveMe.transform.position = newPosition;
            yield return null;
        }
        
        Debug.Log($"Done moving {moveMe.name}!");
        totalPrice.text = "$" + price.ToString();
        isMoving = false;
    }
}
