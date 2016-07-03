using System;
using System.Collections.Generic;

namespace GameFramework
{
    public class SignalReceiverQueue : PriorityQueue<EventWrapper>
    {
        public void Fire()
        {
            LinkedListNode<PriorityNode<EventWrapper>> curNode;
            curNode = list.Last;

            while (curNode != null)
            {
                curNode.Value.value.Fire();
                curNode = curNode.Previous;
            }
        }

        public void Enqueue(int prio, Action method)
        {
            PriorityNode<EventWrapper> node = GetNode(prio);
            if (node != null)
            {
                node.value.Register(method);
                return;
            }
            Enqueue(new PriorityNode<EventWrapper>(prio, new EventWrapper(method)));
        }

        public void Dequeue(Action method)
        {
            LinkedListNode<PriorityNode<EventWrapper>> curNode;
            curNode = list.First;

            while (curNode != null)
            {
                curNode.Value.value.UnRegister(method);
                curNode = curNode.Next;
            }
        }
    }

    public class EventWrapper
    {
        public event Action OnSignal = () => { };

        public EventWrapper(Action method)
        {
            OnSignal += method;
        }

        public void Fire()
        {
            OnSignal();
        }

        public void Register(Action method)
        {
            OnSignal -= method;
            OnSignal += method;
        }

        public void UnRegister(Action method)
        {
            OnSignal -= method;
        }
    }


    public static class SignalBus<T>
    {
        private static bool initialized = false;

        static Dictionary<T, SignalReceiverQueue> signalReceivers
            = new Dictionary<T, SignalReceiverQueue>();

        public static void SignIn(T header, Action method , int priority)
        {
            if (!initialized)
            {
                initialized = true;

                EventEngine.OnClear +=
                    () => { initialized = false; signalReceivers = new Dictionary<T, SignalReceiverQueue>(); };
            }
            if (!signalReceivers.ContainsKey(header))
            {
                signalReceivers[header] = new SignalReceiverQueue();
            }

            signalReceivers[header].Enqueue(priority, method);
        }

        public static void SignOut(T header, Action method)
        {
            if (signalReceivers.ContainsKey(header))
            {
                signalReceivers[header].Dequeue(method);
            }
        }

        public static void Fire(T header)
        {
            if (signalReceivers.ContainsKey(header))
            {
                signalReceivers[header].Fire();
            }
        }
    }

    public class Signal : BaseSignal<Enum>
    {
        public static Signal Instance
        {
            get
            {
                return Singleton<Signal>.Instace;
            }
        }

        public override void SignIn<T1>(T1 header, Action method)
        {
            SignalBus<T1>.SignIn(header, method, 0);
        }

        public override void SignIn<T1>(T1 header, Action method, int priority)
        {
            SignalBus<T1>.SignIn(header, method, priority);
        }

        public override void SignOut<T1>(T1 header, Action method)
        {
            SignalBus<T1>.SignOut(header, method);
        }

        public override void Fire<T1>(T1 header)
        {
            SignalBus<T1>.Fire(header);
        }
    }

    public class BaseSignal<T>
    {
        public virtual void SignIn<T1>(T1 header, Action method) where T1 : T
        {

        }

        public virtual void SignIn<T1>(T1 header, Action method, int priority) where T1 : T
        {

        }

        public virtual void SignOut<T1>(T1 header, Action method) where T1 : T
        {

        }

        public virtual void Fire<T1>(T1 header) where T1 : T
        {

        }
    }
}
