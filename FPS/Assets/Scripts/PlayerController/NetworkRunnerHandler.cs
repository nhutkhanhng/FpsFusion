using Fusion;
using Fusion.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class NetworkRunnerHandler : MonoBehaviour
{
    [SerializeField] protected NetworkRunner networkRunnerPrefab;

    public NetworkRunner networkRunner;

    // Start is called before the first frame update
    void Start()
    {
        networkRunner = Instantiate(networkRunnerPrefab);
        networkRunner.name = "Network runner";

    }

    
    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef sceneRef,System.Action<NetworkRunner> initialized)
    {
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if (sceneManager == null)
        {
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }


        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = sceneRef,
            SessionName = "TestR",
            Initialized = initialized,
            SceneManager = sceneManager
        });
    }
}
