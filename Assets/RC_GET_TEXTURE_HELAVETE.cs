using UnityEngine;

public class RC_GET_TEXTURE_HELAVETE : MonoBehaviour
{
    public Camera RenderCamera;
    public Material Mat;

    [Space(20)]
    public bool FreezeEnable = false;
    private bool SkinnedMesh;

    private RenderTexture _rt;

    void Start()
    {
        if (FreezeEnable && RenderCamera)
            RenderCamera.enabled = false;
        if (GetComponent<SkinnedMeshRenderer>())
            SkinnedMesh = true;
    }

    private void Update()
    {
        UpdateMaterial(RenderCamera, Mat);
    }

    void onGUI()
    {
        if (RenderCamera)
            RenderCamera.enabled = !FreezeEnable;
    }

    private void UpdateMaterial(Camera renderCamera, Material material)
    {
        if (!renderCamera)
            return;

        if (!_rt && renderCamera.targetTexture)
        {
            _rt = renderCamera.targetTexture;
            if (SkinnedMesh)
                material.SetTexture("_MainTex", renderCamera.targetTexture);
            else
                material.SetTexture("_MainTex", renderCamera.targetTexture);
        }

        if (_rt && _rt != renderCamera.targetTexture)
            Destroy(_rt);
    }
}