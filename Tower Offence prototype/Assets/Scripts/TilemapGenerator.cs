using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Camera SceneCamera;
    private Vector3 LastPos;
    [SerializeField] private LayerMask placementLayerMask;

    public Vector3 GetMapPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCamera.nearClipPlane;
        Ray ray = SceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 1000, placementLayerMask))
        {
            LastPos = hit.point;
        }
        return LastPos;
    }
}
