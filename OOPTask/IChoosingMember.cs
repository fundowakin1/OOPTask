using OOPTask.Models;

namespace OOPTask
{
    public interface IChoosingMember
    { 
        public void ChoosingMember();
        public MemberEntity ChosenMember { get; set; }
    }
}