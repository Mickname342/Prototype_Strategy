using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManagment : MonoBehaviour
{
    [SerializeField] private Camera SceneCamera;
    private Vector3 LastPos;
    [SerializeField] private LayerMask placementLayerMask;
    [SerializeField] private PlacementSystem placementSystem;
    public event Action OnClicked, OnExit;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();
    

    public Vector3 GetMapPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCamera.nearClipPlane;
        Ray ray = SceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 100, placementLayerMask))
        {
            LastPos = hit.point;
        }
        return LastPos;
    }
}
