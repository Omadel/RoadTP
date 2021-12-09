using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Mathf.Abs(Input.mouseScrollDelta.sqrMagnitude) >= .1f)
        {
            cam.transform.localPosition += cam.transform.forward * Input.mouseScrollDelta.y;
        }

    }
}
