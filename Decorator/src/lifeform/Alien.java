// Jason Quedenfeld
package lifeform;

import gameplay.TimeObserver;
import recovery.RecoveryBehavior;

/**
 * A LifeForm representing an Alien, which
 * can have different types of RecoveryBehaviors.
 *
 */
public class Alien extends LifeForm 
{
	private RecoveryBehavior recoveryBehavior;
	private int maxLifePoints;
	private int recoveryRate;
	
	/**
	 * Creates an Alien with a name and life points, but RecoveryBehavior is null.
	 * @param name name of the Alien.
	 * @param life amount of life points the Alien possesses.
	 */
	public Alien(String name, int life)
	{
		this(name,life,null);
	}
	
	/**
	 * Creates an Alien with a name, life points, and a RecoveryBehavior.
	 * @param name name of the Alien.
	 * @param life amount of life points the Alien possesses.
	 * @param rb RecoveryBehavior the Alien possesses.
	 */
	public Alien(String name, int life, RecoveryBehavior rb)
	{
		this(name,life,rb,0);
	}
	
	/**
	 * Creates an Alien with a name, life points, and a RecoveryBehavior.
	 * @param name name of the Alien.
	 * @param life amount of life points the Alien possesses.
	 * @param rb RecoveryBehavior the Alien possesses.
	 * @param attack the strength of the attack the Alien possesses.
	 */
	public Alien(String name, int life, RecoveryBehavior rb, int attack)
	{
		this(name,life,rb,attack,0);
	}
	
	public Alien(String name, int life, RecoveryBehavior rb, int attack,int recoveryRate)
	{
		super(name,life,attack);
		recoveryBehavior = rb;
		maxLifePoints = life;
		this.recoveryRate = recoveryRate;
	}
	
	/**
	 *  Calls the calculateRecovery in the corresponding RecoveryBehavior.
	 */
	public void recover()
	{
		if(recoveryBehavior!=null)
			setCurrentLifePoints(recoveryBehavior.calculateRecovery(getCurrentLifePoints(), maxLifePoints ));
	}
	
	
	/**
	 * Sets the current life points.
	 * @param lifePoints the amount to set the life points to.
	 */
	public void setCurrentLifePoints(int lifePoints)
	{
		currentLifePoints = lifePoints;
		if(currentLifePoints > maxLifePoints)
		{
			currentLifePoints = maxLifePoints;
		}
	}
	
	/**
	 * Gets the max life points associated with the Alien.
	 * @return returns the max life points.
	 */
	public int getMaxLifePoints()
	{
		return maxLifePoints;
	}
	
	/**
	 * Gets the recovery rate of the Alien.
	 * @return the recovery rate of the Alien.
	 */
	public int getRecoveryRate()
	{
		return recoveryRate;
	}

	@Override
	public void updateTime(int time) 
	{
		
		if((time%2)==0)
		{
			if(recoveryBehavior!=null)
			{
				setCurrentLifePoints(recoveryBehavior.calculateRecovery
						(currentLifePoints, maxLifePoints));
			}
		}
		
	}
}
