//Jason Quedenfeld
package weapon;

import static org.junit.Assert.*;

import org.junit.Test;

/**
 * 
 * Tests the functionality provided by the PowerBooster class
 *
 */
public class TestPowerBooster 
{
	
	/**
	 * test the basic functionality of power booster.
	 */
	@Test
	public void testBasics() 
	{
		PlasmaCannon weap = new PlasmaCannon(4, 40, 50, 1, 4);
        PowerBooster pb = new PowerBooster(weap);
        
        assertEquals(100, pb.calculateDamage(weap.getMaxRange()-1));
        
        weap.currentAmmo--;
        assertEquals(64, pb.calculateDamage(weap.getMaxRange()-1));
        
        //Testing PlasmaCannon>PowerBooster>Stabilizer
        
        Stabilizer stabilizer = new Stabilizer(pb);
        assertEquals(80, stabilizer.calculateDamage(weap.getMaxRange()-1));
        
        //Testing PlasmaCannon>PowerBooster>Scope
        pb = new PowerBooster(weap);
       	assertEquals(64, pb.calculateDamage(weap.getMaxRange()-1));
        
       	Scope scope = new Scope(pb);
     
       	assertEquals(80, scope.calculateDamage(10));
	}
	
	/**
	 * tests that only 2 attachments can be added.
	 */
	@Test
	public void testCannotAddMoreThanTwoAttachments() 
	{
		PlasmaCannon weap = new PlasmaCannon(4, 50, 40, 2, 4);
        PowerBooster pb = new PowerBooster(weap);
        Scope s = new Scope(pb);
        Stabilizer st = new Stabilizer(s);
  
  
        assertEquals(pb.getAttachmentCount(),1);
        assertEquals(s.getAttachmentCount(),2);
        
        //Stabilizer only contains itself because the attachment count exceeded 2, so it was not added to the other attachments chain
        assertEquals(st.getAttachmentCount(),1);
	}

}
