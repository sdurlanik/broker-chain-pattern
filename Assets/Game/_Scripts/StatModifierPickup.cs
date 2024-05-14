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

        [SerializeField] private StatModifierData data;

        protected override void ApplyPickupEffect(Entity entity)
        {
            StatModifier modifier = data.operatorType switch
            {
                OperatorType.Add => new BasicStatModifier(data.type, data.duration, x => x + data.value),
                OperatorType.Multiply => new BasicStatModifier(data.type, data.duration, x => x * data.value),
                _ => throw new System.ArgumentOutOfRangeException()
            };

            entity.Stats.Mediator.AddModifier(modifier);

            Debug.Log(entity.Stats.ToString());
            modifier.OnDispose += _ => Debug.Log(entity.Stats.ToString());
        }
    }
}