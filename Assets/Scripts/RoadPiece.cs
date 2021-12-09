using UnityEngine;

public class RoadPiece : MonoBehaviour {
    public Connections Connections => connections;
    [SerializeField] private Connections connections;


    private void OnDrawGizmos() {
        Vector3Int[] neighbours = new Vector3Int[] {
            new Vector3Int(1,0,0),
            new Vector3Int(-1,0,0),
            new Vector3Int(0,0,1),
            new Vector3Int(0,0,-1)
        };

        if(connections.connections.Length == 0) return;
        for(int i = 0; i < connections.connections.Length; i++) {
            if(!connections.connections[i]) continue;
            Gizmos.DrawSphere(transform.position + neighbours[i], .2f);
        }
    }
}

[System.Serializable]
public struct Connections {
    public bool[] connections;

    public Connections(int lenght) {
        connections = new bool[lenght];
    }

    public override string ToString() {
        System.Text.StringBuilder stringbuilder = new System.Text.StringBuilder();
        foreach(bool b in connections) {
            stringbuilder.Append(b);
        }
        return stringbuilder.ToString();
    }
}
