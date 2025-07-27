using UnityEngine;

// ReSharper disable Unity.UnknownTag

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
    public float turnSpeed = 255f;
    
    /// <summary>
    /// The speed at which the vehicle moves
    /// </summary>
    [SerializeField]
    public float driveSpeed = 15f;

    /// <summary>
    /// The speed at which the vehicle drives after running into an obstacle
    /// </summary>
    [SerializeField]
    public float slowSpeed = 10f;
    
    /// <summary>
    /// The speed at which the vehicle drives after running into a boost
    /// </summary>
    [SerializeField]
    public float boostSpeed = 30f;
    
    private const string BoostTag = "Boost";

    private void OnCollisionEnter2D(Collision2D other)
    {
        driveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(BoostTag))
            driveSpeed = boostSpeed;
    }

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
