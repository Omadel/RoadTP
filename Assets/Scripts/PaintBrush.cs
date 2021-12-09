using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : Tool {
    [SerializeField] private GameObject objectToPaint;
    private Dictionary<Vector3Int, GameObject> grid = new Dictionary<Vector3Int, GameObject>();

    private void Update() {
        if(Input.GetKey(KeyCode.Mouse0)) {
            Paint();
        }
    }

    private void Paint() {
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out float distance)) {
            Vector3 worldPosition = ray.GetPoint(distance);
            Vector3Int gridPosition = Vector3Int.RoundToInt(worldPosition);
            if(grid.ContainsKey(gridPosition)) return;

            GameObject go = Instantiate(objectToPaint, gridPosition, Quaternion.identity);
            grid.Add(gridPosition, go);
        }
    }
}
