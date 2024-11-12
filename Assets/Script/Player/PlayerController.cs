
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TouchInput playerInputs { get; private set; }
    public TouchInput.PlayerActions playerActions { get; private set; }

    private void Awake()
    {
        playerInputs = new TouchInput();
        playerActions = playerInputs.Player;
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}



