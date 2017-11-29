using System.Collections;
using UnityEngine;

namespace Collidables
{
    public interface Collidable 
    {
        int pointImpact { get; }
        ScoreController scoreController { get; set; }

        // void OnCollisionEnter(Collision other);

        IEnumerator Reaction();

    }
} 