using System;
using System.Collections.Generic;
namespace FactoryApp
{
	public class Program
	{
		public static void Main()
		{
			House h = new House();
			h.Build();
			h.ShowParts();
			//Ball b4 = new Ball();//compilation error
		}
	}
	
	public interface IBuild
	{
		string Name{get;}
		void Build();	
	}
	
	public class Foundation :IBuild
	{
		public string Name{get;} = "Foundation";
		public void Build()
		{
			Console.WriteLine("Making foundation Pouring Concrete!");
		}
	}
	
	public class Frame :IBuild
	{
		public string Name{get;} ="Frame";
		public void Build()
		{
			Console.WriteLine("Building the house Frame");
		}
	}
	
	public class Walls :IBuild
	{
		public string Name{get;} ="Walls";
		public void Build()
		{
			Console.WriteLine("Adding the walls to the house");
		}
	}
	
	public class Roof :IBuild
	{
		public string Name{get;} = "Roof";
		public void Build()
		{
			Console.WriteLine("Adding the Roof");
		}
	}
	
	public class HousePhase
	{
		public IBuild Create(int phase)
		{
			switch(phase)
			{
				case 0:
					return new Foundation();
				case 1:
					return new Frame();
				case 2:
					return new Walls();
				case 3:
					return new Roof();
				default:
					return new Foundation();
			}
		}
	}
	
	public class House
	{
		private List<IBuild> parts = new List<IBuild>();
		public string Name{get;set;}
		public float Price{get;set;}
			
		public void Build()
		{
			int i =0;
			while(i<4)
			{
				var p =  new HousePhase();
				parts.Add(p.Create(i));
				i++;	
			}
		}
		
		public void ShowParts()
		{
			foreach(var part in parts)
			{
				Console.WriteLine(part.Name);
			}
		}
		
	}
}
