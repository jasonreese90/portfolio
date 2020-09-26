import java.util.ArrayList;
import java.util.Comparator;


public class Main 
{
	public static void main(String[] args)
	{
		ArrayList<Point> al = new ArrayList<Point>();
		
		int maxDistance = 5;
		
		al.sort(new Comparator<Point>() {

			@Override
			public int compare(Point arg0, Point arg1) 
			{
				int dis = distance(arg0,arg1);
				if(dis >= maxDistance)
					return 1;
				else
					return -1;
			}
		});
		
		int dis = 0;
		int count = 0;
		while(dis < maxDistance)
		{
			Point previousPoint;
			for(Point p : al)
			{
				dis = distance(p, previousPoint);
				previousPoint = p;
			}
			count++;
		}
	}
	
	public static int distance(Point p1, Point p2)
	{
		int x = p2.x-p1.x;
		int y = p2.y-p1.y;
		int z = p2.z- p1.z;
		
		return (int)Math.sqrt((x*x)+(y*y)+(z*z));
	}
	
	class Point
	{
		int x,y,z;
	}
}
