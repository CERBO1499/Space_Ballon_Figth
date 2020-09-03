using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMCameraResolutionFix : MonoBehaviour
{
    public SpriteRenderer spriteWidth;

    void Start()
    {
        //VERTICAL FIT
        //Camera.main.orthographicSize = spriteWidth.bounds.size.x * Screen.height / Screen.width * 0.5f;
        GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = spriteWidth.bounds.size.x * Screen.height / Screen.width * 0.5f;

        /*
        //HORIZONTAL FIT
        Camera.main.orthographicSize = spriteWidth.bounds.size.y / 2;

        //ENTIRE FIT
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = spriteWidth.bounds.size.x / spriteWidth.bounds.size.y;
        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = spriteWidth.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = spriteWidth.bounds.size.y / 2 * differenceInSize;
        }
        */
    }
}