using UnityEngine;

public class Inputs : MonoBehaviour
{
    public static Inputs Instance;
    public InputSystem_Actions inputs;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        inputs = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public Vector2 Move => inputs.Player.Move.ReadValue<Vector2>();
    public Vector2 Look => inputs.Player.Look.ReadValue<Vector2>();
    public bool JumpDown => inputs.Player.Jump.WasPressedThisFrame();// Button Down
    public bool JumpHold => inputs.Player.Jump.IsPressed();// Button
    public bool JumpUp => inputs.Player.Jump.WasReleasedThisFrame();// Button Up
    public bool FireDown => inputs.Player.Attack.WasPressedThisFrame();// Button Down
}
