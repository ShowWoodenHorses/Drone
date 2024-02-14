
using UnityEngine;

public class CameraFollowDrone : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [Header("Rotate offset")]
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    [Header("Move offset")]
    //public float moveX;
    //public float moveY;
    //public float moveZ;

    public Vector3 offsetMove;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = _target.position + offsetMove;
    }
}
