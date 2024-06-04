using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Transform camera;
    public Joystick joystickMove;
    public Joystick joystickRotate;
    public Transform player;
    public CharacterController characterController;

    public float speed = 10f;
    private float x;
    private float z;
    private Vector3 _move;

    private float rotateV;
    private float rotateH;
    public float SpeedRotate = 0.2f;
    void Start()
    {
        camera = Camera.main.transform;
    }

    public void Move()
    {
        x = joystickMove.Horizontal + Input.GetAxis("Horizontal");
        z = joystickMove.Vertical + Input.GetAxis("Vertical");
        _move = player.right * x + player.forward * z;
        characterController.Move(_move * speed * Time.deltaTime);
    }

    public void Rotate() 
    {
        rotateH = joystickRotate.Horizontal * SpeedRotate;
        rotateV = joystickRotate.Vertical * SpeedRotate;
        camera.Rotate(rotateV,0,0);
        player.Rotate(0,rotateH, 0);
    }

    private void Update()
    {
        Move();
        Rotate();
    }
}
