using UnityEngine;

// ReSharper disable Unity.UnknownTag

public class Delivery : MonoBehaviour
{
    private const string PackageTag = "Package";
    private const string CustomerTag = "Customer";

    private bool _hasPackage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PackageTag))
        {
            Debug.Log("Package picked up");
            _hasPackage = true;
        }
        
        else if (other.CompareTag(CustomerTag) && _hasPackage)
        {
            _hasPackage = false;
            Debug.Log("Package dropped off");
        }
    }
}
