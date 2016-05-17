using UnityEngine;
using System.Collections;

public class TeleportCamera : MonoBehaviour
{
    Camera camera;
    
    RenderTexture texture;

    void Awake ()
    {
        camera = GetComponent<Camera>();

        texture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);

        camera.aspect = 1;

        camera.targetTexture = texture;
    }

    public void SetMeshRenderer(MeshRenderer renderer)
    {
        renderer.material.mainTexture = texture;
    }

}
