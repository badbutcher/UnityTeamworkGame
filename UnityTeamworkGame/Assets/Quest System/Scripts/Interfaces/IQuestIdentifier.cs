using UnityEngine;
using System.Collections;

namespace QuestSystem
{
    public interface IQuestIdentifier
    {
        int ID { get; }
        int SourceID { get; }
    }
}
