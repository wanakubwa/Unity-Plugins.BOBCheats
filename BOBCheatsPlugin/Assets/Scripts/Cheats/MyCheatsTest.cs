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

    [Cheat("Change Weather - Rain")]
    public static void MakeItRain()
    {
        Debug.Log("MakeItRain");
    }

    [Cheat("Coins +")]
    public static void AddConstantCointsCheat(int coins)
    {
        Debug.LogFormat("AddConstantCointsCheat coins: {0}", coins);
    }
}
