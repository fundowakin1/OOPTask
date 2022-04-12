using OOPTask.Models;

namespace OOPTask.Interfaces
{
    public interface IChoosingMember
    { 
        public void ChoosingMember();
        public MemberEntity ChosenMember { get; set; }
    }
}