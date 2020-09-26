package weapon;

import static org.junit.Assert.*;

import org.junit.Test;

//Tests our weapon class Pistol
public class TestPistol
{

    //Tests that we can create a pistol
    @Test
    public void testInitialize()
    {
        Pistol weap = new Pistol(10, 50, 10, 2, 10);
        assertEquals(10, weap.getMaxAmmo());
        assertEquals(50, weap.getMaxRange());
        assertEquals(10, weap.getBaseDamage());
        assertEquals(2,  weap.getRateOfFire());
        assertEquals(10, weap.getCurrentAmmo());
    }
    
    //Tests that the pistol properly does damage.
    @Test
    public void testDamage()
    {
        Pistol weap = new Pistol(10, 50, 10, 2, 10);

        assertEquals(8, weap.calculateDamage(20));
    }

}
