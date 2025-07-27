using UnityEngine;

// ReSharper disable Unity.UnknownTag

public class Delivery : MonoBehaviour
{
    [SerializeField]
    public Color32 hasPackageColor = new(255, 255, 255, 255);
    
    [SerializeField]
    public Color32 noPackageColor = new(0, 0, 0, 255);
    
    [SerializeField]
    public float destroyDelay = 0.5f;
    
    private SpriteRenderer _spriteRenderer;
    
    private const string PackageTag = "Package";
    private const string CustomerTag = "Customer";

    private bool _hasPackage;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PackageTag) && !_hasPackage)
        {
            if (_spriteRenderer != null)
                _spriteRenderer.color = hasPackageColor;
            
            _hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package picked up");
        }
        
        else if (other.CompareTag(CustomerTag) && _hasPackage)
        {
            if (_spriteRenderer != null)
                _spriteRenderer.color = noPackageColor;
            
            _hasPackage = false;
            Debug.Log("Package dropped off");
        }
    }
}
