using UnityEngine;

public class DebugSettings : MonoBehaviour
{
    public static DebugSettings instance;

    [Range(0.1f, 10f)] 
    [SerializeField] float gameSpeed = 1f;

    [SerializeField] bool isAutoplayEnabled;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
