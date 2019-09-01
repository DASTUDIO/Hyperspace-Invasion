using UnityEngine;
using Z;

public class InspectorCamera : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = ((GameObject)Zarch.objects["inspectorSample"]).transform;

        transform.position = new Vector3(target.position.x + 3, target.position.y + 2, target.position.z + 3); ;

        transform.LookAt(target.transform);

    }

    void Update() { transform.RotateAround(target.position, Vector3.up, 2); }

}
