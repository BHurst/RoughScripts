using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Cinemachine;

public class CharacterCameraController : MonoBehaviour {

    public Cinemachine3rdPersonFollow cam;
    Transform camFocus;
    RaycastHit camHit;
    float baseDistance = 4;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        camFocus = GameObject.Find("CameraHeadFocus").transform;
    }

    void LateUpdate()
    {
        Physics.Raycast(camFocus.position, transform.position - camFocus.position, out camHit, baseDistance, 1<<9);

        if (camHit.collider != null)
            cam.CameraDistance = Mathf.Lerp(cam.CameraDistance, camHit.distance, .5f);
        else
            cam.CameraDistance = Mathf.Lerp(cam.CameraDistance, baseDistance, .5f);
    }
}