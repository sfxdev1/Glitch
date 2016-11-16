using UnityEngine;
using System.Collections;

public class MouseLookScript : MonoBehaviour {
    public float lookSensitivty = 5f;
	float yRot;
	float xRot;
	public float currentYRot;
    public float currentXRot;
	float yRotVel;
	float xRotVel;
    public float lookSmoothDamp = 0.5f;
    public bool inverted;
    //public GameObject parent;

	// Use this for initialization
	void Start () {
        //parent = GetComponentInParent<Transform>();
        SetCursorState();
	}
	
	// Update is called once per frame
	void Update () {
        yRot += Input.GetAxis("Mouse X") * lookSensitivty;
        xRot -= Input.GetAxis("Mouse Y") * lookSensitivty;

        currentXRot = Mathf.SmoothDamp(currentXRot, xRot,  ref xRotVel, lookSmoothDamp);
        currentYRot = Mathf.SmoothDamp(currentYRot, yRot, ref yRotVel, lookSmoothDamp);

        currentXRot = Mathf.Clamp(currentXRot, -90, 90);

	    //parent.rotation = Quaternion.Euler(0,currentYRot,0f);
	    transform.rotation = Quaternion.Euler(currentXRot,currentYRot,0);
	}

    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Hide cursor when locking
        Cursor.visible = false;
    }

}
