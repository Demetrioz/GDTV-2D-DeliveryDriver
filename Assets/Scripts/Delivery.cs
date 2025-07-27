using UnityEngine;

// ReSharper disable Unity.UnknownTag

public class Delivery : MonoBehaviour
{
    [SerializeField]
    public float destroyDelay = 0.5f;
    
    private const string PackageTag = "Package";
    private const string CustomerTag = "Customer";

    private bool _hasPackage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PackageTag) && !_hasPackage)
        {
            Debug.Log("Package picked up");
            _hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        
        else if (other.CompareTag(CustomerTag) && _hasPackage)
        {
            _hasPackage = false;
            Debug.Log("Package dropped off");
        }
    }
}
