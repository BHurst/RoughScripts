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
}