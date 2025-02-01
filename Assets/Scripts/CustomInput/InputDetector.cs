using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CustomInput
{
    public class InputDetector : MonoBehaviour, IPointerClickHandler, IClickDetect, IGetInputLastPoint
    {
        public event Action OnClick;
        
        private Vector2 lastPoint;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            lastPoint = eventData.position;
            Debug.Log("OnPointerClick");
            OnClick?.Invoke();
        }

        public Vector2 GetPoint()
        {
            return lastPoint;
        }
    }
}
