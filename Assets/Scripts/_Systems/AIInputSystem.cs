using UnityEngine;
using Anthill.Core;
using Anthill.Inject;

public class AIInputSystem : ISystem, IExecuteSystem, IExecuteFixedSystem
{
    private AntNodeList<AIInputNode> _inputNodes;

    [Inject] public Game Game { get; set; }



    public void AddedToEngine()
    {
        _inputNodes = AntEngine.GetNodes<AIInputNode>();
        _inputNodes.EventNodeAdded += KeyboardNodeAddedHandler;
        _inputNodes.EventNodeRemoved += KeyboardNodeRemovedHandler;

        AntInject.Inject<AIInputSystem>(this);

    }

    public void RemovedFromEngine()
    {
        _inputNodes = null;
    }

    public void Execute()
    {

    }

    public void ExecuteFixed()
    {
        AIInputNode node;

        for (int i = _inputNodes.Count - 1; i >= 0; i--)
        {
            node = _inputNodes[i];

            node.AIControl.internalTimer += Time.fixedDeltaTime;

            if (Game.PlayerController == null) continue;

            Vector3 dir = (-node.Movement.movementTransform.position + Game.PlayerController.gameObject.transform.position).normalized;
            Debug.DrawLine(node.Movement.movementTransform.position, node.Movement.movementTransform.position - dir * 2f, Color.red);
            // Debug.Log(dir.x + " : " + dir.z);
            node.AIControl.inputX = dir.x;
            node.AIControl.inputY = dir.z;

        }
    }

    public void KeyboardNodeAddedHandler(AIInputNode aNode)
    {
        Debug.Log($"ADDED AIINPUTNODE " + _inputNodes.Count);
    }

    public void KeyboardNodeRemovedHandler(AIInputNode aNode)
    {
        Debug.Log($"Removed AIINPUTNODE " + _inputNodes.Count);
    }

}