using UnityEngine;

namespace DefaultNamespace.Effect
{
    public class ExplodeEffect : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem explosion_particle; // particle for explosion
    
        [SerializeField]
        private int explosion_range_radius = 10; // at this range all rigidbodies will be affected and all damagables will be damaged

        [SerializeField]
        private int explosion_force = 20; // explosion force on rigid bodies

        [SerializeField]
        private int attack_value = 1; // damage on damagables


        public void Explode()
        {
            Instantiate(explosion_particle, transform.position, Quaternion.identity);

            foreach (Collider collider in Physics.OverlapSphere(transform.position, explosion_range_radius))
            {
                Rigidbody rigidbody_ = collider.GetComponent<Rigidbody>();
                if (rigidbody_)
                {
                    rigidbody_.AddExplosionForce(explosion_force, transform.position, explosion_range_radius);
                }


                IDamagable damagable = collider.gameObject.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.Deal(attack_value);
                }

            }
        }
    }
}