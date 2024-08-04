using System;
using Photon.Pun;
using UnityEngine;

namespace Client.Code
{
    public class PhotonTest : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        private void OnGUI()
        {
            if(GUI.Button(new Rect(10,10,100,30),"JoinRandomRoom")) 
                JoinRoom();
            
            if(GUI.Button(new Rect(10,40,100,30),"CreateRoom")) 
                CreateRoom();
        }

        public override void OnConnectedToMaster()
        {
            UnityEngine.Debug.Log("OnConnectedToMaster");
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null);
        }
        
        public void JoinRoom()
        {
            PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.LoadLevel("Hub");
        }

        public override void OnJoinedRoom()
        {
            UnityEngine.Debug.Log("OnJoinedRoom");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            UnityEngine.Debug.Log("OnJoinRoomFailed");
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
        }
    }
}