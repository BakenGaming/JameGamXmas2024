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
    }
    private void OnDisable() 
    {
        GameManager.onGameReady -= Initialize;  
    }
    private void Initialize()
    {
        Debug.Log("Camera Initialized");
        _mainCam = Camera.main;
        _cameraTarget = GameManager.i.GetPlayerGO().transform;
    }

    private void Update() 
    {
        _mainCam.transform.position = new Vector3(_mainCam.transform.position.x, _cameraTarget.position.y, _mainCam.transform.position.z);        
    }
}
