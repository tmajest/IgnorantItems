using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CoffeeCat.RiotCommon.Utils
{
    /// <summary>
    /// Class to manage a thread safe collection of keys.
    ///
    /// Accessing the next key will add it to the end of the collection.  The
    /// cycling of the keys will help prevent hitting the rate limit for the
    /// Riot APIs.
    /// </summary>
    public class KeyManager
    {
        private BlockingCollection<string> keys;

        /// <summary>
        /// Get the next available key.
        /// </summary>
        public string NextKey
        {
            get
            {
                var key = this.keys.Take();
                this.keys.Add(key);
                return key;
            }
        }

        /// <summary>
        /// Create a new KeyManager from the list of keys.
        /// </summary>
        /// <param name="keys">The keys to manage.</param>
        public KeyManager(IEnumerable<string> keys)
        {
            Validation.ValidateNotNull(keys, nameof(keys)); 

            this.keys = new BlockingCollection<string>();
            foreach (var key in keys)
            {
                Validation.ValidateNotNullOrWhitespace(key, nameof(key));
                this.keys.Add(key);
            }
        }
    }
}
