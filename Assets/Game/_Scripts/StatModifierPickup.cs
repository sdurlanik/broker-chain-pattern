using UnityEngine;

namespace SDurlanik.BrokerChain
{
    public class StatModifierPickup : Pickup
    {
        public enum OperatorType
        {
            Add,
            Multiply
        }

        [SerializeField] private StatType type = StatType.Attack;
        [SerializeField] private OperatorType operatorType = OperatorType.Add;
        [SerializeField] private int value = 10;
        [SerializeField] private float duration = 5;

        protected override void ApplyPickupEffect(Entity entity)
        {
            StatModifier modifier = operatorType switch
            {
                OperatorType.Add => new BasicStatModifier(type, duration, x => x + value),
                OperatorType.Multiply => new BasicStatModifier(type, duration, x => x * value),
                _ => throw new System.ArgumentOutOfRangeException()
            };

            entity.Stats.Mediator.AddModifier(modifier);
        }
    }
}