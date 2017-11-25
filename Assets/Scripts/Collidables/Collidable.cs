using UnityEngine;

// maybe be better to turn this into an abstract class for point management
namespace Collidables
{
    public interface Collidable 
    {
        int pointImpact { get; }

        void OnCollisionEnter(Collision other);

    }
} 