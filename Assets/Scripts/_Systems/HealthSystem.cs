using UnityEngine;
using Anthill.Core;

public class HealthSystem : ISystem, IExecuteSystem
{
    private AntNodeList<HealthNode> _healthNodes;

    public void AddedToEngine()
    {
        _healthNodes = AntEngine.GetNodes<HealthNode>();
        _healthNodes.EventNodeAdded += HealthNodeAddedHandler;
        _healthNodes.EventNodeRemoved += HealthNodeRemovedHandler;
    }

    public void RemovedFromEngine()
    {
        _healthNodes = null;
    }

    public void Execute()
    {
        HealthNode node;
        for (int i = _healthNodes.Count - 1; i >= 0; i--)
        {
            node = _healthNodes[i];
            if (!node.Health.CanTakeDamage) continue;

            if (node.Health.cashedDamage > 0 && node.Health.CanTakeDamage)
            {
                float tmpDamage = node.Health.cashedDamage;
                node.Health.cashedDamage = 0f;
                node.Health.health -= tmpDamage;
            }

            if (node.Health.health <= 0.0f)
            {
                AntEngine.RemoveEntity(node.Entity);
                GameObject.Destroy(node.Entity.gameObject);
            }

        }
    }

    public void HealthNodeAddedHandler(HealthNode aNode)
    {
        Debug.Log($"Added HEALTH `{aNode.Entity.gameObject.name}` node!");
    }

    public void HealthNodeRemovedHandler(HealthNode aNode)
    {
        Debug.Log($"Removed HEALTH`{aNode.Entity.gameObject.name}` node!");
    }
}