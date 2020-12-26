using BOBCheats;
using UnityEngine;

public class MyCheatsTest : CheatBase
{
    [Cheat]
    public static void PauseGameCheat()
    {
        Debug.Log("PauseGameCheat");
    }

    [Cheat]
    public static void SetTimeMultiplierCheat(float value)
    {
        Debug.LogFormat("SetTimeMultiplierCheat {0}", value);
    }

    [Cheat]
    public static void GodModeCheat()
    {
        Debug.Log("GodModeCheat");
    }

    [Cheat("", "Change Weather - Rain")]
    public static void MakeItRain()
    {
        Debug.Log("MakeItRain");
    }

    [Cheat("", "Coins +")]
    public static void AddConstantCointsCheat(int coins)
    {
        Debug.LogFormat("AddConstantCointsCheat coins: {0}", coins);
    }

    // Category A.
    [Cheat("Category A")]
    public static void CategoryACheat1()
    {
        Debug.Log("A - GodModeCheat");
    }

    [Cheat("Category A")]
    public static void CategoryACheat2()
    {
        Debug.Log("A - MakeItRain");
    }

    [Cheat("Category A")]
    public static void CategoryACheat3(int coins)
    {
        Debug.LogFormat("A - AddConstantCointsCheat coins: {0}", coins);
    }

    // Category B.
    [Cheat("Category B")]
    public static void CategoryBCheat1()
    {
        Debug.Log("B - GodModeCheat");
    }

    [Cheat("Category B")]
    public static void CategoryBCheat2()
    {
        Debug.Log("B - MakeItRain");
    }

    [Cheat("Category B")]
    public static void CategoryBCheat3(int coins)
    {
        Debug.LogFormat("B - AddConstantCointsCheat coins: {0}", coins);
    }

    // Category C.
    [Cheat("Category C")]
    public static void CategoryCCheat1()
    {
        Debug.Log("C - GodModeCheat");
    }

    [Cheat("Category C")]
    public static void CategoryCCheat2()
    {
        Debug.Log("C - MakeItRain");
    }

    [Cheat("Category C")]
    public static void CategoryCCheat3(int coins)
    {
        Debug.LogFormat("C - AddConstantCointsCheat coins: {0}", coins);
    }
}
