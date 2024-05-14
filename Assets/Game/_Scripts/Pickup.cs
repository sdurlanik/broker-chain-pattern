using UnityEngine;

namespace SDurlanik.BrokerChain
{
    public abstract class Pickup : MonoBehaviour, IVisitor
    {
        protected abstract void ApplyPickupEffect(Entity entity);

        public void Visit<T>(T visitable) where T : Component, IVisitable
        {
            if (visitable is Entity entity)
            {
                ApplyPickupEffect(entity);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IVisitable visitable))
            {
                Debug.Log($"Pickup collected: {gameObject.name}");
                visitable.Accept(this);
                Destroy(gameObject);
            }
        }
    }
}