using System;
using DefaultNamespace.Waypoints;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public static UnityAction<Enemy> OnEndReached;

        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private Vector3 CurrentPointPos;
        [SerializeField] private Vector3 _lastPointPosition;
        [SerializeField] private float _speed;
        private int _currentWaypointIndex = 0;
        public EnemyHealth _enemyHealth;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        private void OnEnable()
        {
            Reset();
            //_lastPointPosition = _waypoint.GetWaypointPosition(0);
        }

        private void Update()
        {
            //Debug.Log(GetComponent<Rigidbody>().IsSleeping());
            Move();
            Rotate();
            if (CurrentPointPositionReached())
            {
                UpdateCurrentPointIndex();
            }
        }

        private bool CurrentPointPositionReached()
        {
            float distanceToNextPos = (transform.position - CurrentPointPos).magnitude;
            if (distanceToNextPos < 0.1f)
            {
                _lastPointPosition = transform.position;
                return true;
            }

            return false;
        }

        private void UpdateCurrentPointIndex()
        {
            int lastWaypointIndex = _waypoint.Points.Length - 1;
            if (_currentWaypointIndex < lastWaypointIndex)
            {
                _currentWaypointIndex++;
                _lastPointPosition = CurrentPointPos;
                CurrentPointPos = _waypoint.GetWaypointPosition(_currentWaypointIndex);
            }
            else
            {
                ReachEndPoint();
            }
        }

        private void ReachEndPoint()
        {
            OnEndReached?.Invoke(this);
            _enemyHealth.Die();
        }
        
        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentPointPos, _speed * Time.deltaTime);
        }

        private void Rotate()
        {
            if (CurrentPointPos.x > _lastPointPosition.x)
            {
                
            }
        }

        private void Reset()
        {
            CurrentPointPos = _waypoint.GetWaypointPosition(0);
            _currentWaypointIndex = 0;
        }
    }
}