using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] InputAction thrust;

    // Input action enabled, it can also be disabled and called multiple times
    private void OnEnable()
    {
        thrust.Enable();
    }

    private void Update()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("The Thrust is Thrusting!!");
        }
    }
}
