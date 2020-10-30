using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smoothness;

    [SerializeField]
    private Vector3 _offset;

    private void FixedUpdate()
    {
        if (_target == null)
        {
            return;
        }
        
        //Bir noktayı bir yerden bir yere (çizgi şeklinde) taşır.
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smoothness);
    }
}
