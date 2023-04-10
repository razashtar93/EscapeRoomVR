using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool m_IsPressed;
    private Vector3 m_StartPos;
    private ConfigurableJoint m_Joint;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        m_StartPos = transform.localPosition;
        m_Joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }

        if (m_IsPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(m_StartPos, transform.localPosition) / m_Joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        m_IsPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        m_IsPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
