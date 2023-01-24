using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Logs : MonoBehaviour
{
    [Conditional("DEBUG")]
    public static void Log(string title, string log, LogType logType = LogType.Log, LogColor titleColor = LogColor.None, LogColor logColor = LogColor.None)
    {
        title = $"<b>[{title}]</b>";

        if (titleColor != LogColor.None)
        {
            title = $"<color={GetColorByLogColor(titleColor)}>{title}</color>";
        }

        if (logColor != LogColor.None)
        {
            log = $"<color={GetColorByLogColor(titleColor)}>{log}</color>";
        }
        
        Debug.unityLogger.Log(logType, $"{title} -- {log}");
    }

    public static string GetColorByLogColor(LogColor logColor)
    {
        string color = "0,0,0";

        switch (logColor)
        {
            case LogColor.Blue:
                return ":blue";
            
            case LogColor.Green:
                return ":green";
            
            case LogColor.Red:
                return ":red";

            case LogColor.None:
                return ":white";
        }
        
        return ":white";
    }

    public enum LogColor
    {
        None,
        Red,
        Blue,
        Green
    }
}
