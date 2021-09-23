using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stone {

public class GameCameraScript : MonoBehaviour
{

    //Размер в пикселях для отображения
    private float sceneHigh = Const.CellSizePx * (Const.MapSize );

    private Camera _camera;

    private float PreviusAspect;
    private float unitsPerPixel;

    
    void Start()
    {
        PreviusAspect = 0;
        _camera = GetComponent<Camera>();
        float s = Const.CellSizePx * (Const.MapSize - 0);
        Camera.main.transform.position = new Vector3(s / 2f, -s / 2f, -10);

    }


    void Update()
    {
        if (PreviusAspect != Camera.main.aspect)
        {
            PreviusAspect = Camera.main.aspect;

            if (Camera.main.aspect > 1)
            {
                _camera.orthographicSize = sceneHigh / 2;
            }
            else
            {
                _camera.orthographicSize = sceneHigh / 2 / Camera.main.aspect;
            }
        }
    }
}
                 
}