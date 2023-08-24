using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//EventSystem is required in the Hierarchy for this to work.
//need to attached to a UI gameObject which serve as the joystick base
public class TwinSticks : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static TwinSticks Left { private set; get; }
    public static TwinSticks Right { private set; get; }
    public float Vertical { private set; get; }
    public float Horizontal { private set; get; }
    //the joystick knob
    public RectTransform Knob;
    public float MaxDistance = 100;
    private void Awake()
    {
        if (name.ToLower() == "right" || Left != null)
        {
            Right = this;
        }
        else if (Left == null)
        {
            Left = this;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 point = eventData.position;
        Vector2 deltaPos = point - (Vector2)transform.position;
        float distance = deltaPos.magnitude;
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
        Horizontal = axis.x;
        Vertical = axis.y;
    }
}
