namespace GameFramework
{
    public class DataEvent<T, DataType> : Event<T> where T : class, IEvent
    {
        public DataType data;

        public DataEvent(DataType data)
        {
            this.data = data;
        }
    }
}
