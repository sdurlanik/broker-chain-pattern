using System;
using UnityEngine;

namespace SDurlanik.BrokerChain
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit<T>(T visitable) where T : Component, IVisitable;
    }

    public abstract class Entity : MonoBehaviour, IVisitable
    {
        [SerializeField] BaseStats baseStats;
        public Stats Stats { get; private set; }

        private void Awake()
        {
            Stats = new Stats(new StatsMediator(), baseStats);
            Debug.Log(Stats.ToString());
        }

        public void Update()
        {
            Stats.Mediator.Update(Time.deltaTime);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}