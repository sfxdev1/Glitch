using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float Speed = 1;
    public float JumpSpeed = 8.0F;
    float _gravity;
    public GameObject Cam;
    public float VerticalMomentum;
    readonly CharacterController _controller;

    public MovementScript()
    {
        _gravity = 9;
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {

    }

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x,Cam.transform.rotation.y,transform.rotation.z,Cam.transform.rotation.w);
        CharacterController controller = GetComponent<CharacterController>();
        if (Input.GetKey(KeyCode.W))
        {
            controller.SimpleMove(transform.forward * Speed);

        }
        VerticalMomentum = Input.GetAxis("Jump");

    }

    void Gravity()
    {
        if (!_controller.isGrounded)
        {
            VerticalMomentum -= _gravity * Time.deltaTime;
        }
    }

    void UpdateTransform()
    {
        transform.position *= VerticalMomentum * Time.deltaTime;
    }
} 
