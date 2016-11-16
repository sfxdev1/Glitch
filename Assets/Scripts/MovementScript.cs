using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float Speed = 1;
    public float JumpSpeed = 8.0F;
    public float Gravity = 9F;
    public GameObject Cam;
    public float VerticalMomentum;
    readonly CharacterController _controller;

    public MovementScript()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (Input.GetKey(KeyCode.W))
        {
            controller.SimpleMove(transform.forward * Speed);
        }
        VelCalc();
        VerticalMomentum = _controller.isGrounded ? Input.GetAxis("Jump") : 0f;
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