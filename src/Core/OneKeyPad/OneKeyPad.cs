using Mahamudra.Cryptography.OneKeyPad.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad
{
    public class OneKeyPad : IOneKeyPad
    {
        private readonly ILogger<OneKeyPad> _logger;
        private readonly Text _text;
        private VernamKey _key;
        private Cypher _cypher;
        public OneKeyPad(string text, string key, ILogger<OneKeyPad> logger = null)
        {
            this._logger = logger ?? NullLogger<OneKeyPad>.Instance;
            this._text = new Text(text);
            this._key = new VernamKey(key);
            this._logger = logger ?? NullLogger<OneKeyPad>.Instance;
        }

        public void Import(BitArray key)
        {
            this._key = new VernamKey(key);
            this._logger.LogInformation("Added new key");
        }

        public BitArray Export()
        {
            this._logger.LogInformation("Exported key");
            return _key.GetKeyBitArray();
        }

        public BitArray Cypher()
        {
            var t = _text.GetKeyBitArray();
            var c = t.Xor(_key.GetKeyBitArray());
            _cypher = new Cypher(c);
            return c;
        }

        public BitArray DeCypher(BitArray cypher)
        {
            var ab = _cypher.GetKeyBitArray();
            var t = _text.GetKeyBitArray();
            return ab.Xor(t);
        }
    }
}
