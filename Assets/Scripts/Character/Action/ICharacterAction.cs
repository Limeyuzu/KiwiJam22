namespace AdventureTogether
{
    public interface ICharacterAction
    {
        void ActOnOtherCharacter(Character thisChar, Character enemy);
        void ActOnParty(Character thisChar, Party party);
    }
}
