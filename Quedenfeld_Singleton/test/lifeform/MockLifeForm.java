//Jason Quedenfeld
package lifeform;

/**
 * 
 * Simple MockLifeForm to test against
 *
 */
public class MockLifeForm extends LifeForm
{
	public int myTime;
	
	public MockLifeForm(String name, int points)
	{
		super(name,points);
	}
	
	public MockLifeForm(String name, int points,int attack)
	{
		super(name,points,attack);
	}
	
    @Override
	public void updateTime(int time) 
	{
		myTime = time;
	}
}
