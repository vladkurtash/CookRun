
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CookRun.Input
{
    public class SlidingArea : MonoBehaviour, ISlidingArea, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _pointerDelta = Vector2.zero;
        private bool _pointerActive = false;

        /// <summary>
        /// Pointer movement delta value.
        /// </summary>
        /// <value>Returns value multiplied by Time.deltaTime</value>
        public Vector2 PointerDelta { get => _pointerDelta * Time.deltaTime; }

        /// <summary>
        /// Indicates whether the pointer is pressing this object or not.
        /// </summary>
        /// <value>Returns True if the object is pressing by a pointer.</value>
        public bool PointerActive { get => _pointerActive; }
        public event Action PointerDown;
        public event Action PointerUp;

        /// <summary>
        /// Resets "_pointerDelta" value on the end of Monobehaviour cycle.
        /// Should be reseted because "_pointerDelta" variable keeps last dynamic pointer delta value 
        /// when the pointer is static.
        /// </summary>
        private void LateUpdate()
        {
            _pointerDelta = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _pointerDelta.x = UnityEngine.Input.GetAxis("Mouse X");
            _pointerDelta.y = UnityEngine.Input.GetAxis("Mouse Y");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _pointerDelta = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerActive = true;
            PointerDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointerActive = false;
            PointerUp?.Invoke();
        }
    }

    public interface ISlidingArea
    {
        Vector2 PointerDelta { get; }
        bool PointerActive { get; }
        event Action PointerDown;
        event Action PointerUp;
    }
}