using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostContoller : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick _fixedJoystick;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _fixedJoystick = FindObjectOfType<FixedJoystick>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        float xVal = _fixedJoystick.Horizontal;
        float yVal = _fixedJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);
        _rigidbody.velocity = movement * speed;

        if (xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg,
                transform.eulerAngles.z);
        }
    }
}
