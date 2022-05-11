using System.Collections;
using UnityEngine;

public interface IPooledObject
{
    IEnumerator OnObjectSpawn(Vector3 currentPos, Vector3 targetPos);
}
