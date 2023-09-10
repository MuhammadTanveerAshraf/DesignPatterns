using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class MediatR
    {
        public MediatR()
        {
            Console.WriteLine("It defines an object that encapsulates how a set of objects interacts. MediatR promotes loose coupling by " +
                "keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.");
        }


    }

    //MediatR
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string to, string from, string message);
    }

    //Concrete MediatR
    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();
        public override void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public override void Send(string to, string from, string message)
        {

        }
    }

    //Participant
    public class Participant
    {
        Chatroom chatroom;
        string name;

        public Participant(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public Chatroom Chatroom
        {
            get { return chatroom; }
            set { chatroom = value; }
        }

        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }

        public virtual void Recieve(string from, string message)
        {
            Console.WriteLine("{0} to {1}: {2}", from, name, message);
        }
    }

    public class Beatle : Participant
    {
        public Beatle(string name): base(name)
        {

        }
        public override void Recieve(string from, string message)
        {
            Console.WriteLine("To Beatle: ");
            base.Recieve(from, message);
        }
    }

    public class NonBeatle : Participant
    {
        public NonBeatle(string name) : base(name)
        {

        }
        public override void Recieve(string from, string message)
        {
            Console.WriteLine("To NonBeatle: ");
            base.Recieve(from, message);
        }
    }
}
