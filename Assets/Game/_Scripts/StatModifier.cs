using System;

namespace SDurlanik.BrokerChain
{
    public abstract class StatModifier : IDisposable
    {
        public bool MarkedForRemoval { get; private set; }
        public event Action<StatModifier> OnDispose = delegate { };
        public abstract void Handle(object sender, Query query);
        readonly CountdownTimer _timer;

        protected StatModifier(float duration)
        {
            if (duration <= 0) return;

            _timer = new CountdownTimer(duration);
            _timer.OnTimerStop += () => MarkedForRemoval = true;
            _timer.Start();
        }

        public void Update(float deltaTime)
        {
            _timer?.Tick(deltaTime);
        }

        public void Dispose()
        {
            OnDispose?.Invoke(this);
        }
    }
}