﻿using System;
using UnityEngine;

namespace DefaultNamespace.Waypoints
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Vector3[] points;

        public Vector3 CurrentPosition => _currentPosition;
        public Vector3[] Points => points;

        private Vector3 _currentPosition;
        private bool _gameStarted;

        private void Start()
        {
            _gameStarted = true;
            _currentPosition = transform.position;
        }

        public Vector3 GetWaypointPosition(int index)
        {
            return CurrentPosition + points[index];
        }

        public void OnDrawGizmos()
        {
            if (!_gameStarted && transform.hasChanged)
            {
                _currentPosition = transform.position;
            }

            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(points[i] + _currentPosition,0.5f);

                if (i < points.Length - 1)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(points[i] +_currentPosition , points[i+1] + _currentPosition);
                }
            }
        }
    }
}