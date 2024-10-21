using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float MouseSensitivityY = 5f;
    [SerializeField] float SmoothDampY = 0.2f;
    [SerializeField]
    [Tooltip("Altura mínima da camera")]
    float minCameraY = 0.5f;
    [SerializeField]
    [Tooltip("Altura máxima da camera")]
    float maxCameraY = 5f;

    CinemachineVirtualCamera _cm;
    CinemachineTransposer _tp;

    // Start is called before the first frame update
    void Start()
    {
        //esconder e bloquear
        Cursor.lockState = CursorLockMode.Locked;
        _cm = FindObjectOfType<CinemachineVirtualCamera>();
        _tp=_cm.GetCinemachineComponent<CinemachineTransposer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;

        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
        mouseY = mouseY * MouseSensitivityY;
        _tp.m_FollowOffset.y = Mathf.SmoothStep(_tp.m_FollowOffset.y, _tp.m_FollowOffset.y + mouseY, SmoothDampY);
        _tp.m_FollowOffset.y=Mathf.Clamp(_tp.m_FollowOffset.y,minCameraY, maxCameraY);
    }
}
