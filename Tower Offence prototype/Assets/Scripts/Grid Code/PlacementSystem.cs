using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject MouseIndicator, CellIndicator;
    [SerializeField] private MouseTracker inputManager;
    [SerializeField] private Grid grid;

    private void Update()
    {
        Vector3 MousePos = inputManager.GetMapPos();
        Vector3Int GridPos = grid.WorldToCell(MousePos);
        MouseIndicator.transform.position = MousePos;
        CellIndicator.transform.position = grid.CellToWorld(GridPos);
    }
}
