namespace AdventureTogether
{
    public interface ICharacterAction
    {
        void Act(Character thisChar, Party party, Character target);
    }
}
