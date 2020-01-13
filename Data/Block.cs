using System;

namespace Blockchain.Data
{
    public class MainingBlock
    {

        public EventHandler<string> HashChanged { get; set; }
        private int _blockNum;
        private int _nonce;
        private string _prevHash;
        private string _data;
        private readonly MainingBlock _prevBlock;

        public MainingBlock(MainingBlock prevBlock)
        {
            _prevBlock = prevBlock;
            if (_prevBlock != null)
            {
                _prevBlock.HashChanged += (sender, s) => PrevHash = s;
                PrevHash = _prevBlock.Hash;
            }
        }

        public int BlockNum
        {
            get => _blockNum;
            set
            {
                _blockNum = value;
                GetHash();
            }
        }



        public int Nonce
        {
            get => _nonce;
            set
            {
                _nonce = value;
                GetHash();
            }
        }

        public string PrevHash
        {
            get => _prevHash;
            set
            {
                _prevHash = value;
                GetHash();
            }
        }

        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                GetHash();
            }
        }


        public string Hash { get; set; }

        public void GetHash()
        {
            Hash = ShaService.GetSha(_blockNum + _data + _prevHash + _nonce);
            HashChanged?.Invoke(this, Hash);
        }

        public bool IsGood()
        {
            if (string.IsNullOrWhiteSpace(Hash))
                return false;

            return Hash.StartsWith("00000");
        }

        public void Mine()
        {
            Nonce = 0;
            while (!IsGood())
            {
                Nonce++;
            }
        }
    }
}