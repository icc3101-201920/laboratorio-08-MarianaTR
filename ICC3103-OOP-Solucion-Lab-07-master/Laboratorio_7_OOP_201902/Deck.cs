using Laboratorio_7_OOP_201902.Cards;
using Laboratorio_7_OOP_201902.Enums;
using Laboratorio_7_OOP_201902.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_7_OOP_201902
{
    [Serializable]
    public class Deck : ICharacteristics
    {

        private List<Card> cards;

        public Deck()
        {
        
        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        public void DestroyCard(int cardId)
        {
            cards.RemoveAt(cardId);
        }

        public List<string> GetCharacteristics()
        {
            List<string> cartas = new List<string>();

            string totalDeCard = Convert.ToString(cards.Count());  //Retorna cuantas cartas hay

            IEnumerable<Card> totalCartasMelee =                 // Buscamos en la lista de cartas el numero de cartas melee
                from card in cards
                where card.Type == EnumType.melee
                select card;

            IEnumerable<CombatCard> cardMelee =                    //Del mazo de cartas de melee convertirlas a combat para poder acceder a los puntos, igual para la de range y longRange
                from card in totalCartasMelee
                select card as CombatCard;

            IEnumerable<int> totalAttackPonitsMelee =
                from card in cardMelee
                select card.AttackPoints;
                

            IEnumerable < Card > totalCartasRange =                 // Buscamos en la lista de cartas el numero de cartas range
                from card in cards
                where card.Type == EnumType.range
                select card;

            IEnumerable<CombatCard> cardRange =
                from card in totalCartasRange
                select card as CombatCard;

            IEnumerable<int> totalAttackPonitsRange =
                from card in cardRange
                select card.AttackPoints;

            IEnumerable<Card> totalCartasLongRange =                 // Buscamos en la lista de cartas el numero de cartas longRange
                from card in cards
                where card.Type == EnumType.longRange
                select card;

            IEnumerable<CombatCard> cardLongRange =
                from card in totalCartasLongRange
                select card as CombatCard;

            IEnumerable<int> totalAttackPonitsLongRange =
                from card in cardLongRange
                select card.AttackPoints;

            IEnumerable<Card> totalCartasBuff =                 // Buscamos en la lista de cartas el numero de cartas buff
                from card in cards
                where card.Type == EnumType.buff
                select card;

            IEnumerable<Card> totalCartasWeather =                 // Buscamos en la lista de cartas el numero de cartas weather
                from card in cards
                where card.Type == EnumType.weather
                select card;

            string totalAttackPoints = Convert.ToString(totalAttackPonitsLongRange.Sum() + totalAttackPonitsMelee.Sum() + totalAttackPonitsRange.Sum());

            cartas.Add(Convert.ToString(totalCartasMelee.Count()));
            cartas.Add(Convert.ToString(totalAttackPonitsMelee.Sum()));
            cartas.Add(Convert.ToString(totalCartasRange.Count()));
            cartas.Add(Convert.ToString(totalAttackPonitsRange.Sum()));
            cartas.Add(Convert.ToString(totalCartasLongRange.Count()));
            cartas.Add(Convert.ToString(totalAttackPonitsLongRange.Sum()));
            cartas.Add(Convert.ToString(totalAttackPoints));
            cartas.Add(Convert.ToString(totalCartasBuff.Count()));
            cartas.Add(Convert.ToString(totalCartasWeather.Count()));

            return cartas;

        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

    }
}
