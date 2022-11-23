using Cardtale.Network;
using Fusion;
using TMPro;
using UnityEngine;

namespace Cardtale.Player
{
    public class PlayerNetworkManager : NetworkBehaviour
    {
        [Networked(OnChanged = nameof(OnChangeAnotherNum))] public float AnotherNum { get; set; }
        [SerializeField] private TMP_Text _anotherNumText;

        public override void Spawned()
        {
            print("hey");
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                if (data.NumUp)
                {
                    AnotherNum++;
                    WillThisInvokeOnTheOwner();
                }
            }
        }

        private void Update()
        {
            if (Object.HasInputAuthority && Input.GetKeyDown(KeyCode.M))
                RPC_DoShit("slm");
        }

        private static void OnChangeAnotherNum(Changed<PlayerNetworkManager> changed)
        {

            changed.Behaviour._anotherNumText.SetText(changed.Behaviour.AnotherNum.ToString());
            print(changed.Behaviour.name);
        }

        private void WillThisInvokeOnTheOwner()
        {
            print("heyL");
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_DoShit(string message, RpcInfo info = default)
        {
            if (info.IsInvokeLocal)
                print($"you, {gameObject.name}: {message}");
            else
                print($"them, {gameObject.name}: {message}");
        }
    }
}
