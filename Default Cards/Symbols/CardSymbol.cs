using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.Default
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Card Symbol")]
    public class CardSymbol : ScriptableObject
    {
        public Sprite image;
        public Color color;
    }
}