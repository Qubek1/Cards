using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cards.Default;

namespace Cards
{
    public class CardsTests : MonoBehaviour
    {
        public DeckData deckData;

        // Start is called before the first frame update
        void Start()
        {
            StresGameModel gameModel = new StresGameModel();
            gameModel.deckData = deckData;
            gameModel.StartGame();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}