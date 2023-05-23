using System;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [Space]
    [SerializeField] private float offset;

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
        _forvat = (float)(Math.Atan2(_MousePosition.x, _MousePosition.y)) * Mathf.Rad2Deg *-1; //  Mathf.Rad2Deg = 114.591559157f = 360 / пи , (Atan2) дает угл от пи до - пи , -1 потому что экран к игроку на -90 градусов
        _Tr.rotation = Quaternion.Euler(0, 0, _forvat + offset);
    }
}
