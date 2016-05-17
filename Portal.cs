using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    [SerializeField]
    TeleportCamera firstCamera, secondCamera;

    [SerializeField]
    MeshRenderer firstRenderer, secondRenderer;

    [SerializeField]
    Transform firstPosition, secondPosition;

    [SerializeField]
    Portal connectedPortal;

    void Start()
    {
        SetupPortal();
    }

    void SetupPortal()
    {
        if (connectedPortal == null)
            return;

        firstCamera.SetMeshRenderer(connectedPortal.firstRenderer);
        secondCamera.SetMeshRenderer(connectedPortal.secondRenderer);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (connectedPortal == null)
            return;

        Character character = other.GetComponent<Character>();
        if (character == null)
            return;

        bool isFirst = Vector3.Dot(transform.forward, transform.position - other.transform.position) < 0;

        if (isFirst)
            character.Teleport(connectedPortal.firstPosition.position);
        else
            character.Teleport(connectedPortal.secondPosition.position);

        var cameras = FindObjectsOfType<MainCamera>();

        foreach (var camera in cameras)
            camera.Blur();
    }
}
