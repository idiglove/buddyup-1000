using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour, IPooledObject
{
    // Start is called before the first frame update
    public IEnumerator OnObjectSpawn(Vector3 currentPos, Vector3 targetPos)
    {
        // float currentPos = transform.position.x;
// Debug.Log("11" + currentPos);
        while (currentPos.x < 10f) {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPos, 10f * Time.deltaTime);
            transform.position = newPosition;
            currentPos.x = transform.position.x;
            // Debug.Log(currentPos);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
