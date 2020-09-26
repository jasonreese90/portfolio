//Jason Quedenfeld
package environment;


import weapon.Weapon;
import lifeform.*;

/**
 * A Cell that can hold a LifeForm
 *
 */
public class Cell
{
    private LifeForm entity;
    
    private Weapon[] weapons = new Weapon[3];
    
    /**
     * @return the LifeForm in this Cell.
     */
    public LifeForm getLifeForm()
    {
        return entity;
    }
    
    /**
     * Tries to add the LifeForm to the Cell. Will not add if 
     * LifeForm is already present.
     * @return true if LifeForm was added to the Cell, false otherwise.
     */
    public boolean addLifeForm(LifeForm entity)
    {
        if(this.entity == null)
        {
            this.entity = entity;
            return true;
        }
        
        return false;
    }
    
    /**
     * Removes an existing LifeForm from the cell.
     * @return  returns a LifeForm if ones is present, otherwise returns null.
     */
    public LifeForm removeLifeForm()
    {
        LifeForm temp = entity;
        entity = null;
        
        return temp;
    }
    
    
    /**
     * 
     * @param slot the slot in the cell containing the weapon.
     * @return
     */
	public Weapon getWeapon(int slot) 
	{
		if(slot < weapons.length)
		{
			return weapons[slot];
		}
		
		return null;
	}
	
	/**
	 * Adds a weapon to the cell.
	 * 
	 * @param slot slot in the cell to add the weapon to.
	 * @param weapon weapon to be added to the cell.
	 */
	public void addWeapon(int slot, Weapon weapon)
	{
		if(slot < weapons.length)
		{
			if(weapons[slot] == null)
			{
				weapons[slot] = weapon;
			}
		}
	}
	
	/**
	 * Removes a weapon from the cell.
	 * 
	 * @param slot the slot in the cell to remove the weapon from.
	 * @return returns the removed weapon.
	 */
	public Weapon removeWeapon(int slot)
	{
		if(slot < weapons.length)
		{	
			Weapon temp = weapons[slot];
			weapons[slot] = null;
			return temp;
		}
		
		return null;
	}
}
