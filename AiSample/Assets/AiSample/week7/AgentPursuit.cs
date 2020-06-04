using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class AgentPursuit : MonoBehaviour
{
    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private float _maxSpeed = 0.2f;

    private bool _isPursuit = false;
    private bool _isEvade = false;

    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            /*_isPursuit = true;*/
            _isEvade = true;
        }

        if (_isPursuit)
        {
            // pursuit
            // 3: 적당히 빠르게 해주기 위함.
            _velocity = _velocity + pursuit(_target);

            // 속도를 기반으로 새로운 위치 계산.
            transform.position = transform.position + _velocity;
        }

        if (_isEvade)
        {
            _velocity = _velocity + evade(_target);

            transform.position = transform.position + _velocity;
        }
    }

    private Vector3 pursuit(Transform target_agent)
    {
        return seek(target_agent.position);
    }

    private Vector3 seek(Vector3 target_pos)
    {
        // 방향 변경을 위함.
        Vector3 dir = (target_pos - transform.position).normalized;
        if (dir.sqrMagnitude > 0.0f)
        {
            transform.forward = dir;
        }

        Vector3 desired_velocity = dir * _maxSpeed;

        return (desired_velocity - _velocity);
    }

    private Vector3 evade(Transform target_agent)
    {
        return flee(target_agent.position);
    }

    private Vector3 flee(Vector3 target_pos)
    {
        Vector3 dir = (target_pos - transform.position).normalized;
        if (dir.sqrMagnitude > 0.0f)
        {
            transform.forward = -dir;
        }
        // seek의 반대 방향 사용.
        Vector3 desired_velocity = ((transform.position - target_pos).normalized) * _maxSpeed;

        return (desired_velocity - _velocity);
    }
}