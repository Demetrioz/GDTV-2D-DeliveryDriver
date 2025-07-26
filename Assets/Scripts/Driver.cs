using UnityEngine;

/// <summary>
/// Allows the game object this script is attached to, to drive
/// </summary>
public class Driver : MonoBehaviour
{
    /// <summary>
    /// The "Name" of the Horizontal control from Project Settings -> Axes
    /// </summary>
    private const string TurnControl = "Horizontal";
    
    /// <summary>
    /// The "Name" of the Vertical control from Project Settings -> Axes
    /// </summary>
    private const string DriveControl = "Vertical";
    
    /// <summary>
    /// The speed at which the vehicle turns
    /// </summary>
    [SerializeField]
    public float turnSpeed = 0.1f;
    
    /// <summary>
    /// The speed at which the vehicle moves
    /// </summary>
    [SerializeField]
    public float driveSpeed = 0.01f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var normalizedTurnAmount = -(Input.GetAxis(TurnControl) * turnSpeed) * Time.deltaTime;
        var normalizedDriveAmount = Input.GetAxis(DriveControl) * driveSpeed * Time.deltaTime;
        
        normalizedTurnAmount = normalizedDriveAmount >= 0
            ? normalizedTurnAmount 
            : -normalizedTurnAmount;
        
        transform.Rotate(0, 0, normalizedTurnAmount);
        transform.Translate(0, normalizedDriveAmount, 0);
    }
}
