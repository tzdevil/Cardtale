using Cardtale.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cardtale.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<PlayerManager> players;
        [SerializeField] private int currentPlayer;
        [SerializeField] private int playersCount;

        private void Start()
        {
            players = FindObjectsOfType<PlayerManager>().ToList();
            playersCount = players.Count;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
                NextPlayer();
        }

        void NextPlayer()
        {
            currentPlayer = ++currentPlayer % playersCount;
            PlayerManager player = players[currentPlayer];
            CardtellEvents.OnStartTurn(player);
        }
    }
}