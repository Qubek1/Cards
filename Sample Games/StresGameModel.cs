using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Cards;
using Cards.Default;

public class StresGameModel
{
    public int playerCount;
    public int decksCount;
    public int stacksCount;
    public int cardsInHandCount;
    public List<List<DefaultCard>> playersDecks;
    public List<DefaultCard[]> playersHands;
    public List<Stack<DefaultCard>> stacks;
    public DeckData deckData;

    List<DefaultCard> cards;

    public StresGameModel() 
    {
        playerCount = 2;
        decksCount = 2;
        stacksCount = 2;
        cardsInHandCount = 4;
    }

    public StresGameModel(DeckData deckData) : this()
    {
        this.deckData = deckData;
    }

    public StresGameModel(DeckData deckData, int playerCount, int decksCount, int stacksCount, int cardsInHandCount)
    {
        this.deckData = deckData;
        this.playerCount = playerCount;
        this.decksCount = decksCount;
        this.stacksCount = stacksCount;
        this.cardsInHandCount = cardsInHandCount;
    }

    public void StartGame()
    {
        cards = new List<DefaultCard>();
        for (int i = 0; i < decksCount; i++)
        {
            cards.AddRange(deckData.GenerateNewDeck());
        }
        cards.Shuffle();
        int cardsCount = cards.Count;

        playersDecks = new List<List<DefaultCard>>();
        for (int i = 0; i < playerCount; i++)
        {
            List<DefaultCard> playersCards = cards.GetRange(Mathf.Max(cards.Count - cardsCount / playerCount, 0), cardsCount / playerCount);
            playersDecks.Add(playersCards);
            cards.RemoveRange(Mathf.Max(cards.Count - cardsCount / playerCount, 0), cardsCount / playerCount);
            playersHands.Add(new DefaultCard[cardsInHandCount]);
        }
    }

    public void MakeMove(int cardInHandIndex, int playerIndex, int stackIndex)
    {
        int stackValue = stacks[stackIndex].Peek().value;
        stacks[stackIndex].Push(playersHands[playerIndex][cardInHandIndex]);
        playersHands[playerIndex][cardInHandIndex] = null;
        DrawCard(playerIndex);
    }

    private void DrawCard(int playerIndex)
    {
        if (playersDecks[playerIndex].Count == 0)
        {
            return;
        }
        DefaultCard card = playersDecks[playerIndex].Peek();
        playersDecks[playerIndex].Remove(card);
        bool foundEmptySpot = false;
        for (int i = 0; i < cardsInHandCount; i++)
        {
            if (playersHands[playerIndex][i] == null)
            {
                playersHands[playerIndex][i] = card;
                foundEmptySpot = true;
                break;
            }
        }
        if (!foundEmptySpot)
        {
            throw new Exception("Player tried to draw with a full hand");
        }
    }
}
