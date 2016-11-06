using UnityEngine;
using System.Collections;
using System;

namespace QuestSystem
{
    public class QuestIdentifier : IQuestIdentifier
    {

        private int id;
        private int sourceID;


        public int ID
        {
            get
            {
                return id;
            }
        }

        public int SourceID
        {
            get
            {
                return sourceID;
            }
        }
    }
}
