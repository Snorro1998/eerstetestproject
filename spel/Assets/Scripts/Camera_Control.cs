using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

	public enum RotationAxis{
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axes = RotationAxis.MouseX;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	public float sensHorizontal = 10.0f;
	public float sensVertical = 10.0f;

	public float _rotationX = 0;

	// Update is called once per frame
	void Update () {
		if (axes == RotationAxis.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensHorizontal, 0);
		} else if (axes == RotationAxis.MouseY) {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensVertical;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert); //Clamps the vertical angle within the min and max limits (45 degrees)

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
	}
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public enum RotationAxis{
		MouseX = 1,
		MouseY = 2
	}
	
	public RotationAxis axes = RotationAxis.MouseX;
	
	public float senseHorizontal = 10.0f;
	public float senseVertical = 10.0f;
	
	public float _rotationX = 0;
	
	
	
    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxis.MouseX) {
			transform.Rotate (0, Input.GetAxis("MouseX") * senseHorizontal, 0);
		}
		else if(axes == RotationAxis.MouseY) {
			_rotationX -= Input.GetAxis("MouseY") * senseVertical;
			//transform.Rotate (0, Input.GetAxis("MouseY") * senseVertical, 0);
			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
    }
}*/
