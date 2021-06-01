using MLAPI;

public class Player : NetworkBehaviour
{
    public Unit unitPrefab;

    public override void NetworkStart()
    {
        if (!IsServer)
        {
            enabled = false;
            return;
        }

        var unit = Instantiate(unitPrefab);
        var networkObject = unit.GetComponent<NetworkObject>();
        if (!networkObject.IsSpawned)
            networkObject.Spawn();
    }
}