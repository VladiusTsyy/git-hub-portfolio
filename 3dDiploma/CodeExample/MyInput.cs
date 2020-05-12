using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour {
	protected Vector2 m_Movement;
    protected Vector2 m_Camera;
	public bool playerControllerInputBlocked;
	protected bool m_ExternalInputBlocked;

	 public Vector2 MoveInput
    {
        get
        {
            return Vector2.zero;
            return m_Movement;
        }
    }

    public Vector2 CameraInput
    {
        get
        {
            return Vector2.zero;
            return m_Camera;
        }
    }
	
	// Update is called once per frame
	void Update () {
		m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}
}
