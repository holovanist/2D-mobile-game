using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    [HideInInspector] public Controls controls;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        controls = new Controls();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
