using System;
namespace MySingletonApp{
	public class Program
	{
		public static void Main()
		{
			Ball b = Ball.Singleton;
			Ball b2 = Ball.Singleton;
			Ball b3 = Ball.Singleton;
			//Ball b4 = new Ball();//compilation error
		}
	}

	public class Ball
	{
		private static Ball _instance = null;
		private Ball(){}
		public static Ball Singleton
		{
			get
			{
				if(Ball._instance == null){
					Ball._instance =  new Ball();
					Console.WriteLine("Created a new Ball instance!");
				}
				else{
					Console.WriteLine("Ball instance already Created!");	
				}
				return Ball._instance;
			}
		}
	}
}
