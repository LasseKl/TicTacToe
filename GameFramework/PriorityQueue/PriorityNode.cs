namespace GameFramework
{
    public class PriorityNode<T>
    {
        public T value;
        public int prio;

        public PriorityNode(int prio, T val)
        {
            this.prio = prio;
            this.value = val;
        }
    }
}
