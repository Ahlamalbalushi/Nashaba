namespace GoogleARCore.Examples.Common
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    /// <summary>
    /// Our code
    /// </summary>
    public class DetectedPlaneGenerator : MonoBehaviour
    {


        public Text LevelNumberNow;
      //  public Button Re_Game;



        /// <summary>
        /// these varibles for generating Plane
        /// </summary>

        // A prefab for tracking and visualizing detected planes.
        public GameObject DetectedPlanePrefab;


        // A list to hold new planes ARCore began tracking in the current frame. This object is used across the application to avoid per-frame allocations.
        private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();

        // get transform of new plane.
        public Vector3 newplanePosition;

        //  detect if plane generatted
        //public bool isPlaneDetected;


        GameObject planeObject;
        /// <summary>
        /// these varibles for creating game boxes
        /// </summary>


        /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
        public Camera FirstPersonCamera;


        /// A model to place when a raycast from a user touch hits a plane.
        public GameObject AndyPlanePrefab;
        public GameObject AndyPlanePrefab2;
        public GameObject AndyPlanePrefab3;

        public int IsCreate = 1;


        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        private bool m_IsQuitting = false;

        /// to create game boxes one Time
        public bool isCreatedOnce;

        /// plana will  despear after 5 seconds from craetion
        float planaTimer = 5;

        /// Get access to nashaba script
        public threedNashaba NashabaScript;


         void Start()
        {
           // Re_Game.onClick.AddListener(Re_Game_Again);

        }



        void Re_Game_Again()
        {
           // SceneManager.LoadScene("Game");

            //Update();

        }


        void Update()
        {

            _UpdateApplicationLifecycle();

            // Check that motion tracking is tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            // Iterate over planes found in this frame and instantiate corresponding GameObjects to visualize them.
            Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);

            if (m_NewPlanes.Count > 0 && !isCreatedOnce)
            {
                // Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
                // the origin with an identity rotation since the mesh for our prefab is updated in Unity World coordinates.

                planeObject = Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
                planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[0]);
                
                //creating prefab
                GameObject prefab;




                if (Levels.LevelNumber == 1)
                {
                    if (IsCreate <= 1)
                    {
                        prefab = AndyPlanePrefab;
                        var andyObject = Instantiate(prefab, planeObject.GetComponent<DetectedPlaneVisualizer>().PlaneCenter, Quaternion.identity);
                       
                    }
                }
                else if (Levels.LevelNumber == 2)
                {
                    if (IsCreate <= 1)
                    {
                        prefab = AndyPlanePrefab2;
                        var andyObject = Instantiate(prefab, planeObject.GetComponent<DetectedPlaneVisualizer>().PlaneCenter, Quaternion.identity);

                    }
                }
                else if (Levels.LevelNumber == 3)
                {
                    if (IsCreate <= 1)
                    {
                        prefab = AndyPlanePrefab3;
                        var andyObject = Instantiate(prefab, planeObject.GetComponent<DetectedPlaneVisualizer>().PlaneCenter, Quaternion.identity);

                    }
                }


                LevelNumberNow.text = Levels.LevelNumber.ToString();



               //setting the prefab  
               //  prefab = AndyPlanePrefab;
               // craete the game boxes
               //   var andyObject = Instantiate(prefab, planeObject.GetComponent<DetectedPlaneVisualizer>().PlaneCenter, Quaternion.identity);
               isCreatedOnce = true;
                /// calling setPlayer function from Nashaba script
                NashabaScript.setShooter();



            }

            if (isCreatedOnce && planeObject.activeSelf)
            {
                // timer starts
                planaTimer -= Time.deltaTime;

                if (planaTimer < 0)
                {
                    // plana will dispear after 5 seconds
                    planeObject.SetActive(false);
                }
            }

           
        }

        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }


        /// <summary>
        /// Actually quit the application.
        /// </summary>
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show an Android toast message.
        /// </summary>
        /// <param name="message">Message string to show in the toast.</param>
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                        message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}


