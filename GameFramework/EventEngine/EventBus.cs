using System;
using System.Collections.Generic;

namespace GameFramework
{
    public class EventWrapper<T>
    {
        private event Action<T> OnEvent;

        public EventWrapper(Action<T> method)
        {
            OnEvent -= method;
            OnEvent += method;
        }

        public void SignIn(Action<T> method)
        {
            OnEvent -= method;
            OnEvent += method;
        }

        public void SignOut(Action<T> method)
        {
            OnEvent -= method;
        }

        public void Fire(T t)
        {
            OnEvent(t);
        }
    }

    public class EventReceiverQueue<T> : PriorityQueue<EventWrapper<T>>
    {
        public void Fire(T t)
        {
            LinkedListNode<PriorityNode<EventWrapper<T>>> curNode;
            curNode = list.Last;

            while(curNode != null)
            {
                curNode.Value.value.Fire(t);
                curNode = curNode.Previous;
            }
        }

        public void Enqueue(int prio, Action<T> method)
        {
            PriorityNode<EventWrapper<T>> node = GetNode(prio);
            if(node != null)
            {
                node.value.SignIn(method);
                return;
            }
            Enqueue(new PriorityNode<EventWrapper<T>>(prio, new EventWrapper<T>(method)));
        }

        public void Dequeue(Action<T> method)
        {
            LinkedListNode<PriorityNode<EventWrapper<T>>> curNode;
            curNode = list.First;

            while (curNode != null)
            {
                curNode.Value.value.SignOut(method);
                curNode = curNode.Next;
            }
        }
    }

    public static class EventBus<T>
    {
        private static EventReceiverQueue<T> events
            = new EventReceiverQueue<T>();

        private static bool signedIn = false;

        public static void FireEvent(T t)
        {
            events.Fire(t);
        }

        public static void SignIn(Action<T> t)
        {
            if (!signedIn)
            {
                EventEngine.OnClear += () => { events.Clear(); signedIn = false; };
                signedIn = true;
            }
            events.Enqueue(0, t);
        }

        public static void SignIn(Action<T> t, int priority)
        {
            if (!signedIn)
            {
                EventEngine.OnClear += () => { events.Clear(); signedIn = false; };
                signedIn = true;
            }
            events.Enqueue(priority, t);
        }

        public static void SignOut(Action<T> t)
        {
            events.Dequeue(t);
        }
    }
}
