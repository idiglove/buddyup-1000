using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingItem : MonoBehaviour
{
    TextMeshPro totalPrice;
    [SerializeField] private float movementSpeed = 20f;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = transform.parent.parent.Find("Total Price").GetComponent<TextMeshPro>();
        StartCoroutine(WaitUntilLevelFinished());
    }

    IEnumerator WaitUntilLevelFinished()
    {
        while (!ShoppingItems.levelFinished) {
            yield return new WaitForSeconds(1f);
            ShoppingItems.timeElapsed++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collider " + other.name);
        if (other.gameObject.name == "Scanner Collider") {
            ShoppingCart.isScanned = true;
            var itemPrice = ShoppingItems.items[transform.name];
            if (itemPrice.GetType() == typeof(int)) {
                ShoppingItems.price += itemPrice;    
                if (ShoppingItems.price >= 1000) {
                    ShoppingItems.levelFinished = true;
                }
                Transform bagPos = transform.parent.parent.Find("Shopping Bag");
                StartCoroutine(MoveObjectOverTime(transform, bagPos.position, movementSpeed));
            }
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
        totalPrice.text = "$" + ShoppingItems.price.ToString();

        if (ShoppingItems.price >= 1000) {
            transform.parent.parent.Find("Final Score").gameObject.SetActive(true);
            transform.parent.parent.Find("Final Score").GetComponent<TextMeshPro>().text = "You did it in " + ShoppingItems.timeElapsed.ToString() + "s";
            Time.timeScale = 0;
        } 
        isMoving = false;
    }
}
