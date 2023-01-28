using UnityEngine;

public class testlog : MonoSingleton<testlog>
{
    public Transform cube;
    public GameObject prefabToPool;

    public TestEnum testEnum;
    public int testInt;
    
    public enum TestEnum
    {
        TESTA,
        TESTB
    }

    void Start()
    {
        Logs.Log("TEST CONVERTER", testEnum.ConvertToInt().ToString(), LogType.Log, Logs.LogColor.None, Logs.LogColor.None);
    }
}
