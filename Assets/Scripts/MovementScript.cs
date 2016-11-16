using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float Speed = 1;
    public float JumpSpeed = 8.0F;
    public float Gravity;
    public GameObject Cam;
    public float VerticalMomentum;
    readonly CharacterController _controller;

    public MovementScript()
    {
        Gravity = 9;
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
    }

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, Cam.transform.rotation.y, transform.rotation.z,Cam.transform.rotation.w);
        CharacterController controller = GetComponent<CharacterController>();
        if (Input.GetKey(KeyCode.W))
        {
            controller.SimpleMove(transform.forward * Speed);
        }
        VelCalc();
        VerticalMomentum = Input.GetAxis("Jump");
        UpdateTransform();
    }

    void VelCalc()
    {
        if (!_controller.isGrounded)
        {
            VerticalMomentum -= Gravity * Time.deltaTime;
        }
    }

    void UpdateTransform()
    {
        transform.position *= VerticalMomentum * Time.deltaTime;
    }
}