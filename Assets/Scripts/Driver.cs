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
        var turnAmount = -(Input.GetAxis(TurnControl) * turnSpeed);
        var driveAmount = Input.GetAxis(DriveControl) * driveSpeed;
        
        turnAmount = driveAmount >= 0
            ? turnAmount 
            : -turnAmount;
        
        transform.Rotate(0, 0, turnAmount);
        transform.Translate(0, driveAmount, 0);
    }
}
