using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//EventSystem is required in the Hierarchy for this to work.
//need to attached to a UI gameObject which serve as the joystick base
public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static VirtualJoystick Default { private set; get; }
    public float Vertical { private set; get; }
    public float Horizontal { private set; get; }
    //the joystick knob
    public RectTransform Knob;
    public float MaxDistance = 100;
    private void Awake()
    {
        Default = this;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 point = eventData.position;
        Vector2 deltaPos = point - (Vector2)transform.position;//transform.position is the center of the background
        float distance = deltaPos.magnitude;//distance from the knob and the center of background
        //we need to factor in the scale of the joystick so the distance is calculated correctly
        float maxDistance = MaxDistance * transform.lossyScale.x;
        if (distance > maxDistance)
        {
            //we move the knob so it will not exceed the max distance.
            Vector2 direction = deltaPos.normalized;
            Vector2 proj = direction * MaxDistance;
            Knob.localPosition = proj;
        }
        else
            Knob.position = eventData.position;

        UpdateAxis();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Knob.position = eventData.position;
        UpdateAxis();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //reset the knob
        Knob.localPosition = Vector3.zero;
        Horizontal = 0;
        Vertical = 0;
    }
    void UpdateAxis()
    {
        //we update the axis info to MyInput
        Vector2 pos = Knob.localPosition;
        Vector2 axis = pos / MaxDistance;
        Horizontal = axis.x;//axis.x is a value between -1 and 1
        Vertical = axis.y;//axis.y is a value between -1 and 1
    }
}
