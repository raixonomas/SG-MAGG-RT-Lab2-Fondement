using UnityEngine;

public class Manager<T> : MonoBehaviour where T : Manager<T>, new()
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            if (TryGetComponent<T>(out var manager))
            {
                Instance = manager;
                return;
            }
            gameObject.AddComponent<T>();
        }
        else Destroy(Instance);
    }
}