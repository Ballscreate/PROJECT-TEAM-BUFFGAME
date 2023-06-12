using UnityEngine;
using UnityEngine.AI;
public class UnitController : MonoBehaviour
{
    [Space]
    public Transform Item;


    [Space]
    [SerializeField] private Transform Nav;
    [SerializeField] private NavMeshAgent NavMesh;


    [Space]
    [SerializeField]
    private float
        // максимальный угл поворота оружия относительно игрока
        maxTurningAngle,
        // скорость вращения юнита при достижении максимального угла
        turningSpeed;


    private Transform _unit;


    [HideInInspector] // поле сереализовано но скрыто в инспекторе
    public float
        // наклон вектора до цели (мышки) или (таргета) от  pi   до   -pi
        radian;


    private float
        // поворот юнита в глобальных координатах в радианах
        _radianUnit,
        // разница поворота юнита и его взгляда
        _offsetRadian;


    [HideInInspector]
    public Vector2
        // направление взгляда юнита
        direction,
        // направление движения юнита
        target;


    private Vector3
        // дублирование нужно для того чтобы, сохранять текущие значение, и проводить расчёт только при его ихменении
        _currentTarget;

    private void Start()
    {
        _unit = transform;
    }

    private void Update()
    {
        navMove();

        angleCalculation();

        unitRotation();

        itemRotation();
    }

    private void navMove()
    {
        if (_currentTarget.x != target.x || _currentTarget.y != target.y)
        {
            _currentTarget = target;
            NavMesh.SetDestination(target);
        }

        if (_unit.position != Nav.position) { _unit.position = Nav.position; }
    }

    private void angleCalculation()
    {
        radian = Mathf.Atan2(direction.x, direction.y) * -1;

        _radianUnit = Mathf.Atan(_unit.rotation.z / _unit.rotation.w) * 2;

        _offsetRadian = radian - _radianUnit;
    }

    private void itemRotation()
    {
        Item.rotation = new Quaternion // x, y, z - ось вращения w - угол в радианах
            (0, 0,
            Mathf.Sin(radian * 0.5f),
            Mathf.Cos(radian * 0.5f));
    }

    private void unitRotation()
    {
        // здесь нужен лишь модуль, он становится не верным при наложении + и + или - и - модуль числа инвертируется и увиличивается (больше pi)
        if (Mathf.Abs(_offsetRadian) > Mathf.PI)
        {
            _offsetRadian = _offsetRadian * -1;
        }
        // ^^^^ это костыль из-за неправильного округления float есть "зазоры", периуды где не правильно работает модуль

        if (_offsetRadian > maxTurningAngle)
        {
            _unit.Rotate(0, 0, turningSpeed);
        }
        else if (_offsetRadian < -maxTurningAngle)
        {
            _unit.Rotate(0, 0, -turningSpeed);
        }
    }
}
