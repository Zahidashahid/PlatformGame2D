using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCameraController : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    float smoothTime = .5f;
    Vector3 velocity;
      
    float minZoom = 150f;
    float maxZoom = 90f;
    float ZoomLimiter = 50f;
    Camera cam;
    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        Move();
        Zoom();
    }
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    void Zoom()
    {
        Debug.Log(GetGreatestDistance());
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / ZoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=  0; i <targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
