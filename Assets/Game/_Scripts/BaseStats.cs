using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDurlanik.BrokerChain
{
    [CreateAssetMenu(fileName = "BaseStats", menuName = "Base Stats")]
    public class BaseStats : ScriptableObject
    {
        public int attack = 10;
        public int defense = 5;
    }
}