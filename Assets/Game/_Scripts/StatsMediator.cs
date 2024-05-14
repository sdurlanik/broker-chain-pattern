using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDurlanik.BrokerChain
{
    public class BasicStatModifier : StatModifier
    {
        private readonly StatType _type;
        private readonly Func<int, int> operation;

        public BasicStatModifier(StatType type, float duration, Func<int, int> operation) : base(duration)
        {
            _type = type;
            this.operation = operation;
        }

        public override void Handle(object sender, Query query)
        {
            if (query.StatType == _type)
            {
                query.Value = operation(query.Value);
            }
        }
    }

    public class StatsMediator
    {
        private readonly LinkedList<StatModifier> _modifiers = new();

        public EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.AddLast(modifier);
            Queries += modifier.Handle;

            modifier.OnDispose += _ =>
            {
                _modifiers.Remove(modifier);
                Queries -= modifier.Handle;
            };
        }

        public void Update(float deltaTime)
        {
            var node = _modifiers.First;
            while (node != null)
            {
                var modifier = node.Value;
                modifier.Update(deltaTime);
                node = node.Next;
            }

            node = _modifiers.First;
            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.MarkedForRemoval)
                {
                    _modifiers.Remove(node);
                    node.Value.Dispose();
                }

                node = nextNode;
            }
        }
    }

    public class Query
    {
        public readonly StatType StatType;
        public int Value;

        public Query(StatType statType, int value)
        {
            StatType = statType;
            Value = value;
        }
    }
}