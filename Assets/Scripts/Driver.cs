using UnityEngine;

/// <summary>
/// Allows the game object this script is attached to, to drive
/// </summary>
public class Driver : MonoBehaviour
{
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
        transform.Rotate(0, 0, turnSpeed);
        transform.Translate(0, driveSpeed, 0);
    }
}
