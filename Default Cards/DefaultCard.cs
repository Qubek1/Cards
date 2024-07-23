using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.Default
{
    [Serializable]
    public class DefaultCard
    {
        public int value;
        public CardSymbol symbol;

        public DefaultCard(int value, CardSymbol symbol)
        {
            this.value = value;
            this.symbol = symbol;
        }
    }
}