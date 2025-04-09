using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    bool thirdPerson = false;

    public float mouseSensitivity = 300f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        yRotation = playerBody.rotation.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            thirdPerson = !thirdPerson;
        }
        //сброс на первое лицо
        transform.localPosition = new Vector3(0, 2, 0);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        if (thirdPerson)
        {
            transform.localPosition = new Vector3(0, 4, -5);
        }
    }
}