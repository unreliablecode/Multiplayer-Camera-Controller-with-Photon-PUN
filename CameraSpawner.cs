using UnityEngine;
using Photon.Pun;

public class CameraSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // Assign your player prefab here
    public GameObject cameraPrefab; // Assign your camera prefab here

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("SpawnCamera", newPlayer);
        }
    }

    [PunRPC]
    private void SpawnCamera()
    {
        GameObject cameraObject = Instantiate(cameraPrefab);
        CameraController cameraController = cameraObject.GetComponent<CameraController>();
        cameraController.AssignPlayer(PhotonNetwork.LocalPlayer);
    }
}
