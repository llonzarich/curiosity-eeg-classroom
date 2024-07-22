using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

/*namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class SimpleOutletTriggerEvent : MonoBehaviour
    {
        *//*
         * This is a simple example of an LSL Outlet to stream out irregular events occurring in Unity.
         * This uses only LSL.cs and is intentionally simple. For a more robust version, see another sample.
         * 
         * We stream out the trigger event during OnTriggerEnter which is, in our opinion, the closest
         * time to when the trigger actually occurs (i.e., independent of its rendering).
         * A simple way to print the events is with pylsl: `python -m pylsl.examples.ReceiveStringMarkers`
         *
         * If you are instead trying to log a stimulus event then there are better options. Please see the 
         * LSL4Unity SimpleStimulusEvent Sample for such a design.
         *//*
        string StreamName = "LSL4Unity.Samples.SimpleCollisionEvent";
        string StreamType = "Markers";
        private StreamOutlet outlet;
        private string[] sample = {""};
        private int currQuest = 0;

        // A dictionary to keep track of the unique identifiers for each game object.
        private Dictionary<int, string> gameObjectIDs = new Dictionary<int, string>();

        void Start()
        {
            var hash = new Hash128();
            hash.Append(StreamName);
            hash.Append(StreamType);
            hash.Append(gameObject.GetInstanceID());
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 1, LSL.LSL.IRREGULAR_RATE,
                channel_format_t.cf_string, hash.ToString());
            outlet = new StreamOutlet(streamInfo);

            // Register this game object with a unique identifier.
            // RegisterGameObject();
        }

        private void RegisterGameObject()
        {
            int instanceID = gameObject.GetInstanceID();
            Debug.Log("Registering game object with ID: " + instanceID);
            if (!gameObjectIDs.ContainsKey(instanceID))
            {
                gameObjectIDs.Add(instanceID, "GameObject_" + instanceID);
                Debug.Log("Registered: " + gameObjectIDs[instanceID]);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
            if (outlet != null)
            {
                string stringNum = currQuest.ToString();
                *//*int otherInstanceID = other.gameObject.GetInstanceID();
                sample[0] = "Anticipation " + stringNum + otherInstanceID;
                // sample[0] = "Anticipation " + stringNum + gameObject.GetInstanceID();
                Debug.Log("Pushing sample on enter: " + sample[0]);
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);*//*

                int otherInstanceID = other.gameObject.GetInstanceID();
                sample[0] = "Anticipation " + stringNum + otherInstanceID;
                // sample[0] = "Anticipation " + stringNum + gameObjectIDs[gameObject.GetInstanceID()];
                Debug.Log(sample[0]);
                outlet.push_sample(sample);

            }
            else
            {
                Debug.Log("Outlet is null for object: " + gameObject.name);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit called with: " + other.gameObject.name);
            if (outlet != null)
            {
                string stringNum = currQuest.ToString();
                *//*int otherInstanceID = other.gameObject.GetInstanceID();
                sample[0] = "Answer " + stringNum + otherInstanceID;
                // sample[0] = "Answer " + stringNum + gameObject.GetInstanceID();
                Debug.Log("Pushing sample on exit: " + sample[0]);
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);*//*


                int otherInstanceID = other.gameObject.GetInstanceID();
                sample[0] = "Answer " + stringNum + otherInstanceID;
                // sample[0] = "Answer " + stringNum + gameObjectIDs[gameObject.GetInstanceID()];
                Debug.Log(sample[0]);
                outlet.push_sample(sample);

                currQuest += 1;
            }
            else
            {
                Debug.Log("Outlet is null for object: " + gameObject.name);
            }
        }
    }
}*/



namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class SimpleOutletTriggerEvent : MonoBehaviour
    {
        string StreamName = "LSL4Unity.Samples.SimpleCollisionEvent";
        string StreamType = "Markers";
        private StreamOutlet outlet;
        private string[] sample = { "" };
        // private int currQuest = 0;

        void Start()
        {
            var hash = new Hash128();
            hash.Append(StreamName);
            hash.Append(StreamType);
            hash.Append(gameObject.GetInstanceID());
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 1, LSL.LSL.IRREGULAR_RATE,
                channel_format_t.cf_string, hash.ToString());
            outlet = new StreamOutlet(streamInfo);
        }

        private void OnTriggerEnter(Collider other)
         {
             if (outlet != null)
             {
                // int otherInstanceID = other.gameObject.GetInstanceID();
                // sample[0] = "Enter " + otherInstanceID;
                // sample[0] = "TriggerEnter " + gameObject.GetInstanceID();
                sample[0] = "TriggerEnter " + this.gameObject.name;
                Debug.Log(sample[0]);
                outlet.push_sample(sample);
             }
         }

         private void OnTriggerExit(Collider other)
         {
             if (outlet != null)
             {
                //int otherInstanceID = other.gameObject.GetInstanceID();
                // sample[0] = "Exit " + otherInstanceID;
                // sample[0] = "TriggerExit " + gameObject.GetInstanceID();
                sample[0] = "TriggerExit " + this.gameObject.name;
                Debug.Log(sample[0]);
                outlet.push_sample(sample);

                 // currQuest += 1;
             }
         }
     }
 }