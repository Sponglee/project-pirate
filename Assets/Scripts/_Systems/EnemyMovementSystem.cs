using UnityEngine;
using Anthill.Core;
using Anthill.Inject;

public class EnemyMovementSystem : ISystem, IExecuteSystem, IExecuteFixedSystem
{
    private AntNodeList<EnemyMovementNode> _enemyNodes;

    [Inject] public Game Game { get; set; }



    public void AddedToEngine()
    {
        _enemyNodes = AntEngine.GetNodes<EnemyMovementNode>();
        _enemyNodes.EventNodeAdded += NodeAddedHandler;
        _enemyNodes.EventNodeRemoved += NodeRemovedHandler;

        AntInject.Inject<EnemyMovementSystem>(this);

    }

    public void RemovedFromEngine()
    {
        _enemyNodes = null;
    }

    public void Execute()
    {

    }

    public void ExecuteFixed()
    {
        if (Game.PlayerController == null) return;

        EnemyMovementNode node;

        for (int i = _enemyNodes.Count - 1; i >= 0; i--)
        {
            node = _enemyNodes[i];
            node.TargetDummy.ExecuteMovement();

            // Vector3 dir = (-node.Movement.movementTransform.position + Game.PlayerController.gameObject.transform.position).normalized;
            // Debug.DrawLine(node.Movement.movementTransform.position, node.Movement.movementTransform.position - dir * 2f, Color.red);
            // // Debug.Log(dir.x + " : " + dir.z);
            // node.AIControl.inputX = dir.x;
            // node.AIControl.inputY = dir.z;

        }
    }

    public void NodeAddedHandler(EnemyMovementNode aNode)
    {
        Debug.Log($"ADDED DUMMY " + _enemyNodes.Count);
    }

    public void NodeRemovedHandler(EnemyMovementNode aNode)
    {
        Debug.Log($"Removed DUMMY " + _enemyNodes.Count);
    }

    private void StateChangeHandler()
    {

    }

}