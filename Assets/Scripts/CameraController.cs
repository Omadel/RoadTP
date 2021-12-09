using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    private float _screenDistance = 70;
    private float _zoom;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _zoom = 10;
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
            if (_zoom >= 1 && Input.mouseScrollDelta.y < 0)
            {
            cam.transform.localPosition += cam.transform.forward * Input.mouseScrollDelta.y;
                _zoom += Input.mouseScrollDelta.y;
            } 
            
            if (_zoom <= 20 && Input.mouseScrollDelta.y > 0)
            {
            cam.transform.localPosition += cam.transform.forward * Input.mouseScrollDelta.y;
                _zoom += Input.mouseScrollDelta.y;
            } 
            
        }
    }

    public void Recenter()
    {
        transform.position = Vector3.zero;
    }
}
