namespace DefaultNamespace.Projectiles.Components.ComponentData
{
    public class ExplodeData: ComponentData
    {
        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(ProjectileExplode);
        }
    }
}