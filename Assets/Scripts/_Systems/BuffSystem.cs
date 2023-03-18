using UnityEngine;
using Anthill.Core;

public class BuffSystem : ISystem, IExecuteSystem, IExecuteFixedSystem
{
    private AntNodeList<BuffNode> _buffNodes;

    public void AddedToEngine()
    {
        _buffNodes = AntEngine.GetNodes<BuffNode>();
        _buffNodes.EventNodeAdded += BuffNodeAddedHanlder;
        _buffNodes.EventNodeRemoved += BuffNodeRemovedHandler;

    }

    public void RemovedFromEngine()
    {
        _buffNodes = null;


        BuffNode node;
        for (int i = _buffNodes.Count - 1; i >= 0; i--)
        {
            node = _buffNodes[i];
            if (node.Buff.isInvincible)
            {
                node.Health.CanTakeDamage = false;
            }
        }
    }

    public void Execute()
    {

    }

    public void ExecuteFixed()
    {
        BuffNode node;
        for (int i = _buffNodes.Count - 1; i >= 0; i--)
        {
            node = _buffNodes[i];
            node.Buff.buffTimer += Time.fixedDeltaTime;
            if (node.Buff.buffTimer >= node.Buff.buffDuration)
            {
                node.Health.CanTakeDamage = true;
            }
        }
    }

    public void BuffNodeAddedHanlder(BuffNode aNode)
    {

        A.Log("CHECKED" + aNode.Buff.isInvincible);
        if (aNode.Buff.isInvincible)
        {
            aNode.Health.CanTakeDamage = true;
        }
    }

    public void BuffNodeRemovedHandler(BuffNode aNode)
    {

        A.Log("REMOVED" + aNode.Buff.isInvincible);
        if (aNode.Buff.isInvincible)
        {
            aNode.Health.CanTakeDamage = false;
        }
    }

}