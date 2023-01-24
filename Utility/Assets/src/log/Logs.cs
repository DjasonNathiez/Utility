using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Logs : MonoBehaviour
{
    [Conditional("DEBUG")]
    public static void Log(string text)
    {
        Debug.Log(text);
    }

    [Conditional("DEBUG")]
    public static void LogError(string text)
    {
        Debug.LogError(text);
    }
}
