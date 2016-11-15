using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    public float speed = 1;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject cam;
    void Start()
    {

    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (Input.GetKey(KeyCode.W))
        {
            controller.SimpleMove(transform.forward * speed * Time.deltaTime);
            /*transform.Translate(transform.forward*speed*Time.deltaTime)*/;
        }
    }
} 
