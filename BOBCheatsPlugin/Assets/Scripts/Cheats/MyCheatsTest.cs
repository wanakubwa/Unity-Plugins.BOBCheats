using BOBCheats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCheatsTest : CheatBase
{
    [Cheat]
    public static void CheatOneTest()
    {
        Debug.Log("Cheat one test");
    }

    [Cheat]
    public static void CheatSecondTest()
    {
        Debug.Log("Cheat second test");
    }
}
