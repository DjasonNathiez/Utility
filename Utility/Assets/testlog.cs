using UnityEngine;

public class testlog : MonoSingleton<testlog>
{
    public Transform cube;
    public GameObject prefabToPool;
    
    void Start()
    {
        var pool = new Pool<GameObject>(prefabToPool);
        var obj = pool.GetFromPool();
        pool.AddToPool(obj);
        pool.AddToPool(obj);
        
        Logs.Log("TEST", "HELLO WORLD", LogType.Log, Logs.LogColor.Green, Logs.LogColor.Red);
        
        cube.SetPosX(2);
        cube.SetScale(3);
    }
}
