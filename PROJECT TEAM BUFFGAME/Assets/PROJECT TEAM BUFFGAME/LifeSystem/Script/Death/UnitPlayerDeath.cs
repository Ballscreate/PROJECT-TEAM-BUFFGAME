using Mirror;

public class UnitPlayerDeath : UnitDeath
{
    [Server]
    protected override void DeathLogic()
    {
        RcpDeathLogic();
        NetworkServer.Destroy(gameObject.GetComponentInParent<NetworkIdentity>().gameObject);
        OnDeath?.Invoke();   
    }

    [TargetRpc]
    public void RcpDeathLogic()
    {
        DeathLogic();
    }
}
