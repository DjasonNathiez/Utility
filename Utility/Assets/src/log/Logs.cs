using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class Logs
{
    public enum LogColor
    {
        None,
        Red,
        Blue,
        Green,
        Yellow,
        Black
    }

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
            log = $"<color={GetColorByLogColor(logColor)}>{log}</color>";
        }
        
        Debug.unityLogger.Log(logType, $"{title} -- {log}");
    }
    
    [Conditional("DEBUG")]
    public static void Log(string title, string log, LogType logType = LogType.Log, LogColor logColor = LogColor.None)
    {
        title = $"<b>[{title}]</b>";
        
        if (logColor != LogColor.None)
        {
            log = $"<color={GetColorByLogColor(logColor)}>{log}</color>";
        }
        
        Debug.unityLogger.Log(logType, $"{title} -- {log}");
    }

    private static string GetColorByLogColor(LogColor logColor)
    {
        return logColor switch
        {
            LogColor.None => "",
            LogColor.Red => "#D45656",
            LogColor.Blue => "#71A7C2",
            LogColor.Yellow =>"#F1C232",
            LogColor.Green => "#8FCE00",
            LogColor.Black => "#000000",
            _ => throw new ArgumentOutOfRangeException(nameof(logColor), logColor, null)
        };
    }

}
