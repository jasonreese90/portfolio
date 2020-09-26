//Jason Quedenfeld
package environment;

import static org.junit.Assert.*;

import org.junit.Test;

import weapon.PlasmaCannon;
import weapon.Weapon;
import lifeform.*;

/**
 * The test cases for the Cell class
 *
 */
public class TestCell
{
	
    /**
     * At initialization, the Cell should be empty and not contain a LifeForm.
     */
    @Test
    public void testInitialization()
    {
       Cell cell = new Cell();
       assertNull(cell.getLifeForm());
       assertNull(cell.getWeapon(0));
       assertNull(cell.getWeapon(1));
    }
    
    /**
	 * Tests that a weapon can be added to a cell.
	 */
    @Test
    public void testAddWeapon()
    {
    	Cell cell = new Cell();
    	PlasmaCannon cannon = new PlasmaCannon(4,50,40,1,2);
    	cell.addWeapon(0, cannon);
    	
    	assertEquals(cannon,cell.getWeapon(0));
    }
    
    /**
	 * Tests that a weapon can be removed from a cell.
	 */
    @Test
    public void testRemoveWeapon()
    {
    	Cell cell = new Cell();
    	PlasmaCannon cannon = new PlasmaCannon(4,50,40,1,2);
    	cell.addWeapon(0, cannon);
    	
    	
    	Weapon weapon = cell.removeWeapon(0);
    	
    	assertNull(cell.getWeapon(0));
    	assertEquals(cannon,weapon);
    }
    
    /**
	 * Tests that a weapon cannot be added to a slot that already contains a weapon.
	 */
    @Test
    public void testCannotAddWeaponInPopulatedSlot()
    {
    	Cell cell = new Cell();
    	PlasmaCannon cannon = new PlasmaCannon(4,50,40,1,2);
    	PlasmaCannon cannon2 = new PlasmaCannon(4,50,40,1,2);
    	cell.addWeapon(0, cannon);
     	cell.addWeapon(0, cannon2);

     	assertEquals(cannon,cell.getWeapon(0));
    }
    
    

	/**
	 * Start Section for Lab 1 Tests
	 */
		
    /**
     * Checks to see if we change the LifeForm held by the Cell that
     * getLifeForm properly responds to this change.
     */
    @Test
    public void testSetLifeForm()
    {
        LifeForm bob = new MockLifeForm("Bob",40);
        LifeForm fred = new MockLifeForm("Fred",40);
        Cell cell = new Cell();
        
        // The cell is empty so this should work.
        
        boolean success = cell.addLifeForm(bob);
        assertTrue(success);
        assertEquals(bob,cell.getLifeForm());
        
        // The cell is not empty so this should fail.
        success = cell.addLifeForm(fred);
        assertFalse(success);
        assertEquals(bob,cell.getLifeForm());  
    }

    /**
	 * Tests that a life form can be removed from the cell.
	 */
    @Test
    public void testRemoveLifeForm()
    {
        Cell cell = new Cell();
        LifeForm bob = new MockLifeForm("Bob",40);
        
        // The cell is empty so this should work.
        
        boolean success = cell.addLifeForm(bob);
        assertTrue(success);
     
        LifeForm entity = cell.removeLifeForm();
        
        //returned LifeForm from removeLifeForm shouldn't be null
        assertNotNull(entity);
        // getLifeForm should return null
        assertNull(cell.getLifeForm());
    }
}
