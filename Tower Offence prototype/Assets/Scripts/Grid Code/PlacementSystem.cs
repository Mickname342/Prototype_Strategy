using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject MouseIndicator, CellIndicator;
    [SerializeField] private InputManagment inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private GoblinDatabase database;
    [SerializeField] private int SelectedObjectIndex = -1;
    public int Gold  = 900;

    private void Start()
    {
        StopPlacement();
    }


    public void StartPlacement(int ID)
    {
        StopPlacement();
         CellIndicator.SetActive(true);
        
        //SelectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        SelectedObjectIndex = Random.Range(0,3);
        if(SelectedObjectIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;
        }
        if(Gold>=100)
        {
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
        }
        else if(Gold<100)
        {
            Debug.Log("You can't afford any more goblins");
            return;
        }
        
    }
    private void PlaceStructure()
    {
        if(inputManager.IsPointerOverUI()) 
        {
            return;
        }
        Vector3 MousePos = inputManager.GetMapPos();
        Vector3Int GridPos = grid.WorldToCell(MousePos);
        GameObject newObject = Instantiate(database.objectsData[SelectedObjectIndex].Prefab);
        newObject.transform.position = grid.CellToWorld(GridPos);
    }
        private void StopPlacement()
    {
        SelectedObjectIndex = -1;
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement; 
        CellIndicator.SetActive(false);       
    }

    private void Update()
    {
        if(SelectedObjectIndex < 0 )
        {
            return;
        }
        Vector3 MousePos = inputManager.GetMapPos();
        Vector3Int GridPos = grid.WorldToCell(MousePos);
        MouseIndicator.transform.position = MousePos;
        CellIndicator.transform.position = grid.CellToWorld(GridPos);
    Checker();
    }

    public void Checker()
    {
        if(Input.GetMouseButtonDown(0) && Gold >=100)
        {
            Debug.Log("you recruited a goblin");
            Gold -=100;
            StopPlacement();
        }


    }
}
