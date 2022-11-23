using Cardtale.Player;
using UnityEngine;

namespace Cardtale.Gameplay
{
    public class CardtellEvents : MonoBehaviour
    {
        public delegate void StartTurn(PlayerManager player); // yeni turn baþladýðýnda kimin turn'üyse o CardDraw(player) yapacak.
        public delegate void EndTurn(PlayerManager player); // Turn'i biten oyuncuyla çalýþacak
        public delegate void CardDraw(PlayerManager player); // player kart çekecek.

        public static event StartTurn onStartTurn;
        public static event EndTurn onEndTurn;
        public static event CardDraw onCardDraw;

        public static void OnStartTurn(PlayerManager player)
            => onStartTurn?.Invoke(player);

        public static void OnEndTurn(PlayerManager player)
            => onEndTurn?.Invoke(player);

        public static void OnCardDraw(PlayerManager player)
            => onCardDraw?.Invoke(player);
    }
}