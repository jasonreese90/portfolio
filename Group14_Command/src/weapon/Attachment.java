//Ryan Handley
package weapon;

/**
 * 
 * An implementation of Weapon that represents an
 * attachment that can be attached to another weapon that
 * modifies damage.
 *
 */
public abstract class Attachment implements Weapon
{
	protected Weapon weapon;
	
	/**
	 * Creates and instance.
	 * @param weapon weapon to attach to.
	 */
	public Attachment(Weapon weapon)
	{
		if(getAttachmentCount(weapon) < 2)
		{
			this.weapon = weapon;
		}
	}
	
	/**
	 * 
	 * @return how many attachments possessed.
	 */
	public int getAttachmentCount()
	{
		return getAttachmentCount(this);
	}
	
	/**
	 * Used for internal purposes.
	 * @param weap weapon to count attachments on.
	 * @return how many attachments possessed.
	 */
	private int getAttachmentCount(Weapon weap)
	{
		int attachmentCount = 0;;
		
		while(weap != null && weap instanceof Attachment)
		{
			attachmentCount++;
		    weap = ((Attachment)weap).weapon;
		}
		
		return attachmentCount;
	}
	
	
	public Weapon getWeapon()
	{
		return this.weapon;
	}
	
	@Override
	public abstract int calculateDamage(int dinstance);
}
