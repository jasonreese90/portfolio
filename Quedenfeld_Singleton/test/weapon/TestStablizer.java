package weapon;

import static org.junit.Assert.*;

import org.junit.Test;

//Tests our Stabilizer
public class TestStablizer
{

    //Makes sure the Damage increase of stabilizer works
    @Test
    public void testDamageIncrease()
    {
        Pistol weap = new Pistol(10, 50, 10, 2, 10);
        Stabilizer st = new Stabilizer(weap);
        assertEquals(10, st.calculateDamage(20));
    }
    
    //Tests that the stabilizer will auto reload.
    @Test
    public void testAutoReload()
    {
        Pistol weap = new Pistol(10, 50, 10, 2, 10);
        Stabilizer st = new Stabilizer(weap);
        weap.setCurrentAmmo(0);
        st.calculateDamage(weap.getMaxRange()-1);
        assertEquals(10, weap.getCurrentAmmo());
    }

}
