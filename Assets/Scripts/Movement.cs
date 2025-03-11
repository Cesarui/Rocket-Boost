using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] InputAction thrust;

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
