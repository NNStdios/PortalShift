using System.Collections.Generic;
using UnityEngine;

namespace Portals
{
    public class PortalScript : MonoBehaviour
    {
        private Quaternion _rotationDelta;
        private Vector3 _positionDelta;
        [HideInInspector] public List<GameObject> TeleportedObjects = new();
        
        [SerializeField] private PortalScript _correspondingPortal;

        [Header("Particles")]
        [SerializeField] private ParticleSystem _mainParticles;
        [SerializeField] private ParticleSystem _trailParticles;
        [SerializeField] private ParticleSystem _ribbonParticles;
        [SerializeField] private ParticleSystem _activationParticles;
        

        private void Start()
        {
            var tr = transform;
            var ctr = _correspondingPortal.transform;

            _positionDelta = ctr.transform.localPosition - tr.localPosition;
            _rotationDelta = Quaternion.AngleAxis(Quaternion.Angle(tr.localRotation, ctr.localRotation), Vector3.forward);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Portal")) return;
            if (!other.TryGetComponent<Rigidbody2D>(out _)) return;
            if (TeleportedObjects.Contains(other.gameObject)) return;
            
            _correspondingPortal.TeleportedObjects.Add(other.gameObject);
            _correspondingPortal._activationParticles.Play();
            
            var otr = other.transform;
            otr.localPosition += _positionDelta;
            otr.localRotation *= _rotationDelta;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Portal")) return;
            if (TeleportedObjects.Contains(other.gameObject))
                TeleportedObjects.Remove(other.gameObject);
        }
    }
}
