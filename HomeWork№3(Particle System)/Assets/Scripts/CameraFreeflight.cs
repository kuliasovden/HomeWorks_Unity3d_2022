using UnityEngine;
using System.Collections;

public class CameraFreeflight : MonoBehaviour 
{
    [SerializeField]private float _speedNormal = 10.0f;
    [SerializeField]private float _speedFast   = 50.0f;

    [SerializeField]private float _mouseSensitivityX = 5.0f;
	[SerializeField]private float _mouseSensitivityY = 5.0f;
    
	private float rotY = 0.0f;
    

	private void Update()
	{
        float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        // rotation        
        if (Input.GetMouseButton(1)) 
        {
            float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _mouseSensitivityX;
            rotY += Input.GetAxis("Mouse Y") * _mouseSensitivityY;
            rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0.0f);
        }
        

        
        // move forwards/backwards
        if (forward != 0.0f)  
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? _speedFast : _speedNormal;
            Vector3 trans = new Vector3(0.0f, 0.0f, forward * speed * Time.deltaTime);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }

        // strafe left/right
        if (strafe != 0.0f) 
        {
            float speed = Input.GetKey(KeyCode.LeftShift) ? _speedFast : _speedNormal;
            Vector3 trans = new Vector3(strafe * speed * Time.deltaTime, 0.0f, 0.0f);
            gameObject.transform.localPosition += gameObject.transform.localRotation * trans;
        }
	}
}
