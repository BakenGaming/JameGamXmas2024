using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCam;
    private Transform _cameraTarget;
    private void OnEnable() 
    {
        GameManager.onGameReady += Initialize;
        PlayerHandler.onLaunched += SetCameraTarget;
    }
    private void OnDisable() 
    {
        GameManager.onGameReady -= Initialize;  
        PlayerHandler.onLaunched -= SetCameraTarget;
    }
    private void Initialize()
    {
        Debug.Log("Camera Initialized");
        _mainCam = Camera.main;
        _cameraTarget = null;
    }

    private void Update() 
    {
        _mainCam.transform.position = new Vector3(_cameraTarget.position.x, _mainCam.transform.position.y, _mainCam.transform.position.z);        
    }
    private void SetCameraTarget()
    {
        _cameraTarget = GameManager.i.GetSledGO().transform;
    }
}
