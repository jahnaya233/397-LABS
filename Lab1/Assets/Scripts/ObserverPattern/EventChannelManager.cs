using UnityEngine;
using System.Collections.Generic;



/// <summary>
/// This class will be responsible to hold all of the channels for the observer pattern
/// </summary>
/// 


public class EventChannelManager: PersistentSingleton<EventChannelManager>
{
    public VoidEventChannel voidEvent;
    public FloatEventChannel floatEvent;
    public GameDataEventChannel gameDataEvent;


}
//public abstract class Subject : MonoBehaviour
//{

//    private List<IObserver> observers = new List<IObserver>();

//    public void AddObserver(IObserver observer)
//    {
//        observers.Add(observer);
//    }

//    public void RemoveObserver(IObserver observer)
//    {
//        observers.Remove(observer);
//    }
//    public void NotifyObservers()
//    {
//        foreach(IObserver observer in observers)
//        {
//            observer.Notify();
//        }
//    }
//}