using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventureTogether
{
    public class Party : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);
        }

        public List<Character> Characters;
        public bool IsDefeated() => Characters.All(c => c.IsDefeated());
    }

}
