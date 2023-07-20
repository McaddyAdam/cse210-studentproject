// Goal.cs

public class Goal
{
    protected string name;
    protected bool isCompleted;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.isCompleted = false;
        this.points = points;
    }

    public virtual void RecordCompletion()
    {
        // Implement recording completion logic here
    }

    public virtual string GetGoalStatus()
    {
        // Implement logic to get the status of the goal here
    }

    // Add any other common methods and properties here
}
