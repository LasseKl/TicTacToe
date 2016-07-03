using System;
using System.Collections.Generic;

namespace GameFramework
{
    public class PriorityQueue<T>
    {
        protected LinkedList<PriorityNode<T>> list
            = new LinkedList<PriorityNode<T>>();

        public void Enqueue(PriorityNode<T> nodeToAdd)
        {
            if (list.Count == 0 || nodeToAdd.prio == 0)
            {
                list.AddFirst(nodeToAdd);
                return;
            }
            LinkedListNode<PriorityNode<T>> node = GetNodePos(nodeToAdd.prio);
            if (node.Value.prio >= nodeToAdd.prio)
            {
                list.AddBefore(node, nodeToAdd);
            }
            else
            {
                list.AddAfter(node, nodeToAdd);
            }
        }

        public void Dequeue(PriorityNode<T> node)
        {
            list.Remove(node);
        }

        public void Clear()
        {
            list.Clear();
        }

        public PriorityNode<T> GetNode(int prio)
        {
            LinkedListNode<PriorityNode<T>> curNode = list.Last;

            while (curNode != null)
            {
                if (curNode.Value.prio == prio)
                {
                    return curNode.Value;
                }

                curNode = curNode.Previous;
            }

            return null;
        }

        private LinkedListNode<PriorityNode<T>> GetNodePos(int prio)
        {
            LinkedListNode<PriorityNode<T>> curNode = list.Last;

            while (curNode != null)
            {
                if (curNode == list.First || curNode.Value.prio <= prio)
                {
                    return curNode;
                }

                curNode = curNode.Previous;
            }
            throw new Exception("No Elements");
        }
    }
}
