using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPositionUI : MonoBehaviour
{
    [Header ("Позиция")]
    public float positionX;
    public float positionY;
    public float positionZ;

    [Header("Вращение")]
    public float rotatioinX;
    public float rotatioinY;
    public float rotatioinZ;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void SwitchPositionCamera()
    {
        _camera.transform.position = new Vector3(positionX, positionY, positionZ);
        _camera.transform.rotation = Quaternion.Euler(rotatioinX, rotatioinY, rotatioinZ);
    }
}
