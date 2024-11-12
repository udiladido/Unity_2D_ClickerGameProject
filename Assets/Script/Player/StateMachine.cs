
public abstract class StateMachine
{
    protected ICharacterStrategy characterStrategy;


    public void ChangeCharacter(ICharacterStrategy character)
    {

        characterStrategy = character;
        
    }

    public void Attack()
    {
        characterStrategy?.Attack();

    }

}
