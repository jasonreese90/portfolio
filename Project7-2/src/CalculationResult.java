public class CalculationResult
{
    public CalculationResult(int originalValue, int currentValue)
    {
        this.originalValue = originalValue;
        this.currentValue = currentValue;
    }

    private int originalValue;

    private int currentValue;

    public int getOriginalValue()
    {
        return originalValue;
    }

    public void setOriginalValue(int originalValue)
    {
        this.originalValue = originalValue;
    }

    public int getCurrentValue()
    {
        return currentValue;
    }

    public void setCurrentValue(int currentValue)
    {
        this.currentValue = currentValue;
    }
}
