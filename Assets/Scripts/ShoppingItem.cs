using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingItem : MonoBehaviour
{
    TextMeshPro totalPrice;
    TextMeshPro hoverPrice;
    GameObject hoverObj;
    [SerializeField] private float movementSpeed = 20f;
    bool isMoving = false;
    int currentPrice = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = transform.parent.parent.Find("Total Price").GetComponent<TextMeshPro>();
        hoverPrice = transform.parent.parent.Find("Hover Price").Find("Text").GetComponent<TextMeshPro>();
        hoverObj = transform.parent.parent.Find("Hover Price").gameObject;
        currentPrice = Random.Range(100, ShoppingItems.items[transform.name]);
    }

    private void OnMouseEnter() {
        hoverObj.SetActive(true);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = transform.position - mousePosition;
        Vector3 newPos = mousePosition + offset;
        hoverObj.transform.position = new Vector3(newPos.x, newPos.y + 2f);
        // hoverObj.transform.position = new Vector3(mousePosition.x, mousePosition.y + 1f);
        Debug.Log(hoverObj.transform.position);
        hoverPrice.text = currentPrice.ToString();
    }

    private void OnMouseExit() {
        hoverObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("collider " + other.name);
        if (other.gameObject.name == "Scanner Collider") {
            ShoppingCart.isScanned = true;
            ShoppingItems.price += currentPrice;
            if (ShoppingItems.price >= 1000) {
                ShoppingItems.levelFinished = true;
            }
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
        totalPrice.text = "$" + ShoppingItems.price.ToString();
        
        if (GameObject.Find("Shopping Bag")) {
            GameObject.Find("Shopping Bag").SetActive(false);
            transform.parent.parent.Find("Filled Up Bag").gameObject.SetActive(true);
        }
        
        if (ShoppingItems.price >= 1000) {
            transform.parent.parent.Find("Final Score").gameObject.SetActive(true);
            transform.parent.parent.Find("Final Score").GetComponent<TextMeshPro>().text = "You did it in " + ShoppingItems.timeElapsed.ToString() + "s";
            Time.timeScale = 0;
        }
        isMoving = false;
        this.gameObject.SetActive(false);
    }
}
