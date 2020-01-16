namespace Blockchain.Data
{
    public class Transaction
    {
        public string WalletFrom { get; set; }
        public string WalletTo { get; set; }
        public int Coins { get; set; }

        public string Sign { get; set; }

    }
}
