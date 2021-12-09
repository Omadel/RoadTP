using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    private float _screenDistance = 70;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - _screenDistance)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.width - _screenDistance)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y < _screenDistance)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x < _screenDistance)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Mathf.Abs(Input.mouseScrollDelta.sqrMagnitude) >= .1f)
        {
            cam.transform.localPosition += cam.transform.forward * Input.mouseScrollDelta.y;
        }
    }
}
