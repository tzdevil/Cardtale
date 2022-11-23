using Cardtale.Gameplay;
using UnityEngine;

namespace Cardtale.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private void OnEnable()
        {
            CardtellEvents.onStartTurn += StartTurn;
        }

        private void OnDisable()
        {
            CardtellEvents.onStartTurn -= StartTurn;
        }

        void StartTurn(PlayerManager player)
        {
            print($"{gameObject.name} - It's {(player == this ? "your" : $"{player}'s")} turn.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CardtellEvents.OnStartTurn(this);
            }
        }
    }
}