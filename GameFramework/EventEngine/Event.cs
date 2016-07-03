using System;

namespace GameFramework
{
    public interface IEvent
    {
        void Fire();
    }

    public class Event<T> : BaseSignal<Enum>, IEvent where T : class, IEvent
    {
        private Signal signal;

        public Event()
        {
            signal = Signal.Instance;
        }

        public void Fire()
        {
            EventEngine.Fire(this as T);
        }

        public override void Fire<T1>(T1 header)
        {
            signal.Fire(header);
            EventEngine.Fire(this as T);
        }
    }
}
