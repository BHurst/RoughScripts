using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook freeCam;

    private void Awake()
    {
        freeCam = GetComponent<CinemachineFreeLook>();
    }

    public void Update()
    {
        freeCam.m_XAxis.m_InputAxisValue = Input.GetAxisRaw("MouseX") * Time.deltaTime;
        freeCam.m_YAxis.m_InputAxisValue = Input.GetAxisRaw("MouseY") * Time.deltaTime;
    }

    //public Transform target;
    //public float distance = 5.0f;
    //public float maxDistance = 5.0f;
    //public float xSpeed = 120.0f;
    //public float ySpeed = 120.0f;

    //public float yMinLimit = -80f;
    //public float yMaxLimit = 80f;

    //public float distanceMin = .5f;
    //public float distanceMax = 15f;

    //private RaycastHit camLineOfSight;

    //float x = 0.0f;
    //float y = 0.0f;

    //// Use this for initialization
    //void Start()
    //{
    //    Vector3 angles = transform.eulerAngles;
    //    x = angles.y;
    //    y = angles.x;
    //}

    //void FixedUpdate()
    //{
    //    x += Input.GetAxis("MouseX") * xSpeed * Time.deltaTime;
    //    y -= Input.GetAxis("MouseY") * ySpeed * Time.deltaTime;

    //    y = ClampAngle(y, yMinLimit, yMaxLimit);

    //    Quaternion rotation = Quaternion.Euler(y, x, 0);

    //    Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
    //    Vector3 position = rotation * negDistance + target.position;

    //    //transform.rotation = rotation;
    //    transform.position = position;
    //}

    //public static float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360F)
    //        angle += 360F;
    //    if (angle > 360F)
    //        angle -= 360F;
    //    return Mathf.Clamp(angle, min, max);
    //}
}