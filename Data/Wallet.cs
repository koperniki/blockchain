

using System;
using Nethereum.Signer;

namespace Blockchain.Data
{
    public class Wallet
    {
      
        public string PublicKey { get; set; }
        public string ReadName { get; set; }

        public string PrivateKey { get; set; }

        public int InitialCoin { get; set; }



        public Wallet()
        {
            var ecKey = EthECKey.GenerateKey();
            PublicKey = ecKey.GetPublicAddress();
            PrivateKey = ecKey.GetPrivateKey();
        }


        public string SignData(string data)
        {
            var signer = new MessageSigner();
            var signature = signer.HashAndSign(data, PrivateKey);

            return signature;
        }


        public static string SignData(string data, string privateKey)
        {
            if (data == null || privateKey == null) return null;
            var signer = new MessageSigner();
            try
            {

                var signature = signer.HashAndSign(data, privateKey);
                return signature;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static bool Verify(string message, string signature, string publicKey)
        {
            var signer = new MessageSigner();
            try
            {
                var key = signer.HashAndEcRecover(message, signature);
                return key == publicKey;
            }
            catch (Exception e)
            {
                return false;
            }
          
        }
    }
}