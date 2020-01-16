using System.Collections.Generic;
using Blockchain.Pages;

namespace Blockchain.Data
{
    public class Peer
    {
        public Wallet Wallet { get; set; }

        public List<Block> Blocks { get; set; }

        public Peer(string name)
        {

            Wallet = new Wallet();
            Wallet.ReadName = name;
            Blocks = new List<Block>();

        }
        
    }
}