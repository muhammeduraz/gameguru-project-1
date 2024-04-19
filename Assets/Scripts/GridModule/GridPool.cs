using Zenject;

namespace Assets.Scripts.GridModule
{
    public class GridPool : MonoMemoryPool<Grid>
    {
        protected override void OnCreated(Grid item)
        {
            base.OnCreated(item);
        }

        protected override void OnDestroyed(Grid item)
        {
            base.OnDestroyed(item);
        }

        protected override void OnSpawned(Grid item)
        {
            base.OnSpawned(item);
        }

        protected override void OnDespawned(Grid item)
        {
            base.OnDespawned(item);
        }

        protected override void Reinitialize(Grid item)
        {
            base.Reinitialize(item);
        }
    }
}