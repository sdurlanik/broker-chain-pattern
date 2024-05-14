using UnityEngine;

namespace SDurlanik.BrokerChain
{
    [CreateAssetMenu(fileName = "StatModifierData", menuName = "Stat Modifier Data")]
    public class StatModifierData : ScriptableObject
    {
        public StatType type = StatType.Attack;
        public StatModifierPickup.OperatorType operatorType = StatModifierPickup.OperatorType.Add;
        public int value = 10;
        public float duration = 5;
    }
}