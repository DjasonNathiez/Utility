using UnityEngine;

public class testlog : MonoBehaviour
{
    void Start()
    {
        Logs.Log("WESH", "BONJOUR", LogType.Log, Logs.LogColor.Green, Logs.LogColor.Red);
    }
}
