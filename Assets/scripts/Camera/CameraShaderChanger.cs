using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaderChanger : MonoBehaviour
{
    public CameraFilterPack_Real_VHS VCRShader;
    public CameraFilterPack_FX_Drunk DRUNKONEShader;
    public CameraFilterPack_FX_Drunk2 DRUNKTWOShader;
    public CameraFilterPack_Pixel_Pixelisation PIXELShader;
    public CameraFilterPack_Vision_AuraDistortion AURAShader;

    public List<MonoBehaviour> tList = new List<MonoBehaviour>();
    private EventController _eventController;
    private void Start()
    {
        MonoBehaviour[] t = GetComponents<MonoBehaviour>();
        for (int i = 0; i < t.Length; i++)
        {
            Debug.Log(t[i].ToString());
            if (t[i].ToString().Contains("CameraFilt"))
            {

                tList.Add(t[i]);
            }
        }
    }
    private void OnEnable()
    {
        _eventController.ChangeCameraToShader += ChangeCameraVisual;
    }


    public void ChangeCameraVisual(CAMERA_SHADER targetShader)
    {
        for (int i = 0; i < tList.Count; i++)
        {
            tList[i].enabled = false;
        }
        switch (targetShader)
        {
            case CAMERA_SHADER.VCR:
                VCRShader.enabled = true;
                break;
            case CAMERA_SHADER.PIXEL:
                PIXELShader.enabled = true;
                break;
            case CAMERA_SHADER.AURA:
                AURAShader.enabled = true;
                break;
            case CAMERA_SHADER.DRUNK1:
                Debug.Log("PLS DO IT");
                DRUNKONEShader.enabled = true;
                break;
            case CAMERA_SHADER.DRUNK2:
                DRUNKTWOShader.enabled = true;
                break;
            default:
                break;
        }
    }
}


public enum CAMERA_SHADER
{
    VCR,
    PIXEL,
    AURA,
    DRUNK1,
    DRUNK2,

}