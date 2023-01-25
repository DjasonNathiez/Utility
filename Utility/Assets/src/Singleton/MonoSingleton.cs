using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
{
    public static T instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Logs.Log("Singleton", $"This singleton already exist so {gameObject} have been deleted", LogType.Error, Logs.LogColor.Red, Logs.LogColor.Red);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = GetComponent<T>();
        }
    }
}
