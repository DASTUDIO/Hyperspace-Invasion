using UnityEngine;

public class Move : MonoBehaviour
{
    public void MoveHorizontal(float x)
    {
        transform.Translate(x, 0, 0, Space.World);

        if (transform.position.x < -94) { transform.position = new Vector3( -94, transform.position.y, transform.position.z); }

        if (transform.position.x > 94) { transform.position = new Vector3( 94, transform.position.y, transform.position.z );  }
    }

    void RotateVertical(float y) { transform.Rotate(y, 0, 0, Space.Self); }

    void RotateHorizontal(float x) { transform.Rotate(0, x, 0, Space.World); }

    float MoveSpeed = 2f;

    float MouseSpeed = 800.0f;

    void Update()
    {
        if (PlayerPrefs.GetInt("freeze")==0)
            return;

        if (!Input.GetAxis("Horizontal").Equals(0)) { MoveHorizontal(Input.GetAxis("Horizontal") * MoveSpeed); }

        if (!Input.GetAxis("Mouse X").Equals(0)) { RotateHorizontal(Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime); }

        if (!Input.GetAxis("Mouse Y").Equals(0)) { RotateVertical(Input.GetAxis("Mouse Y") * -MouseSpeed * Time.deltaTime);  }
    }

}
