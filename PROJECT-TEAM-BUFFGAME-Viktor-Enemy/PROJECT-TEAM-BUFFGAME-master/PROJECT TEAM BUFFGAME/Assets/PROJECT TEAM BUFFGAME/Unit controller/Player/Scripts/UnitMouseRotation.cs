using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UnitMouseRotation : MonoBehaviour
{
    [Space]
    [SerializeField] private float offsetRotation;
    [SerializeField] private float MaxDistansOffset;

    [Space]
    [SerializeField] private float senseti = -0.2f;
    [SerializeField] private float Debag;

    [Space]
    [SerializeField] private Transform target;
    [SerializeField] private Transform rotPoint;

    [Space]
    [SerializeField] private Transform L;
    [SerializeField] private Transform R;  // кастыль

    [Space]
    [SerializeField] private Transform Unit;

    private float _forvat;

    private Transform _Tr;
    private Camera _Cam;

    private Vector3 _MousePosition;

    private void Start()
    {
        _Tr = transform;
        _Cam = Camera.main;
    }

    void Update()
    {
        _MousePosition = _Cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _forvat = (float)(Math.Atan2(_MousePosition.x, _MousePosition.y)) * Mathf.Rad2Deg * -1; //  Mathf.Rad2Deg = 114.591559157f = 360 / пи , (Atan2) дает угл от пи до - пи , -1 потому что экран к игроку на -90 градусов

        _Tr.rotation = Quaternion.Euler(0, 0, _forvat + offsetRotation);


        if ((target.position - rotPoint.position).magnitude > MaxDistansOffset)
        {
            if((rotPoint.position - L.position).magnitude > (rotPoint.position - R.position).magnitude)
            {
                Unit.Rotate(0, 0, senseti);
            }
            else
            {
                Unit.Rotate(0, 0, -senseti);
            }
        }
    }
}
