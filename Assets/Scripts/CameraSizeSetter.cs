using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(Camera))]
public class CameraSizeSetter : MonoBehaviour
{
    [SerializeField] Vector2 targetResolution;
    [SerializeField] float targetCameraSize;

    [SerializeField] bool isUpdate;

    Camera _camera;

    //--------------------------------------------------

    void Awake()
    {
        _camera = GetComponent<Camera>();

        SetCameraSize();
    }

    void Update()
    {
		if (isUpdate) {
            SetCameraSize();
		}
    }

    void SetCameraSize()
    {
        var targetRatio = targetResolution.y / targetResolution.x;
        var currentRatio = (float)Screen.height / (float)Screen.width;

        var targetSize = (targetCameraSize * currentRatio) / targetRatio;
        _camera.orthographicSize = targetSize;
    }
}
