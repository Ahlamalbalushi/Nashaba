//-----------------------------------------------------------------------
// <copyright file="LocalPlayerController.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.CloudAnchors
{
    using UnityEngine;
    using UnityEngine.Networking;



    /// <summary>
    /// Local player controller. Handles the spawning of the networked Game Objects.
    /// </summary>
#pragma warning disable 618
    public class LocalPlayerController : NetworkBehaviour
#pragma warning restore 618
    {
        /// <summary>
        /// The Star model that will represent networked objects in the scene.
        /// </summary>
        public GameObject StarPrefab;

        /// <summary>
        /// The Anchor model that will represent the anchor in the scene.
        /// </summary>
        public GameObject AnchorPrefab;
        public GameObject nashabaBody;
        public GameObject holder;
        public static LocalPlayerController instance;

        [SyncVar] public int PlayerOnescore;
        [SyncVar] public int PlayerTwocore;
        //public NetworkInstanceId netId { get; }

        bool isHost = false;




        //public bool isObjectCreated = false;

        /// <summary>
        /// The Unity OnStartLocalPlayer() method.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            // A Name is provided to the Game Object so it can be found by other Scripts, since this is instantiated as
            // a prefab in the scene.
            gameObject.name = "LocalPlayer";

            print("My ID: " + playerControllerId);
        }

        void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            print("My ID: " + playerControllerId);

            print("Number of Player Controllers: " + NetworkManager.singleton.client.connection.playerControllers.Count);
            foreach (var item in NetworkManager.singleton.client.connection.playerControllers)
            {
                print("Player Controller ID: " + item.playerControllerId);
            }
            // score
            NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();

            print("NetID: " + networkIdentity.netId);
            print("Player ID: " + networkIdentity.playerControllerId);
            if (networkIdentity.netId.Value == 1)
                isHost = true;
            else
            {
                isHost = false;
            }
        }

        /// <summary>
        /// Will spawn the origin anchor and host the Cloud Anchor. Must be called by the host.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
        /// <param name="anchor">The ARCore Anchor to be hosted.</param>
        public void SpawnAnchor(Vector3 position, Quaternion rotation, Component anchor)
        {
            // Instantiate Anchor model at the hit pose.
            var anchorObject = Instantiate(AnchorPrefab, position, rotation);
            //isObjectCreated = true;



            // Anchor must be hosted in the device.
            anchorObject.GetComponent<AnchorController>().HostLastPlacedAnchor(anchor);



            // Host can spawn directly without using a Command because the server is running in this instance.
#pragma warning disable 618
            NetworkServer.Spawn(anchorObject);
            //NetworkServer.Spawn(nashabaObject);
            //NetworkServer.Spawn(anchorObject);\



            //NetworkServer.connections[0].
#pragma warning restore 618
        }

        /// <summary>
        /// A command run on the server that will spawn the Star prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnStar(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
            var starObject = Instantiate(StarPrefab, position, rotation);

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject);
#pragma warning restore 618
        }

#pragma warning disable 618
        [Command]
#pragma warning restore 618

        public void CmdDestroyCube(GameObject obj)
        {

#pragma warning disable 618
            NetworkServer.Destroy(obj);
          
            if (isHost)
            {
                PlayerOnescore++;

            }
            else
            {
                PlayerTwocore++;
            }


#pragma warning restore 618

        }


    }
}
