using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensetivity = 25f;
    [SerializeField] private Transform _player;

    private float _xRotation;

   private void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if (Input.touchCount > 0  && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }

            mouseX = Input.GetTouch(0).deltaPosition.x * _mouseSensetivity;
            mouseY = Input.GetTouch(0).deltaPosition.y * _mouseSensetivity;
        }

        _xRotation -= mouseY * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _player.Rotate(Vector3.up * mouseX * Time.deltaTime); 
    }
}
