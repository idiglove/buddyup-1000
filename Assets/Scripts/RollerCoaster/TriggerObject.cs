using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriggerObject : MonoBehaviour
{
  bool isTriggered = false;
  TextMeshPro totalScore;
  void Start()
  {
    totalScore = GameObject.Find("Total Score").GetComponent<TextMeshPro>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!isTriggered && other.name == "Coaster")
    {
      Debug.Log(other.name + " current: " + this.name);
      isTriggered = true;

      if (this.name == "Coin(Clone)")
      {
        RollerCoasterManager.totalScore += Random.Range(50, 250);
        totalScore.text = RollerCoasterManager.totalScore.ToString();

        if (RollerCoasterManager.totalScore >= 1000)
        {
          RollerCoasterManager.levelFinished = true;
          triggerEndGame("You Win");
        }
      }
      else
      {
        triggerEndGame("You Lose");
      }

    }
  }

  void triggerEndGame(string gameObject)
  {
    if (gameObject == "You Win") {
      GameObject.Find("Main").transform.Find(gameObject).GetComponent<TextMeshPro>().text = "You win in " + RollerCoasterManager.timeElapsed + "s";
    }
    GameObject.Find("Main").transform.Find(gameObject).gameObject.SetActive(true);
    Time.timeScale = 0;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    isTriggered = false;
  }
}
