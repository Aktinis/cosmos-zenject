using Cosmos.Data;
using Cosmos.Gameplay;
using Cosmos.Gameplay.Providers;
using Cosmos.Signals;
using UnityEngine;
using Zenject;

namespace Cosmos.Player
{
    internal sealed class PlayerController : IPositionProvider, IRotationProvider, ITickable, IInvincibilityProvider
    {
        private readonly BoundsHandler boundsHandler = null;
        private readonly InvincibilityHandler invincibilityHandler = null;
        private readonly WeaponManager weaponManager = null;
        private readonly SignalBus signalBus = null;

        private IPawn pawn = null;
        private IHealthProvider healthRef = null;
        private bool hasPawn = false;
        private bool hasWeapon = false;
        private float fireTime = 0f;
        private BulletData bulletData = null;
        private int instancedId = -1;

        public Vector3 Position
        {
            get
            {
                if (hasPawn)
                {
                    return pawn.Position;
                }
                return Vector3.zero;
            }
            set
            {
                if (hasPawn)
                {
                    pawn.Position = value;
                }
            }
        }
        public Quaternion Rotation 
        { 
            get
            {
                if(hasPawn)
                {
                    return pawn.Rotation;
                }
                return Quaternion.identity;
            }
            set
            {
                if (hasPawn)
                {
                    pawn.Rotation = value;
                }
            }

        }

        public PlayerController(BoundsHandler boundsHandler, InvincibilityHandler invincibilityHandler, WeaponManager weaponManager, SignalBus signalBus)
        {
            this.weaponManager = weaponManager;
            this.signalBus = signalBus;
            this.invincibilityHandler = invincibilityHandler;
            this.boundsHandler = boundsHandler;
        }
        
        public void Possess(IPawn pawn)
        {
            this.pawn = pawn;
            if (pawn is IHealthProvider health)
            {
                healthRef = health;
            }
            if(pawn is IDamageProvider damage)
            {
                ((IDamageProvider)pawn).OnTakeDamage = OnTakeDamage;
            }
            if(pawn is Transform transform)
            {
                instancedId = transform.gameObject.GetInstanceID();
            }
            hasPawn = true;
        }
        public void AddWeapon(BulletData bulletData)
        {
            this.bulletData = bulletData;
            hasWeapon = true;
        }
        public bool IsAlive()
        {
            if(hasPawn && healthRef != null)
            {
                return healthRef.IsAlive;
            }
            return false;
        }
        public void Tick()
        {
            if(hasPawn && healthRef.IsAlive)
            {
                boundsHandler.UpdatePosition(this);
                HandleControls();
            }
        }
        public void ToggleInvincibility(bool state)
        {
            if(hasPawn)
            {
                pawn.ToggleCollision(state);
            }
        }
        public void Fire()
        {
            if (hasWeapon && Time.realtimeSinceStartup - fireTime > bulletData.Cooldown)
            {
                fireTime = Time.realtimeSinceStartup;
                weaponManager.Fire(bulletData.Id, instancedId, pawn.Position, pawn.Rotation);
            }
        }
        private void HandleControls()
        {
            var direction = 0;
            var useThrust = false;
            if (Input.GetKey(KeyCode.W))
            {
                useThrust = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction = 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction = -1;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                boundsHandler.Teleport(pawn);
            }

            pawn.Rotate(direction);
            pawn.Thrust(useThrust);
        }
        private void OnTakeDamage(int id)
        {
            signalBus.Fire(new PlayerHealthChangedSignal(healthRef.Health));
            invincibilityHandler.UpdateInvincibility(this);
        }
    }
}
