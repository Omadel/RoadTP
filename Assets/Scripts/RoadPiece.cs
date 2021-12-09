using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPiece : MonoBehaviour
{
    public Vector3Int[] Connections => connections;
    [SerializeField] Vector3Int[] connections;

    private void OnDrawGizmos() {
        if(connections.Length == 0) return;
        foreach(var connection in connections) {

            Gizmos.DrawSphere(transform.position + connection, .2f);
        }
    }
}
