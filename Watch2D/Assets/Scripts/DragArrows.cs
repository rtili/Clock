using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragArrows : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private InputField _timeInputField;
    [SerializeField] private int _value;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = (Vector2)Input.mousePosition - (Vector2)_centerPoint.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        UpdateInputField(-angle);
    }

    private void UpdateInputField(float angle)
    {
        int time = Mathf.RoundToInt(angle / 360f * _value);
        time = (time + _value) % _value;
        _timeInputField.text = time.ToString();      
    }
}
