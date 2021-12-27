using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCameraController : MonoBehaviour
{
    public List<GameObject> targets;
    public Vector3 offset;
    float smoothTime = .5f;
    public Transform player;
    float smoothSpeed = 0.125f;
    Vector3 velocity;
      
    float minZoom = 150f;
    float maxZoom = 90f;
    float ZoomLimiter = 50f;
    Camera cam;
    private void Update()
    {
        if (targets.Count == 0)
            return;
        else if(targets.Count == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector3 desiredPosiiton = new Vector3(player.position.x + 8, player.position.y + 5, transform.position.z);
            Vector3 smoothedPosiiton = Vector3.Lerp(transform.position, desiredPosiiton, smoothSpeed);
            transform.position = smoothedPosiiton;
        }
        else
        {
            for(int i = 0; i < targets.Count; i++)
            {
                if(targets[i] == null)
                {
                    Debug.Log("targets[i] " + i +" is null");
                    if (targets[i + 1] != null)
                    {
                        for (int j = i; j <= targets.Count; j++)
                        {
                            if (j == (targets.Count - 1))
                            {
                                //Delete last element from list
                                targets.RemoveAt(targets.Count - 1);
                                break;
                            }
                            targets[j] = targets[j + 1];
                            Debug.Log(j);
                            
                        }
                    }
                    else
                    {
                        Debug.Log( " End List  " );
                    }
                    Debug.Log("I is " + i);
                    /* if(targets[i] == targets[i+1])
                     {
                         Debug.Log(i + " and  " + i + 1 + " same");
                     }*/
                }
            }
            Move();
            Zoom();
        }
        
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
        //Debug.Log(GetGreatestDistance());
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / ZoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for(int i=  0; i <targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].transform.position;
        }
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].transform.position);
        }

        return bounds.center;
    }
}
