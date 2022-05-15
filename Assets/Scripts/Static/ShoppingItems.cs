using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShoppingItems
{
  public static IDictionary<string, int> items = new Dictionary<string, int>()
  {
    {"plunger", 300},
    {"mug", 100},
    {"banana", 150},
    {"crowbar", 200},
    {"clock", 250},
    {"toothbrush", 270},
    {"toilet paper", 210},
    {"milk", 220},
    {"bread", 150},
    {"duck", 300},
  };

  public static int price = 0;
  public static int timeElapsed = 0;
  public static bool levelFinished = false;

  public static void resetLevel() {
    price = 0;
    timeElapsed = 0;
    levelFinished = false;
  }
}