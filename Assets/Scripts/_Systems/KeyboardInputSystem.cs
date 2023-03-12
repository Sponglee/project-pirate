using UnityEngine;
using Anthill.Core;

public class KeyboardInputSystem : ISystem, IExecuteSystem, IDisableSystem, IEnableSystem
{
    private AntNodeList<KeyboardInputNode> _inputNodes;
    private Transform cameraRef;

    public void AddedToEngine()
    {
        _inputNodes = AntEngine.GetNodes<KeyboardInputNode>();
        _inputNodes.EventNodeAdded += KeyboardNodeAddedHandler;
        _inputNodes.EventNodeRemoved += KeyboardNodeRemovedHandler;
        cameraRef = Camera.main.transform;
    }

    public void RemovedFromEngine()
    {
        _inputNodes = null;
    }

    public void Execute()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 dir = cameraRef.rotation * new Vector3(inputX, 0f, inputY);

        bool jumpTrigger = Input.GetAxisRaw("Jump") == 1 ? true : false;

        KeyboardInputNode node;
        for (int i = _inputNodes.Count - 1; i >= 0; i--)
        {
            node = _inputNodes[i];

            node.Control.inputX = dir.x;
            node.Control.inputY = dir.z;
            node.Control.jumpTrigger = jumpTrigger;
        }
    }

    public void KeyboardNodeAddedHandler(KeyboardInputNode aNode)
    {
        Debug.Log($"Added KEYBOARDINPUTNODE " + _inputNodes.Count);
    }

    public void KeyboardNodeRemovedHandler(KeyboardInputNode aNode)
    {
        Debug.Log($"Removed KEYBOARDINPUTNODE " + _inputNodes.Count);
    }

    public void Disable()
    {
    }

    public void Enable()
    {

    }
}