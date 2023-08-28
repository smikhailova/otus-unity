using System.Collections.Generic;
using UnityEngine;

public class BloodSplatSpawner : MonoBehaviour
{
    public ParticleSystem bloodDropSystem;
    public List<ParticleCollisionEvent> collisionEvents = new();

    [SerializeField]
    private GameObject bloodSplat;


    private void Start()
    {
        bloodDropSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = bloodDropSystem.GetCollisionEvents(other, collisionEvents);

        int i = 0;

        while (i < numCollisionEvents)
        {
            Vector3 pos = collisionEvents[i].intersection - collisionEvents[i].normal * Random.Range(.3f, .7f);
            pos.y = 1.63f;
            Instantiate(bloodSplat, pos, Quaternion.identity);
            i++;
        }
    }
}
