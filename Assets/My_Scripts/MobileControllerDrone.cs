
using UnityEngine;

public class MobileControllerDrone : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bl_Joystick _joystick;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedVecrtical;


    public DroneMovement droneMovement;

    private void Start()
    {
        droneMovement = GetComponent<DroneMovement>();
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MovingDroneMobile();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            RotateDroneLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            RotateDroneRight();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            MoveUpDrone();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            MoveDownDrone();
        }
    }

    private void MovingDroneMobile()
    {
        float v = _joystick.Vertical;
        float h = _joystick.Horizontal;
        Vector3 move = (new Vector3(h, 0, v));
        _rb.velocity = move * Time.deltaTime *_speedMove;
    }
    private void MovingDroneDesctop()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        Vector3 move = (new Vector3(x, 0, z));
        _rb.velocity = move * Time.deltaTime * _speedMove;
    }

    public void RotateDroneLeft()
    {
        transform.Rotate(0, transform.localPosition.y * -_speedRotate * Time.deltaTime, 0);
    }

    public void RotateDroneRight()
    {
        transform.Rotate(0, transform.position.y * _speedRotate * Time.deltaTime,0);
    }

    public void MoveUpDrone()
    {
        Vector3 moveUp = (new Vector3(0f, _speedVecrtical * Time.deltaTime, 0f));
        transform.Translate(moveUp);
    }

    public void MoveDownDrone()
    {
        Vector3 moveDown = (new Vector3(0f, -_speedVecrtical * Time.deltaTime, 0f));
        transform.Translate(moveDown);
    }
}
