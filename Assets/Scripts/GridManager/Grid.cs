using System;
using UnityEngine;

namespace GridManager
{
    public class Grid : MonoBehaviour
    {
        public Vector2 _position;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Color _baseColor, _offsetColor, _highlightColor;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        public void SetCoordinate(int x, int y)
        {
            _position.x = x;
            _position.y = y;
        }

        public void Init(bool isOffset)
        {
            _renderer.material.color = isOffset ? _offsetColor : _baseColor;
        }
    }
}