using BOBCheats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCheatsTest : CheatBase
{
    [Cheat("Custom-Name-test")]
    public static void CheatOneTest()
    {
        Debug.Log("Cheat one test");
    }

    [Cheat("Parametrized cheat test")]
    public static void CheatParametersTest(int intParam, float floatParam, string stringParam)
    {
        Debug.LogFormat("Parameters cheat test: int {0}, float {1}, string {2}", intParam, floatParam, stringParam);
    }


    [Cheat]
    public static void CheatSecondTest()
    {
        Debug.Log("Cheat second test");
    }
}
