using UnityEngine;

public class testlog : MonoSingleton<testlog>
{
    public Transform cube;
    
    void Start()
    {
        Logs.Log("WESH", "BONJOUR", LogType.Log, Logs.LogColor.Green, Logs.LogColor.Red);
        
        cube.SetPosX(2);
        cube.SetScale(3);
    }
}
