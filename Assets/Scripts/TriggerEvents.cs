using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AS
{
    public class TriggerEvents : MonoBehaviour
    {

        public string[] TriggerTags = { "Player" };

        public UnityEvent OnTriggerEnterEvent;
        public UnityEvent OnTriggerExitEvent;

        [Header("<----- For Specific Conditions ----->")]
        public ConditionalTriggerEvents OnEnterConditionalEvents, OnExitConditionalEvents;

        private void OnTriggerEnter(Collider other)
        {

            for (int i = 0; i < TriggerTags.Length; i++)
            {
                if (CheckTags(other, TriggerTags[i]))
                {
                    if (OnTriggerEnterEvent != null)
                    {
                        OnTriggerEnterEvent.Invoke();
                    }


                    if (OnEnterConditionalEvents)
                        OnEnterConditionalEvents.OnEvent();
                }
            }




        }

        private void OnTriggerExit(Collider other)
        {

            for (int i = 0; i < TriggerTags.Length; i++)
            {
                if (CheckTags(other, TriggerTags[i]))
                {
                    if (OnTriggerExitEvent != null)
                    {
                        OnTriggerExitEvent.Invoke();
                    }

                    if (OnExitConditionalEvents)
                        OnExitConditionalEvents.OnEvent();

                   
                }
            }


        }


        public void AddOnEnterConditionalEvent(ConditionalTriggerEvents events)
        {
            OnEnterConditionalEvents = events;
        }

        public void AddOnExitConditionalEvent(ConditionalTriggerEvents events)
        {
            OnExitConditionalEvents = events;
        }

        public void RemoveOnEnterConditionalEvent()
        {
            OnEnterConditionalEvents = null;
        }

        public void RemoveOnExitConditionalEvent()
        {
            OnExitConditionalEvents = null;
        }

        bool CheckTags(Collider other, string tag)
        {

            if (other.CompareTag(tag))
                return true;
            else return false;

        }
    }
}

