using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2
        _input,
        _mousPosition,
        // вектор движения локально развернутый относительно игрока
        _inputLocal;

    private float _cos, _sin;

    private Camera _camMain;

    private UnitController _controller;

    private Transform _unit;

    void Start()
    {
        _unit = transform;
        _camMain = Camera.main; // находит камеру по тегу
        _controller = GetComponent<UnitController>();
    }

    void Update()
    {
        input();
        control();
    }

    private void input()
    {
        _input.x = -Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");
        _input.Normalize();

        _mousPosition = _camMain.ScreenToWorldPoint(Input.mousePosition) - _unit.position;

        _cos = Mathf.Cos(-_controller.radian);
        _sin = Mathf.Sin(-_controller.radian);

        if (_input.magnitude > 0)
        {
            _inputLocal.x = _input.x * -_cos + _input.y * _sin;
            _inputLocal.y = _input.x * _sin + _input.y * _cos;
        }
    }

    private void control()
    {
        _controller.direction = _mousPosition;

        if (_input.magnitude > 0.01f)
        {
            _controller.target = new Vector2(_unit.position.x, _unit.position.y) + _inputLocal;
        }
    }
}
