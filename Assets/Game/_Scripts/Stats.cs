namespace SDurlanik.BrokerChain
{
    public enum StatType
    {
        Attack,
        Defense
    }

    public class Stats
    {
        private readonly StatsMediator _mediator;
        private readonly BaseStats _baseStats;

        public StatsMediator Mediator => _mediator;

        public int Attack
        {
            get
            {
                var query = new Query(StatType.Attack, _baseStats.attack);
                _mediator.PerformQuery(this, query);
                return query.Value;
            }
        }

        public int Defense
        {
            get
            {
                var query = new Query(StatType.Defense, _baseStats.defense);
                _mediator.PerformQuery(this, query);
                return query.Value;
            }
        }

        public Stats(StatsMediator mediator, BaseStats baseStats)
        {
            _mediator = mediator;
            _baseStats = baseStats;
        }

        public override string ToString()
        {
            return $"Attack: {Attack}, Defense: {Defense}";
        }
    }
}