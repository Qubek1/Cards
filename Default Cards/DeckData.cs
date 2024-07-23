using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards.Default
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DeckData")]
    public class DeckData : ScriptableObject
    {
        public bool aceValueIs14 = true;
        public List<CardSymbol> cardSymbols;
        public int jokersCount = 0;
        public CardSymbol jokerSymbol;
        public int jokerValue = 0;

        public List<DefaultCard> GenerateNewDeck()
        {
            List<DefaultCard> newDeck = new List<DefaultCard>();
            foreach (CardSymbol symbol in cardSymbols)
            {
                if (aceValueIs14)
                {
                    for (int i = 2; i <= 14; i++)
                    {
                        newDeck.Add(new DefaultCard(i, symbol));
                    }
                }
                else
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        newDeck.Add(new DefaultCard(i, symbol));
                    }
                }
            }
            for (int i = 0; i < jokersCount; i++)
            {
                newDeck.Add(new DefaultCard(jokerValue, jokerSymbol));
            }
            return newDeck;
        }
    }
}