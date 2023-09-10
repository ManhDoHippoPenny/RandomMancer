using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class DragAndDropAble : MonoBehaviour
    {
        [SerializeField] private InputAction press, screen;

        private Vector3 curScreenPos;

        private Vector2 _dir;
        private float _speed;

        public Vector2 Direction => _dir;
        public float Speed => _speed;

        public Camera _camera;
        private bool isDragging = false;
        private PhysicBaseMovement _movement;
        
        public delegate void OnRelaseAction();

        public OnRelaseAction onRelaseEvent;
        private bool isClickedOn()
        {
            Ray ray = _camera.ScreenPointToRay(curScreenPos);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            return hit.transform == transform;
        }

        private Vector3 WorldPos
        {
            get
            {
                float z = _camera.WorldToScreenPoint(transform.position).z;
                return _camera.ScreenToWorldPoint(curScreenPos + new Vector3(0,0,z));
            }
        }
        
        private void Awake()
        {
            _camera = Camera.main;
            press.Enable();
            screen.Enable();
            _movement = GetComponent<PhysicBaseMovement>();
            screen.performed += context =>
            {
                curScreenPos = context.ReadValue<Vector2>();
            };
            press.performed += _ =>
            {
                if(isClickedOn()) StartCoroutine(Drag());
            };
            press.canceled += _ =>
            {
                if (isDragging)
                {
                    isDragging = false;
                    onRelaseEvent?.Invoke();
                    //_movement.ApplyForce(_dir,_speed);
                }
            };
        }

        private IEnumerator Drag()
        {
            isDragging = true;
            
            //drag
            Vector3 offset = transform.position - WorldPos;
            //GetComponent<Rigidbody>().useGravity = false;
            while (isDragging)
            {
                Vector3 tempPos = WorldPos + offset;
                // if (tempPos.x < 0 || tempPos.y < 0 || tempPos.x > _camera.rect.width || tempPos.y > _camera.rect.height)
                // {
                //     isDragging = false;
                //     _movement.ApplyForce(_dir,_speed);
                //     StopCoroutine(Drag());
                // }
                _dir = - transform.position + tempPos;
                _speed = Mathf.Max(Vector2.Distance(transform.position, tempPos),15f);
                transform.position = tempPos;
                yield return null;
            }
            
            //drop
            //GetComponent<Rigidbody>().useGravity = true;
        }
    }
}