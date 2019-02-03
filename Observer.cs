using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;

public class Program
{
    public static void Main()
    {
        YoutubeChannel s = new YoutubeChannel("state 1")
        {
        	new YoutubeSubscriber("ob1"),
        	new YoutubeSubscriber("ob2"),
        	new YoutubeSubscriber("ob3"),
        };
        s += new YoutubeSubscriber("ob4");
        s.SetState("Text Changed!");
        
    }
}

public abstract class Observer
{
    public abstract void Update(string state);
}

public abstract class Subject:IEnumerable
{
    protected string SubjectState;

    protected List<Observer> Observers = new List<Observer>();

    public virtual void Add(Observer o) => Observers.Add(o); 
    public virtual void AttachRange(List<Observer> o) =>Observers.AddRange(o);
    public virtual void Detach(Observer o) => Observers.Remove(o);

    public abstract void SetState(string state);

    protected virtual void Notify()=>
        Observers.ForEach(o => o.Update(this.SubjectState));
	
	public string GetState()
	{
		return SubjectState;
	}
	
	public List<Observer> GetObservers()
	{
		return Observers;
	}
	
	public IEnumerator GetEnumerator()
	{
	     foreach(var o in Observers)
		 {
		      yield return o;
		 }
	}
	
}

public class YoutubeChannel : Subject
{
    public YoutubeChannel(string state)=>
        SetState(state);
        
    public override void SetState(string state)
    {
        if (this.SubjectState != state)//when the state changes set it
        {
            SubjectState = state;
            Notify();//notify the subscribers
        }
    }
	
	public static YoutubeChannel operator+(YoutubeChannel c, YoutubeSubscriber s)
	{
	     c.Add(s);
		 return c;
	}
}

public class YoutubeSubscriber : Observer
{
    private string Name { get; set; }
    public YoutubeSubscriber(string name)=>this.Name = name;
    

    public override void Update(string state)=>
        Console.WriteLine($"Observer{Name} notified. New Subject state{state}");
    

}