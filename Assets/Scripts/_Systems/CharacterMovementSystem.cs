using UnityEngine;
using Anthill.Core;

public class CharacterMovementSystem : ISystem, IExecuteSystem, IExecuteFixedSystem
{
    private AntNodeList<MovementNode> _inputNodes;

    public void AddedToEngine()
    {
        _inputNodes = AntEngine.GetNodes<MovementNode>();
        _inputNodes.EventNodeAdded += KeyboardNodeAddedHandler;
        _inputNodes.EventNodeRemoved += KeyboardNodeRemovedHandler;
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
        MovementNode node;
        for (int i = _inputNodes.Count - 1; i >= 0; i--)
        {
            node = _inputNodes[i];
            node.Movement.movementX = node.Control.inputX;
            node.Movement.movementY = node.Control.inputY;

            node.Movement.rb.velocity =
                new Vector3(node.Movement.movementX * Time.fixedDeltaTime * node.Movement.speed,
                node.Movement.rb.velocity.y,
                node.Movement.movementY * Time.fixedDeltaTime * node.Movement.speed);

            if (node.Control.jumpTrigger && !node.Movement.IsJumping && node.Movement.IsOnGround)
            {
                node.Movement.rb.AddForce(Vector3.up * node.Movement.jumpForce, ForceMode.VelocityChange);
                node.Movement.IsOnGround = false;
                node.Movement.IsJumping = true;
            }
        }
    }

    public void KeyboardNodeAddedHandler(MovementNode aNode)
    {
        Debug.Log($"Added MOVEMENT `{aNode.Entity.gameObject.name}` node!");
    }

    public void KeyboardNodeRemovedHandler(MovementNode aNode)
    {
        Debug.Log($"Removed MOVEMENT `{aNode.Entity.gameObject.name}` node!");
    }

}