using UnityEngine;

namespace Collidables
{
    public interface Collidable 
    {
        int pointImpact { get; }

        void OnTriggerEnter(Collider col);
        
    }
}