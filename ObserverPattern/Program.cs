using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var channel = new YoutubeChannel("Curso em Vídeo");

            var subscriber1 = new Subscriber("Carol");
            channel.Attach(subscriber1);

            var subscriber2 = (new Subscriber("Vitória"));
            channel.Attach(subscriber2);

            var subscriber3 = (new Subscriber("Fernanda"));
            channel.Attach(subscriber3);

   
            channel.Attach(new VipSubscriber());

            channel.UploadNewVideo();

            channel.Detach(subscriber3);
            channel.ChangeName("Curso em Vídeo dos Gafanhotos");

            Console.ReadKey();*/
        }
    }

    public interface ISubject
    {
        void Attach(IObserver o);
        void Detach(IObserver o);
        void Notify();
    }

    public interface IObserver
    {
        void Update(ISubject s);
    }

    public class YoutubeChannel : ISubject
    {
        readonly List<IObserver> observers;

        public string Name{ get; private set;}

        public YoutubeChannel(string name)
        {
            observers = new List<IObserver>();

            Name = name;
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Anexando novo observador!");
            Console.WriteLine();
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Console.WriteLine("Desanexando observador!");
            Console.WriteLine();
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
                observer.Update(this);
        }

        public void ChangeName(string newName)
        {
            Console.WriteLine("O Canal {0} alterou o nome para {1}", Name, newName);
            Console.WriteLine();

            Name = newName;

            Notify();
        }
        public void UploadNewVideo()
        {
            Console.WriteLine("O Canal {0} publicou um novo Vídeo!", Name);
            Console.WriteLine();

            Notify();
        }
    }

    public class Subscriber : IObserver
    {
        public string Name { get; private set; }
        public Subscriber(string name)
        {
            Name = name;
        }
        public void Update(ISubject subject)
        {
            Console.WriteLine("O usuário {0} recebeu a notificação das alterações no canal {1}",
                Name, (subject as YoutubeChannel).Name);

            Console.WriteLine();
        }

    }

    public class VipSubscriber : IObserver
    {
        public void Update(ISubject subject)
        {
            Console.WriteLine("Heyy, eu sou usuário VIP mas também recebo notifição do canal {0}!!",
                (subject as YoutubeChannel).Name);
            Console.WriteLine();
        }
    }
}
