using UnityEngine;

public class ToolManager : MonoBehaviour {
    private Tool[] tools;
    private Tool activeTool;

    private void Start() {
        tools = GetComponentsInChildren<Tool>();
        SetTool(0);

    }

    private void SetTool(int index) {
        foreach(Tool tool in tools) tool.enabled = false;
        activeTool = tools[index];
        activeTool.enabled = true;
    }
}
