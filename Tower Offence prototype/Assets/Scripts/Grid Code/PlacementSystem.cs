using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject MouseIndicator;
    [SerializeField] private MouseTracker inputManager;

    private void Update()
    {
        Vector3 MousePos = inputManager.GetMapPos();
        MouseIndicator.transform.position = MousePos;
    }
}
