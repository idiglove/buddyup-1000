using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RollerCoasterManager
{
  public static int totalScore = 0;
  public static bool levelFinished = false;
  public static int timeElapsed = 0;

  public static void reset() {
    totalScore = 0;
    levelFinished = false;
    timeElapsed = 0;
  }
}