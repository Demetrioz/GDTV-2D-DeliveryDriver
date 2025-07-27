using UnityEngine;

/// <summary>
/// Used to follow a particular game object
/// </summary>
public class FollowCamera : MonoBehaviour
{
    /// <summary>
    /// The entity to follow
    /// </summary>
    [SerializeField]
    public GameObject target;

    private Vector3 _offsetPosition = new(0, 0, -10);

    void LateUpdate()
    {
        _offsetPosition.x = target?.transform.position.x ?? transform.position.x;
        _offsetPosition.y = target?.transform.position.y ?? transform.position.y;

        transform.position = _offsetPosition;
    }
}
