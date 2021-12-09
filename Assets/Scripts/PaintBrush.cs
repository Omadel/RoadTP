using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintBrush : Tool {
    [SerializeField] private GameObject preview;
    [SerializeField] private Color[] previewColors;
    [SerializeField] private GameObject objectToPaint;
    [SerializeField] private RoadPiece[] roadPieces;
    private Dictionary<Vector3Int, GameObject> grid = new Dictionary<Vector3Int, GameObject>();
    private Dictionary<string, GameObject> roadPiecesDico = new Dictionary<string, GameObject>();
    List<Vector3Int> checkedPieces;

    private void Start() {
        foreach(RoadPiece roadPiece in roadPieces) {
            roadPiecesDico.Add(roadPiece.Connections.ToString(), roadPiece.gameObject);
        }
        preview = GameObject.Instantiate(preview, transform);
    }

    private void Update() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Vector3Int gridPosition = GetGridMousePosition();
        preview.transform.position = gridPosition;
        bool alreadyExists = grid.ContainsKey(gridPosition);
        if(alreadyExists) {
            //if(Input.GetKeyDown(KeyCode.Mouse0)) Erase(gridPosition);
            preview.GetComponent<MeshRenderer>().material.color = previewColors[0];
            return;
        }
        preview.GetComponent<MeshRenderer>().material.color = previewColors[1];

        if(Input.GetKey(KeyCode.Mouse0)) Paint(gridPosition);
    }

    private void Erase(Vector3Int gridPosition) {
        GameObject.Destroy(grid[gridPosition]);
        grid.Remove(gridPosition);
    }

    private void Paint(Vector3Int gridPosition) {
        checkedPieces = new List<Vector3Int>();
        Connections neighbours = CheckNeighbours(gridPosition);
        GameObject go = GetRoadPiece(neighbours);
        go = Instantiate(go, gridPosition, Quaternion.identity);
        grid.Add(gridPosition, go);
        checkedPieces.Add(gridPosition);
        UpdateNeighbours(gridPosition);
    }

    private void UpdateNeighbours(Vector3Int position) {
        Vector3Int[] neighbours = new Vector3Int[] {
            new Vector3Int(1,0,0),
            new Vector3Int(-1,0,0),
            new Vector3Int(0,0,1),
            new Vector3Int(0,0,-1)
        };
        foreach(Vector3Int neighbour in neighbours) {
            Vector3Int nPos = neighbour + position;
            if(!grid.ContainsKey(nPos)) continue;

            if(checkedPieces.Contains(nPos)) continue;

            GameObject.Destroy(grid[nPos]);
            Connections n = CheckNeighbours(nPos);
            GameObject go = GetRoadPiece(n);
            go = Instantiate(go, nPos, Quaternion.identity);
            grid[nPos] = go;
            checkedPieces.Add(nPos);
        }
    }

    private Vector3Int GetGridMousePosition() {
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out float distance)) {
            Vector3 worldPosition = ray.GetPoint(distance);
            Vector3Int gridPosition = Vector3Int.RoundToInt(worldPosition);
            return gridPosition;
        }
        return Vector3Int.zero;
    }

    private Connections CheckNeighbours(Vector3Int gridPosition) {
        Vector3Int[] neighbours = new Vector3Int[] {
            new Vector3Int(1,0,0),
            new Vector3Int(-1,0,0),
            new Vector3Int(0,0,1),
            new Vector3Int(0,0,-1)
        };
        Connections currentNeighbours = new Connections(neighbours.Length);
        for(int i = 0; i < neighbours.Length; i++) {
            if(grid.TryGetValue(gridPosition + neighbours[i], out GameObject go)) {
                Debug.Log(go.name + " is a neighbour", go);
                currentNeighbours.connections[i] = true;
            } else {
                currentNeighbours.connections[i] = false;
            }
        }
        return currentNeighbours;
    }

    private GameObject GetRoadPiece(Connections currentNeighbours) {
        if(roadPiecesDico.TryGetValue(currentNeighbours.ToString(), out GameObject gameObject)) {
            Debug.Log(gameObject.name, gameObject);
            return gameObject;
        }
        Debug.Log($"Key not found {currentNeighbours}");
        return roadPieces[0].gameObject;
    }
}
